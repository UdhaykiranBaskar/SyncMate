using System;

namespace SyncMate.Models
{
    internal class Task
    {
        public string TaskID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; } // e.g., "Completed", "Pending"

        public void CreateTask()
        {
            // Implementation to create a new task
            Console.WriteLine($"Task '{Title}' created successfully.");
        }

        public void EditTask(string newTitle, string newDescription)
        {
            Title = newTitle;
            Description = newDescription;
            Console.WriteLine("Task details updated.");
        }

        public void DeleteTask()
        {
            Console.WriteLine($"Task '{Title}' deleted.");
        }
    }
}
