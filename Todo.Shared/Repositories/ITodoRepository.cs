using System.Collections.Generic;
using Todo.Shared.Models;

namespace Todo.Shared.Repositories
{
    public interface ITodoRepository
    {
         IEnumerable<TodoItem> GetTodoItems();
         TodoItem FindTodoItemById(int id);
         int Insert(TodoItem todoItem);
         int Update(TodoItem todoItem);
         int Delete(int id);
    }
}