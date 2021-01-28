using System.Collections.Generic;
using Todo.Shared.Models;

namespace Todo.Shared.Services
{
    public interface ITodoService
    {
        IEnumerable<TodoItem> GetTodoItems();
        TodoItem FindTodoItemById(int id);
        int Insert(TodoItem todoItem);
        int Update(TodoItem todoItem);
        int Delete(int id);
    }
}