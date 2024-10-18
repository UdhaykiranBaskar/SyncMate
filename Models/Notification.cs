using System;

namespace SyncMate.Models
{
    internal class Notification
    {
        public string NotificationID { get; set; }
        public string Content { get; set; }
        public DateTime SendDate { get; set; }
        public string Type { get; set; } // e.g., "Reminder"

        public void SendNotification()
        {
            Console.WriteLine($"Notification sent: {Content}");
        }

        public void ScheduleNotification(DateTime reminderDate)
        {
            SendDate = reminderDate;
            Console.WriteLine($"Notification scheduled for {SendDate}");
        }
    }
}
