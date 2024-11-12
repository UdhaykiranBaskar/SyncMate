using System;
using System.Collections.Generic;

namespace SyncMate.Models
{
    internal class Notification
    {
        public string NotificationID { get; set; }
        public string Content { get; set; }
        public DateTime SendDate { get; set; }
        public string Type { get; set; } // e.g., "Reminder", "Event", "Task"
        public string TargetID { get; set; } // ID of the event or task related to this notification

        private static List<Notification> notifications = new List<Notification>(); // Stores all notifications

        public void SendNotification()
        {
            Console.WriteLine($"Notification sent: {Content}");
            notifications.Add(this);
        }

        public void ScheduleNotification(DateTime reminderDate)
        {
            SendDate = reminderDate;
            Console.WriteLine($"Notification scheduled for {SendDate}");
            notifications.Add(this);
        }

        // Method to manage notifications (for tasks and events)
        public void ManageNotifications()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== Manage Notifications ===");
                Console.WriteLine("1. View All Tasks and Set Task Notification");
                Console.WriteLine("2. View All Events and Set Event Notification");
                Console.WriteLine("3. View All Notifications");
                Console.WriteLine("4. Back to Main Menu");
                Console.Write("Select an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        SetNotificationForTask();
                        break;
                    case "2":
                        SetNotificationForEvent();
                        break;
                    case "3":
                        ViewAllNotifications();
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Press any key to try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        // List tasks and allow user to set a notification for a selected task
        private void SetNotificationForTask()
        {
            Console.Clear();
            Console.WriteLine("=== List of Tasks ===");
            List<Task> tasks = Task.GetAllTasks(); // Retrieve all tasks (assuming a static method in Task class)

            if (tasks.Count > 0)
            {
                for (int i = 0; i < tasks.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {tasks[i].Title} (Due: {tasks[i].DueDate.ToShortDateString()})");
                }

                Console.Write("Select a task number to set a notification: ");
                if (int.TryParse(Console.ReadLine(), out int taskIndex) && taskIndex > 0 && taskIndex <= tasks.Count)
                {
                    Task selectedTask = tasks[taskIndex - 1];
                    CustomizeNotification("Task", selectedTask.TaskID);
                }
                else
                {
                    Console.WriteLine("Invalid selection.");
                }
            }
            else
            {
                Console.WriteLine("No tasks available.");
            }
            Console.WriteLine("Press any key to return...");
            Console.ReadKey();
        }

        // List events and allow user to set a notification for a selected event
        private void SetNotificationForEvent()
        {
            Console.Clear();
            Console.WriteLine("=== List of Events ===");
            List<Event> events = Event.GetAllEvents(); // Retrieve all events (assuming a static method in Event class)

            if (events.Count > 0)
            {
                for (int i = 0; i < events.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {events[i].EventName}");
                }

                Console.Write("Select an event number to set a notification: ");
                if (int.TryParse(Console.ReadLine(), out int eventIndex) && eventIndex > 0 && eventIndex <= events.Count)
                {
                    Event selectedEvent = events[eventIndex - 1];
                    CustomizeNotification("Event", selectedEvent.EventID);
                }
                else
                {
                    Console.WriteLine("Invalid selection.");
                }
            }
            else
            {
                Console.WriteLine("No events available.");
            }
            Console.WriteLine("Press any key to return...");
            Console.ReadKey();
        }

        // Set or customize a notification for a specific target (event or task)
        private void CustomizeNotification(string type, string targetID)
        {
            Console.Write($"Enter custom notification content for the {type}: ");
            string customContent = Console.ReadLine();
            Console.Write("Enter reminder date (MM/DD/YYYY): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime reminderDate))
            {
                Notification notification = new Notification
                {
                    NotificationID = Guid.NewGuid().ToString(),
                    Content = customContent,
                    SendDate = reminderDate,
                    Type = type,
                    TargetID = targetID
                };
                notifications.Add(notification);
                Console.WriteLine($"{type} notification scheduled for {reminderDate}.");
            }
            else
            {
                Console.WriteLine("Invalid date format.");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        // Method to view all notifications
        private void ViewAllNotifications()
        {
            Console.Clear();
            Console.WriteLine("=== All Notifications ===");
            if (notifications.Count > 0)
            {
                foreach (var notification in notifications)
                {
                    Console.WriteLine($"ID: {notification.NotificationID}, Type: {notification.Type}, Content: {notification.Content}, Send Date: {notification.SendDate}, Target ID: {notification.TargetID}");
                }
            }
            else
            {
                Console.WriteLine("No notifications available.");
            }
            Console.WriteLine("Press any key to return...");
            Console.ReadKey();
        }
    }
}
