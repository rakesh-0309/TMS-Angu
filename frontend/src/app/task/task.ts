import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { TaskService, Task } from './task.service';

@Component({
  selector: 'app-task',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './task.html',
  styleUrl: './task.css'
})
export class TaskComponent implements OnInit {
  tasks: Task[] = [];
  newTask: Partial<Task> = {
    task_Title: '',
    task_Discription: '',
    dueDate: '',
    status: '',
    remark: '',
    createdBy: ''
  };
  loading = false;
  error = '';
  successMessage = '';

  constructor(private taskService: TaskService, private cdr: ChangeDetectorRef) {}

  ngOnInit(): void {
    this.loadTasks();
  }

  loadTasks(): void {
    this.loading = true;
    this.error = '';
    this.taskService.getTasks().subscribe({
      next: (tasks) => {
        console.log('Tasks received:', tasks);
        this.tasks = tasks || [];
        this.loading = false;
        this.cdr.detectChanges();
      },
      error: (err) => {
        this.error = 'Failed to load tasks. Make sure your API is running.';
        this.loading = false;
        this.cdr.detectChanges();
        console.error('Error loading tasks:', err);
      }
    });
  }

  createTask(): void {
    if (!this.newTask.task_Title) return;
    
    this.taskService.createTask(this.newTask).subscribe({
      next: (task) => {
        this.tasks.push(task);
        this.resetNewTask();
        this.cdr.detectChanges();
      },
      error: (err) => {
        this.error = 'Failed to create task';
        console.error('Error creating task:', err);
      }
    });
  }

  resetNewTask(): void {
    this.newTask = {
      task_Title: '',
      task_Discription: '',
      dueDate: '',
      status: '',
      remark: '',
      createdBy: ''
    };
  }

  updateTask(task: Task): void {
    console.log('Updating task:', task);
    this.taskService.updateTask(task).subscribe({
      next: (updatedTask) => {
        console.log('Update success:', updatedTask);
        const index = this.tasks.findIndex(t => t.task_Id === updatedTask.task_Id);
        if (index !== -1) {
          this.tasks[index] = updatedTask;
        }
        this.loadTasks(); // Reload to get fresh data
      },
      error: (err) => {
        this.error = 'Failed to update task';
        console.error('Error updating task:', err);
      }
    });
  }

  deleteTask(id: number): void {
    if (!confirm('Are you sure you want to delete this task?')) {
      return;
    }
    
    this.taskService.deleteTask(id).subscribe({
      next: () => {
        console.log('Delete success');
        this.tasks = this.tasks.filter(t => t.task_Id !== id);
        this.successMessage = 'Task deleted successfully!';
        this.cdr.detectChanges();
        setTimeout(() => {
          this.successMessage = '';
          this.cdr.detectChanges();
        }, 3000);
      },
      error: (err) => {
        console.error('Error deleting task:', err);
        // Check if it's the known "DB error" but delete actually worked
        if (err.error === 'DB error') {
          this.tasks = this.tasks.filter(t => t.task_Id !== id);
          this.successMessage = 'Task deleted successfully!';
          this.cdr.detectChanges();
          setTimeout(() => {
            this.successMessage = '';
            this.cdr.detectChanges();
          }, 3000);
        } else {
          this.error = 'Failed to delete task';
        }
      }
    });
  }
}