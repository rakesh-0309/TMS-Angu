import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

export interface Task {
  task_Id: number | null;
  task_Title: string | null;
  task_Discription: string | null;
  dueDate: string | null;
  status: string | null;
  remark: string | null;
  createdOn: string | null;
  lastUpdatedDate: string | null;
  createdBy: string | null;
  lastUpdatedBy: string | null;
}

export interface ApiResponse<T> {
  mssg: string;
  data: T;
}

@Injectable({
  providedIn: 'root'
})
export class TaskService {
  private apiUrl = 'https://localhost:7130/api/Task';

  constructor(private http: HttpClient) {}

  private formatDate(date: string | null): string | null {
    if (!date) return null;
    // If already in ISO format, return as is
    if (date.includes('Z') || date.includes('+')) return date;
    // Convert datetime-local (2026-01-25T15:07) to ISO format (2026-01-25T15:07:00.000Z)
    return new Date(date).toISOString();
  }
  // Get all tasks
  getTasks(): Observable<Task[]> {
    const payload = {
      task_Id: null,
      task_Title: ''
    };
    return this.http.post<ApiResponse<Task[]>>(`${this.apiUrl}/listOfTask`, payload)
      .pipe(map(response => response.data));
  }

  // Get a single task by ID
  getTaskById(id: number): Observable<Task> {
    const payload = {
      task_Id: id,
      task_Title: ''
    };
    return this.http.post<ApiResponse<Task>>(`${this.apiUrl}/listOfTask`, payload)
      .pipe(map(response => response.data));
  }

  

  // Create a new task
  createTask(task: Partial<Task>): Observable<Task> {
    const payload = {
      task_Id: null,
      task_Title: task.task_Title || '',
      task_Discription: task.task_Discription || '',
      dueDate: this.formatDate(task.dueDate || null),
      status: task.status || '',
      remark: task.remark || '',
      createdBy: task.createdBy || '',
      lastUpdatedBy: ''
    };
    return this.http.post<ApiResponse<Task>>(`${this.apiUrl}/registerTask`, payload)
      .pipe(map(response => response.data));
  }

  // Update an existing task
  

  // Update an existing task
  updateTask(task: Task): Observable<Task> {
    const payload = {
      task_Id: task.task_Id,
      task_Title: task.task_Title || '',
      task_Discription: task.task_Discription || '',
      dueDate: this.formatDate(task.dueDate),
      status: task.status || '',
      remark: task.remark || '',
      createdBy: task.createdBy || '',
      lastUpdatedBy: task.lastUpdatedBy || ''
    };
    return this.http.post<ApiResponse<Task>>(`${this.apiUrl}/updateTask`, payload)
      .pipe(map(response => response.data));
  }

  // Delete a task
  deleteTask(id: number): Observable<void> {
    return this.http.post<ApiResponse<void>>(`${this.apiUrl}/deleteTask`, { task_Id: id })
      .pipe(map(response => response.data));
  }
}
