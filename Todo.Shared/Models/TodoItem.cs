using System;
using System.ComponentModel.DataAnnotations;

namespace Todo.Shared.Models
{
    public class TodoItem
    {
        [Key]
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime Created_Date { get; set; }
        public DateTime Updated_Date { get; set; }
        public string IsActive { get; set; }
    }
}