using System;
using System.Collections.Generic;

namespace SyncMate.Models
{
    internal class Event
    {
        public string EventID { get; set; } // 8-character ID
        public string EventName { get; set; }
        private static Dictionary<string, List<Event>> emailEvents = new Dictionary<string, List<Event>>();


        public void ManageEvent(string currentEmail, Dictionary<string, List<Event>> emailEvents)
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine($"=== Manage Events for {currentEmail} ===");
                Console.WriteLine("1. Add Event");
                Console.WriteLine("2. View Events");
                Console.WriteLine("3. Edit Event");
                Console.WriteLine("4. Exit to Main Menu");
                Console.Write("Select an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        AddEvent(currentEmail, emailEvents);
                        break;
                    case "2":
                        ViewEvents(currentEmail, emailEvents);
                        Console.WriteLine("Press any key to return...");
                        Console.ReadKey();
                        break;
                    case "3":
                        EditEvent(currentEmail, emailEvents);
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

        public Event(string eventName)
        {
            EventID = Guid.NewGuid().ToString().Substring(0, 8);
            EventName = eventName;
        }

        // Static method to return all events
        public static List<Event> GetAllEvents()
        {
            List<Event> allEvents = new List<Event>();
            foreach (var events in emailEvents.Values)
            {
                allEvents.AddRange(events);
            }
            return allEvents;
        }

        private void AddEvent(string currentEmail, Dictionary<string, List<Event>> emailEvents)
        {
            Console.Write("Enter event name or 8-character event ID: ");
            string eventNameOrId = Console.ReadLine();
            Event newEvent = CreateEvent(eventNameOrId);

            if (emailEvents.ContainsKey(currentEmail))
            {
                emailEvents[currentEmail].Add(newEvent);
                Console.WriteLine($"Event '{newEvent.EventName}' added with ID {newEvent.EventID} for {currentEmail}.");
            }
            else
            {
                Console.WriteLine("Error: No events found for this email.");
            }
        }

        private void EditEvent(string currentEmail, Dictionary<string, List<Event>> emailEvents)
        {
            Console.Write("Enter event name or 8-character event ID to edit: ");
            string eventNameOrId = Console.ReadLine();

            if (emailEvents.ContainsKey(currentEmail))
            {
                Event eventToEdit = FindEvent(eventNameOrId, emailEvents[currentEmail]);

                if (eventToEdit != null)
                {
                    Console.Write("Enter new event name: ");
                    string newEventName = Console.ReadLine();
                    eventToEdit.EventName = newEventName;
                    Console.WriteLine($"Event '{eventToEdit.EventID}' updated to '{newEventName}'.");
                }
                else
                {
                    Console.WriteLine("Event not found.");
                }
            }
        }

        private void ViewEvents(string currentEmail, Dictionary<string, List<Event>> emailEvents)
        {
            Console.WriteLine($"Events in calendar for {currentEmail}:");
            if (emailEvents.ContainsKey(currentEmail) && emailEvents[currentEmail].Count > 0)
            {
                foreach (var ev in emailEvents[currentEmail])
                {
                    Console.WriteLine($"ID: {ev.EventID}, Name: {ev.EventName}");
                }
            }
            else
            {
                Console.WriteLine("No events available for this email.");
            }
        }

        private Event CreateEvent(string eventNameOrId)
        {
            return (eventNameOrId.Length == 8)
                ? new Event($"Event {eventNameOrId}")
                : new Event(eventNameOrId);
        }

        private Event FindEvent(string eventNameOrId, List<Event> events)
        {
            return (eventNameOrId.Length == 8)
                ? events.Find(e => e.EventID == eventNameOrId)
                : events.Find(e => e.EventName == eventNameOrId);
        }
    }
}
