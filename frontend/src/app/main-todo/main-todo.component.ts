import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { TodoItem } from '../_models/todoItem';
import { TodoService } from '../_services/todo.service';

@Component({
  selector: 'app-main-todo',
  templateUrl: './main-todo.component.html',
  styleUrls: ['./main-todo.component.css'],
})
export class MainTodoComponent implements OnInit {
  addTaskForm: FormGroup;
  todoItem: TodoItem;
  todoItemList: TodoItem[];
  todoModel: TodoItem;
  model: any = {};

  constructor(private todoService: TodoService, private fb: FormBuilder) {}

  ngOnInit() {
    this.createTodoItemForm();
    this.getTodoItems();
  }

  createTodoItemForm() {
    this.addTaskForm = this.fb.group({
      subject: ['', Validators.required],
      description: ['', Validators.required],
    });
  }

  addTask() {
    if (this.addTaskForm.valid) {
      this.todoItem = Object.assign({}, this.addTaskForm.value);
      console.log(this.todoItem);
      this.todoService.insertTodo(this.todoItem).subscribe(
        (response) => {
          this.getTodoItems();
        },
        (error) => {
          console.log(error);
        }
      );
    }
  }

  getTodoItems() {
    this.todoService.getTodos().subscribe(
      (response) => {
        console.log(response);
        this.todoItemList = response;
      },
      (error) => {
        console.log(error);
      }
    );
  }

  editTodoItem(id) {
    this.todoService.getTodoById(id).subscribe(
      (response) => {
        this.todoItem = response;
      },
      (error) => {
        console.log(error);
      }
    );
  }

  checkOutTodoItem(id: number, isActive: string) {
    this.model.id = id;
    if (isActive === 'A') {
      this.model.isActive = 'N';
    } else {
      this.model.isActive = 'A';
    }

    this.todoService.updateTask(this.model).subscribe(
      (response) => {
        this.getTodoItems();
      },
      (error) => {
        console.log(error);
      }
    );
  }

  deleteTodoItem(id) {
    this.todoService.deleteTodo(id).subscribe(
      (response) => {
        this.getTodoItems();
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
