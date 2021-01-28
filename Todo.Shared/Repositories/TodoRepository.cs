using System.Collections.Generic;
using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Todo.Shared.Models;

namespace Todo.Shared.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _connection;
        public TodoRepository(IConfiguration configuration) => _configuration = configuration;
        public TodoRepository(IDbConnection connection) => _connection = connection;
        public virtual IDbConnection OpenDbConnection()
        {
            if (!string.IsNullOrEmpty(_configuration.GetConnectionString("DefaultConnection")))
            {
                return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            }
            return _connection;
        }
        public int Delete(int id)
        {
            using (var sqlConnection = OpenDbConnection())
            {
                string sql = @"delete from TODO_ITEM where Id = @id";
                return sqlConnection.Execute(sql, id);
            }
        }

        public TodoItem FindTodoItemById(int id)
        {
            using (var sqlConnection = OpenDbConnection())
            {
                string sql = @"select * from TODO_ITEM where Id = @id";
                return sqlConnection.QuerySingleOrDefault<TodoItem>(sql, id);
            }
        }

        public IEnumerable<TodoItem> GetTodoItems()
        {
            using (var sqlConnection = OpenDbConnection())
            {
                string sql = @"select * from TODO_ITEM";
                return sqlConnection.Query<TodoItem>(sql);
            }
        }

        public int Insert(TodoItem todoItem)
        {
            using (var sqlConnection = OpenDbConnection())
            {
                string sql = @"insert into TODO_ITEM(Subject,Description,StartDate,EndDate,Created_Date,IsActive) ";
                sql += " values(@Subject,@Description,@StartDate,@EndDate,@Created_Date,@IsActive)";
                return sqlConnection.ExecuteScalar<int>(sql, todoItem);
            }
        }

        public int Update(TodoItem todoItem)
        {
            using (var sqlConnection = OpenDbConnection())
            {
                string sql = @"update TODO_ITEM set Subject = @Subject, Description = @Description, StartDate = @StartDate, EndDate = @EndDate, IsActive = @IsActive, Updated_Date = @Updated_Date";
                return sqlConnection.Execute(sql, todoItem);
            }
        }
    }
}