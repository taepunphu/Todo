using System.Collections.Generic;
using NSubstitute;
using Todo.Shared.Models;
using Todo.Shared.Repositories;
using Todo.Shared.Services;
using Xunit;

namespace Todo.Tests.Services
{
    public class TodoServiceTest
    {
        private readonly ITodoRepository _repo;
        private readonly ITodoService _service;

        public TodoServiceTest()
        {
            _repo = Substitute.For<ITodoRepository>();
            _service = new TodoService(_repo);
        }

        [Fact]
        public void GetTodoItems()
        {
            //Given
            var expected = new List<TodoItem>();
            _repo.GetTodoItems().Returns(expected);

            //When
            var actual = _service.GetTodoItems();

            //Then
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FindTodoItemById()
        {
            //Given
            var expected = new TodoItem();
            _repo.FindTodoItemById(Arg.Any<int>()).Returns(expected);

            //When
            var actual = _service.FindTodoItemById(1);

            //Then
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Insert()
        {
            //Given
            var expected = 1;
            _repo.Insert(Arg.Any<TodoItem>()).Returns(expected);

            //When
            var actual = _service.Insert(new TodoItem());

            //Then
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Update()
        {
            //Given
            var expected = 1;
            _repo.Update(Arg.Any<TodoItem>()).Returns(expected);

            //When
            var actual = _service.Update(new TodoItem());

            //Then
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Delete()
        {
            //Given
            var expected = 1;
            _repo.Delete(Arg.Any<int>()).Returns(expected);

            //When
            var actual = _service.Delete(1);

            //Then
            Assert.Equal(expected, actual);
        }
    }
}