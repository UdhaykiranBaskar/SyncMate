using System;
using System.Collections.Generic;

namespace SyncMate.Models
{
    internal class Calendar
    {
        public string CalendarID { get; set; }
        public string CalendarType { get; set; } // e.g., "Google", "Outlook"
        public List<string> Emails { get; set; } = new List<string>(); // List to store connected emails
        public string CurrentEmail { get; private set; } // The currently active email

        // Dictionary to track events per email
        public Dictionary<string, List<Event>> EmailEvents { get; set; } = new Dictionary<string, List<Event>>();

        public void ConnectCalendar(string email)
        {
            if (!Emails.Contains(email))
            {
                Emails.Add(email);
                EmailEvents[email] = new List<Event>(); // Initialize event list for the new email
            }
            CurrentEmail = email;
            Console.WriteLine($"Connected to {CalendarType} calendar with {email}.");
        }

        // Show currently connected email at the top
        public void ShowCurrentEmail()
        {
            Console.WriteLine($"Currently connected email: {CurrentEmail}");
        }

        public void AddEvent(string eventNameOrId)
        {
            Event newEvent;
            if (eventNameOrId.Length == 8) // If the input is 8 characters, assume it's an ID
            {
                newEvent = new Event
                {
                    EventID = eventNameOrId,
                    EventName = $"Event {eventNameOrId}"
                };
            }
            else
            {
                newEvent = new Event
                {
                    EventID = Guid.NewGuid().ToString().Substring(0, 8), // Generate 8-character ID
                    EventName = eventNameOrId
                };
            }

            if (EmailEvents.ContainsKey(CurrentEmail))
            {
                EmailEvents[CurrentEmail].Add(newEvent);
                Console.WriteLine($"Event '{newEvent.EventName}' added with ID {newEvent.EventID} for {CurrentEmail}.");
                SendNotification(newEvent);
            }
            else
            {
                Console.WriteLine("Error: No events found for this email.");
            }
        }

        public void EditEvent(string eventNameOrId)
        {
            if (EmailEvents.ContainsKey(CurrentEmail))
            {
                Event eventToEdit;
                if (eventNameOrId.Length == 8) // Search by ID if 8 characters
                {
                    eventToEdit = EmailEvents[CurrentEmail].Find(e => e.EventID == eventNameOrId);
                }
                else // Otherwise, search by name
                {
                    eventToEdit = EmailEvents[CurrentEmail].Find(e => e.EventName == eventNameOrId);
                }

                if (eventToEdit != null)
                {
                    Console.Write("Enter new event name: ");
                    string newEventName = Console.ReadLine();
                    eventToEdit.EventName = newEventName;
                    Console.WriteLine($"Event '{eventToEdit.EventID}' updated to '{newEventName}'.");
                    SendNotification(eventToEdit); // Send a notification for the updated event
                }
                else
                {
                    Console.WriteLine("Event not found.");
                }
            }
            else
            {
                Console.WriteLine("No events found for this email.");
            }
        }

        public void ViewEvents()
        {
            Console.WriteLine($"Events in {CalendarType} calendar for {CurrentEmail}:");
            if (EmailEvents.ContainsKey(CurrentEmail) && EmailEvents[CurrentEmail].Count > 0)
            {
                foreach (var ev in EmailEvents[CurrentEmail])
                {
                    Console.WriteLine($"ID: {ev.EventID}, Name: {ev.EventName}");
                }
            }
            else
            {
                Console.WriteLine("No events available for this email.");
            }
        }

        private void SendNotification(Event calendarEvent)
        {
            Console.Write("Would you like to send a notification for this event? (y/n): ");
            string sendNotification = Console.ReadLine();
            if (sendNotification.ToLower() == "y")
            {
                Notification notification = new Notification
                {
                    Content = $"Notification: Event '{calendarEvent.EventName}' (ID: {calendarEvent.EventID}) has been added/updated.",
                    SendDate = DateTime.Now
                };
                notification.SendNotification();
            }
        }
    }

    internal class Event
    {
        public string EventID { get; set; } // 8-character ID
        public string EventName { get; set; }
    }
}
