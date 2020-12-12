using SQLite;
using System;

namespace Miniproject.Models
{
    public class Task
    {
        [PrimaryKey]
        public string Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public bool IsComplete { get; set; }
        public string Description { get; set; }

        public Task()
        {
            Date = DateTime.Now;
        }
    }
}