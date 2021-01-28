using System;
using System.Collections.Generic;
using Todo.Shared.Models;
using Todo.Shared.Repositories;

namespace Todo.Shared.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _repo;
        public TodoService(ITodoRepository repo)
        {
            _repo = repo;
        }

        public int Delete(int id)
        {
            return _repo.Delete(id);
        }

        public TodoItem FindTodoItemById(int id)
        {
            return _repo.FindTodoItemById(id);
        }

        public IEnumerable<TodoItem> GetTodoItems()
        {
            return _repo.GetTodoItems();
        }

        public int Insert(TodoItem todoItem)
        {
            var item = new TodoItem()
            {
                Subject = todoItem.Subject,
                Description = todoItem.Description,
                IsActive = "A",
                Created_Date = DateTime.Now
            };
            return _repo.Insert(item);
        }

        public int IsActiveTask(TodoItem todoItem)
        {
            var item = new TodoItem()
            {
                Id = todoItem.Id,
                IsActive = todoItem.IsActive,
                Updated_Date = DateTime.Now
            };

            return _repo.IsActiveTask(item);
        }

        public int Update(TodoItem todoItem)
        {
            var item = new TodoItem()
            {
                Subject = todoItem.Subject,
                Description = todoItem.Description,
                IsActive = todoItem.IsActive,
                Updated_Date = DateTime.Now
            };

            return _repo.Update(item);
        }
    }
}