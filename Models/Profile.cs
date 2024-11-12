using System;

namespace SyncMate.Models
{
    internal class Profile
    {
        public string ProfileID { get; set; }
        public string UserName { get; private set; } // Registered user name
        public string Email { get; private set; } // Registered email
        public Calendar UserCalendar { get; set; } = new Calendar(); // Initialize calendar instance

        // Constructor to initialize Profile with registered name and email
        public Profile(string userName, string email)
        {
            UserName = userName;
            Email = email;
        }

        public void ViewProfile()
        {
            Console.Clear();
            Console.WriteLine($"=== Profile: {UserName} ===");
            Console.WriteLine($"Email: {Email}");

            // Display calendar connection status
            if (UserCalendar.CurrentEmail == null)
            {
                Console.WriteLine("No calendar connected.");
            }
            else
            {
                Console.WriteLine($"Connected Calendar Email: {UserCalendar.CurrentEmail}");
            }

            Console.WriteLine("\nOptions:");
            Console.WriteLine("1. Edit Name");
            Console.WriteLine("2. Edit Email");
            Console.WriteLine("3. Connect/Change Calendar for events");
            Console.WriteLine("4. Back to Main Menu");
            Console.Write("Select an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    EditName();
                    break;
                case "2":
                    EditEmail();
                    break;
                case "3":
                    ConnectCalendar();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid option. Press any key to return.");
                    Console.ReadKey();
                    break;
            }
        }

        public void EditName()
        {
            Console.Write("Enter new name: ");
            UserName = Console.ReadLine();
            Console.WriteLine("Name updated successfully. Press any key to return.");
            Console.ReadKey();
        }

        public void EditEmail()
        {
            Console.Write("Enter new email: ");
            Email = Console.ReadLine();
            Console.WriteLine("Email updated successfully. Press any key to return.");
            Console.ReadKey();
        }

        // Method to connect the calendar
        public void ConnectCalendar()
        {
            Console.WriteLine("Select Calendar Type:\n1. Google\n2. Outlook");
            string option = Console.ReadLine();
            string calendarType = option == "1" ? "Google" : "Outlook";

            Console.Write("Enter email to connect to the calendar: ");
            string email = Console.ReadLine();

            UserCalendar.ConnectCalendar(email, calendarType);
            Console.WriteLine($"Calendar connected to {email}. Press any key to return.");
            Console.ReadKey();
        }
    }
}
