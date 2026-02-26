import { Routes } from '@angular/router';
import { TaskComponent } from './task/task';

export const routes: Routes = [
  { path: '', component: TaskComponent },
  { path: 'task', component: TaskComponent }
];
