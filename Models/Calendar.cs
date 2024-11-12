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

        // Connect or switch calendar email
        public void ConnectCalendar(string email, string calendarType)
        {
            CalendarType = calendarType;
            if (!Emails.Contains(email))
            {
                Emails.Add(email);
                EmailEvents[email] = new List<Event>(); // Initialize event list for the new email
            }
            CurrentEmail = email;
            Console.WriteLine($"Connected to {CalendarType} calendar with {email}.");
        }

        // Show currently connected email
        public void ShowCurrentEmail()
        {
            Console.WriteLine($"Currently connected email: {CurrentEmail}");
        }

        public void TriggerEventActions()
        {
            // Create or show the event actions for the current calendar
            Event eventActions = new Event("DefaultEventName"); // Provide a default event name
            eventActions.ManageEvent(CurrentEmail, EmailEvents);
        }
    }
}
