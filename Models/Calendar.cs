using System;
using System.Collections.Generic;

namespace SyncMate.Models
{
    internal class Calendar
    {
        public string CalendarID { get; set; }
        public string CalendarType { get; set; } // e.g., "Google", "Outlook"
        public List<string> Events { get; set; } = new List<string>();

        public void ConnectCalendar()
        {
            Console.WriteLine($"Connected to {CalendarType} calendar.");
        }

        public void SyncEvents()
        {
            Console.WriteLine("Calendar events synchronized.");
        }
    }
}
