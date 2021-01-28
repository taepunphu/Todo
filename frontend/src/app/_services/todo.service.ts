import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { TodoItem } from '../_models/todoItem';

@Injectable({
  providedIn: 'root',
})
export class TodoService {
  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) {}

  getTodos(): Observable<TodoItem[]> {
    return this.http.get<TodoItem[]>(this.baseUrl + 'todo/' + 'gettodolist');
  }

  getTodoById(id: number): Observable<TodoItem> {
    return this.http.get<TodoItem>(this.baseUrl + 'todo/' + 'gettodo/' + id);
  }

  insertTodo(todo: TodoItem) {
    return this.http.post(this.baseUrl + 'todo/' + 'insert', todo);
  }

  updateTodo(todo: TodoItem) {
    return this.http.put(this.baseUrl + 'todo/' + 'update', todo);
  }

  deleteTodo(id: number) {
    return this.http.delete(this.baseUrl + 'todo/' + 'delete/' + id);
  }

  updateTask(model: any) {
    return this.http.put(this.baseUrl + 'todo/' + 'updatetask', model);
  }
}
