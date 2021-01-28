using Microsoft.AspNetCore.Mvc;
using Todo.API.Dtos;
using Todo.Shared.Models;
using Todo.Shared.Services;

namespace Todo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private readonly ITodoService _service;

        public TodoController(ITodoService service)
        {
            _service = service;
        }

        [HttpGet("gettodolist")]
        public IActionResult GetTodoList()
        {
            var data = _service.GetTodoItems();
            return Ok(data);
        }

        [HttpGet("gettodo/{id}")]
        public IActionResult GetTodoById(int id)
        {
            var data = _service.FindTodoItemById(id);
            return Ok(data);
        }

        [HttpPost("insert")]
        public IActionResult InsertTodo(TodoItem todoItem)
        {
            var data = _service.Insert(todoItem);
            return Ok(data);
        }

        [HttpPut("update")]
        public IActionResult UpdateTodo(TodoItem todoItem)
        {
            var data = _service.Update(todoItem);
            return Ok(StatusCode(200));
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteTodo(int id)
        {
            var data = _service.Delete(id);
            return Ok(StatusCode(200));
        }

        [HttpPut("updatetask")]
        public IActionResult UpdateTask(TodoForUpdateTaskDto todoForUpdateTaskDto)
        {
            var datanew = new TodoItem()
            {
                Id = todoForUpdateTaskDto.Id,
                IsActive = todoForUpdateTaskDto.IsActive
            };

            var data = _service.IsActiveTask(datanew);
            return Ok(StatusCode(200));
        }

    }
}