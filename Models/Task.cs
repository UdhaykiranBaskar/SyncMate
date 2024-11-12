using System;
using System.Collections.Generic;

namespace SyncMate.Models
{
    internal class Task
    {
        public string TaskID { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime DueDate { get; private set; }
        public string Priority { get; private set; }
        public string Status { get; private set; } // e.g., "Completed", "Pending"

        private static List<Task> taskList = new List<Task>(); // List to store tasks

        public Task(string title, string description, DateTime dueDate, string priority = "Medium")
        {
            TaskID = Guid.NewGuid().ToString().Substring(0, 8); // Shortened TaskID
            Title = title;
            Description = description;
            DueDate = dueDate;
            Priority = string.IsNullOrEmpty(priority) ? "Medium" : priority; // Set default to Medium if priority is not provided
            Status = "Pending"; // Default status when task is created
        }

        // Static method to return all tasks
        public static List<Task> GetAllTasks()
        {
            return taskList;
        }

        // Static method to create a task
        public static void CreateTask()
        {
            Console.Clear();
            Console.WriteLine("=== Create Task ===");
            Console.WriteLine("Type 'back' at any point to return to the previous menu.");
            Console.Write("Enter task title: ");
            string title = Console.ReadLine();
            if (title.ToLower() == "back") return;

            Console.Write("Enter task description: ");
            string description = Console.ReadLine();
            if (description.ToLower() == "back") return;

            DateTime dueDate = GetValidFutureDate("Enter due date (MM/DD/YYYY): ");
            if (dueDate == DateTime.MinValue) return; // Check if the user typed 'back'

            Console.Write("Enter priority (High/Medium/Low) [default: Medium]: ");
            string priority = Console.ReadLine();
            if (priority.ToLower() == "back") return;

            Task newTask = new Task(title, description, dueDate, priority);
            taskList.Add(newTask); // Add the new task to the list
            Console.WriteLine($"Task '{title}' created successfully!");
        }

        // Static method to edit a task
        public static void EditTask()
        {
            Console.Clear();
            Console.WriteLine("=== Edit Task ===");
            DisplayAllTasks(); // Show all tasks

            Console.WriteLine("Type 'back' at any point to return to the previous menu.");
            Console.Write("Enter the task ID or name you want to edit: ");
            string taskIdentifier = Console.ReadLine();
            if (taskIdentifier.ToLower() == "back") return;

            Task taskToEdit;

            // Check if input is a valid task ID (8 characters) or a task name
            if (taskIdentifier.Length == 8 && taskList.Exists(t => t.TaskID == taskIdentifier))
            {
                taskToEdit = taskList.Find(t => t.TaskID == taskIdentifier);
            }
            else
            {
                taskToEdit = taskList.Find(t => t.Title.Equals(taskIdentifier, StringComparison.OrdinalIgnoreCase));
            }

            if (taskToEdit != null)
            {
                Console.Write("Enter new task title: ");
                string newTitle = Console.ReadLine();
                if (newTitle.ToLower() == "back") return;

                Console.Write("Enter new task description: ");
                string newDescription = Console.ReadLine();
                if (newDescription.ToLower() == "back") return;

                DateTime newDueDate = GetValidFutureDate("Enter new due date (MM/DD/YYYY): ");
                if (newDueDate == DateTime.MinValue) return; // Check if the user typed 'back'

                Console.Write("Enter new priority (High/Medium/Low) [default: Medium]: ");
                string newPriority = Console.ReadLine();
                if (newPriority.ToLower() == "back") return;

                taskToEdit.Title = newTitle;
                taskToEdit.Description = newDescription;
                taskToEdit.DueDate = newDueDate;
                taskToEdit.Priority = string.IsNullOrEmpty(newPriority) ? "Medium" : newPriority;

                Console.WriteLine("Task updated successfully!");
            }
            else
            {
                Console.WriteLine("Task not found.");
            }
        }

        // Static method to mark a task as complete
        public static void CompleteTask()
        {
            Console.Clear();
            Console.WriteLine("=== Complete Task ===");
            DisplayAllTasks(); // Show all tasks for reference

            Console.WriteLine("Type 'back' at any point to return to the previous menu.");
            Console.Write("Enter the task ID or name you want to mark as completed: ");
            string taskIdentifier = Console.ReadLine();
            if (taskIdentifier.ToLower() == "back") return;

            Task taskToComplete;

            // Check if the input is a valid task ID (8 characters) or a task name
            if (taskIdentifier.Length == 8 && taskList.Exists(t => t.TaskID == taskIdentifier))
            {
                taskToComplete = taskList.Find(t => t.TaskID == taskIdentifier);
            }
            else
            {
                taskToComplete = taskList.Find(t => t.Title.Equals(taskIdentifier, StringComparison.OrdinalIgnoreCase));
            }

            if (taskToComplete != null)
            {
                if (taskToComplete.Status == "Completed")
                {
                    Console.WriteLine($"Task '{taskToComplete.Title}' is already marked as completed.");
                }
                else
                {
                    taskToComplete.Status = "Completed";
                    Console.WriteLine($"Task '{taskToComplete.Title}' has been marked as completed.");
                }
            }
            else
            {
                Console.WriteLine("Task not found.");
            }
        }

        // Static method to display all tasks, showing updated completion status
        public static void DisplayAllTasks()
        {
            if (taskList.Count == 0)
            {
                Console.WriteLine("No tasks available.");
            }
            else
            {
                Console.WriteLine("=== Task List ===");
                foreach (var task in taskList)
                {
                    task.DisplayTaskDetails();
                    Console.WriteLine(); // Empty line between tasks
                }
            }
        }

        // Display details of a single task with updated status
        public void DisplayTaskDetails()
        {
            Console.WriteLine($"Task ID: {TaskID}");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Due Date: {DueDate.ToShortDateString()}");
            Console.WriteLine($"Priority: {Priority}");
            Console.WriteLine($"Status: {Status}");
        }



        // Static method to delete a task
        public static void DeleteTask()
        {
            Console.Clear();
            Console.WriteLine("=== Delete Task ===");
            DisplayAllTasks(); // Show all tasks

            Console.WriteLine("Type 'back' at any point to return to the previous menu.");
            Console.Write("Enter the task ID you want to delete: ");
            string taskId = Console.ReadLine();
            if (taskId.ToLower() == "back") return;

            Task taskToDelete = taskList.Find(t => t.TaskID == taskId);
            if (taskToDelete != null)
            {
                taskList.Remove(taskToDelete); // Fix: remove task from list properly
                Console.WriteLine($"Task '{taskToDelete.Title}' deleted.");
            }
            else
            {
                Console.WriteLine("Task not found.");
            }
        }

    

       

        // Method to get a valid future date input from the user
        private static DateTime GetValidFutureDate(string prompt)
        {
            DateTime dateValue;
            Console.Write(prompt);

            while (true)
            {
                string input = Console.ReadLine();
                if (input.ToLower() == "back") return DateTime.MinValue;

                if (DateTime.TryParse(input, out dateValue) && dateValue > DateTime.Now)
                {
                    return dateValue;
                }

                Console.WriteLine("Invalid date. Please try again or type 'back' to return.");
                Console.Write(prompt);
            }
        }
    }
}
