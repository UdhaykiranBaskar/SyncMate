using System;

namespace SyncMate.Models
{
    internal class Email
    {
        public string EmailID { get; set; }
        public string EmailType { get; set; } // e.g., "Gmail", "Outlook"
        public bool ConnectedStatus { get; set; }

        public void ConnectEmail()
        {
            ConnectedStatus = true;
            Console.WriteLine($"{EmailType} connected successfully.");
        }

        public void SyncEmails()
        {
            Console.WriteLine("Emails synchronized.");
        }
    }
}
