using System;
using SyncMate.Models;
using System.Collections.Generic;

namespace SyncMate
{
    class Program
    {
        static User currentUser = null; // Holds the current logged-in user
        static Calendar userCalendar = null; // Holds the user's calendar
        static Group userGroup = null; // Group Management
        static Notification userNotification = new Notification(); // Notification Management
        static Report reportManager = new Report(); // Report Management

        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== Student Productivity Support System ===");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit");
                Console.Write("Select an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        RegisterUser();
                        break;
                    case "2":
                        if (LoginUser())
                        {
                            MainMenu();
                        }
                        break;
                    case "3":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Press any key to try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void MainMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine($"=== Welcome, {currentUser.Name} ===");
                Console.WriteLine("1. Manage Tasks");
                Console.WriteLine("2. View Profile");
                Console.WriteLine("3. Manage Calendar");
                Console.WriteLine("4. Collaboration");
                Console.WriteLine("5. Manage Notifications");
                Console.WriteLine("6. Generate Reports");
                Console.WriteLine("7. Logout");
                Console.Write("Select an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        ManageTasks();
                        break;
                    case "2":
                        ViewProfile();
                        break;
                    case "3":
                        ManageCalendar();
                        break;
                    case "4":
                        ManageGroups();
                        break;
                    case "5":
                        ManageNotifications();
                        break;
                    case "6":
                        GenerateReports();
                        break;
                    case "7":
                        currentUser.Logout();
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Press any key to try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void ManageTasks()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== Manage Tasks ===");
                Console.WriteLine("1. Create Task");
                Console.WriteLine("2. Edit Task");
                Console.WriteLine("3. Complete Task");
                Console.WriteLine("4. Delete Task");
                Console.WriteLine("5. View All Tasks");
                Console.WriteLine("6. Back to Main Menu");
                Console.Write("Select an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Task.CreateTask();
                        break;
                    case "2":
                        Task.EditTask();
                        break;
                    case "3":
                        Task.CompleteTask();
                        break;
                    case "4":
                        Task.DeleteTask();
                        break;
                    case "5":
                        Task.DisplayAllTasks();
                        Console.WriteLine("Press any key to return...");
                        Console.ReadKey();
                        break;
                    case "6":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Press any key to try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void ManageCalendar()
        {
            if (userCalendar == null)
            {
                // Create a calendar on first access
                userCalendar = new Calendar();
                Console.WriteLine("Connect Calendar! ");
                Console.WriteLine("1. Google");
                Console.WriteLine("2. Outlook");
                string option = Console.ReadLine();

                if (option == "1") userCalendar.CalendarType = "Google";
                else if (option == "2") userCalendar.CalendarType = "Outlook";
                else
                {
                    Console.WriteLine("Invalid selection. Defaulting to Google.");
                    userCalendar.CalendarType = "Google";
                }

                // Connect to the calendar using an email
                Console.Write("Enter email to connect: ");
                string email = Console.ReadLine();
                userCalendar.ConnectCalendar(email);
            }

            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                userCalendar.ShowCurrentEmail(); // Always show the current connected email on top
                Console.WriteLine($"=== Manage Calendar ({userCalendar.CalendarType}) ===");
                Console.WriteLine("1. Add Event");
                Console.WriteLine("2. View Events");
                Console.WriteLine("3. Edit Event");
                Console.WriteLine("4. Back to Main Menu");
                Console.Write("Select an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("Enter event name or 8-character event ID to add: ");
                        string eventNameOrId = Console.ReadLine();
                        userCalendar.AddEvent(eventNameOrId);
                        break;
                    case "2":
                        userCalendar.ViewEvents();
                        Console.WriteLine("Press any key to return...");
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.Write("Enter event name or 8-character event ID to edit: ");
                        string eventIdOrName = Console.ReadLine();
                        userCalendar.EditEvent(eventIdOrName);
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



        static void ManageGroups()
        {
            if (userGroup == null)
            {
                userGroup = new Group();
                Console.WriteLine("Enter Group Name: ");
                userGroup.GroupName = Console.ReadLine();
                userGroup.CreateGroup();
            }

            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== Manage Groups ===");
                Console.WriteLine("1. Add Member");
                Console.WriteLine("2. Remove Member");
                Console.WriteLine("3. View Members");
                Console.WriteLine("4. Back to Main Menu");
                Console.Write("Select an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("Enter member name: ");
                        string memberName = Console.ReadLine();
                        User newUser = new User { Name = memberName };
                        userGroup.AddMember(newUser);
                        break;
                    case "2":
                        Console.Write("Enter member name to remove: ");
                        string memberToRemove = Console.ReadLine();
                        User userToRemove = new User { Name = memberToRemove };
                        userGroup.RemoveMember(userToRemove);
                        break;
                    case "3":
                        foreach (var member in userGroup.Members)
                        {
                            Console.WriteLine($"Member: {member.Name}");
                        }
                        Console.WriteLine("Press any key to return...");
                        Console.ReadKey();
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

        static void ManageNotifications()
        {
            Console.Clear();
            Console.WriteLine("=== Manage Notifications ===");
            Console.WriteLine("1. Send Notification");
            Console.WriteLine("2. Schedule Notification");
            Console.WriteLine("3. Back to Main Menu");
            Console.Write("Select an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("Enter notification content: ");
                    userNotification.Content = Console.ReadLine();
                    userNotification.SendNotification();
                    break;
                case "2":
                    Console.Write("Enter notification content: ");
                    userNotification.Content = Console.ReadLine();
                    Console.Write("Enter reminder date (MM/DD/YYYY): ");
                    DateTime reminderDate = DateTime.Parse(Console.ReadLine());
                    userNotification.ScheduleNotification(reminderDate);
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid option. Press any key to try again.");
                    Console.ReadKey();
                    break;
            }
        }

        static void GenerateReports()
        {
            Console.Clear();
            Console.WriteLine("=== Generate Reports ===");
            Console.WriteLine("1. Generate Task Report");
            Console.WriteLine("2. Generate Group Performance Report");
            Console.WriteLine("3. Back to Main Menu");
            Console.Write("Select an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    reportManager.GenerateTaskReport();
                    break;
                case "2":
                    reportManager.GenerateGroupPerformanceReport();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid option. Press any key to try again.");
                    Console.ReadKey();
                    break;
            }
        }

        static void RegisterUser()
        {
            Console.Clear();
            Console.WriteLine("=== Register ===");
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.Write("Enter your email: ");
            string email = Console.ReadLine();
            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            currentUser = new User()
            {
                Name = name,
                Email = email,
                Password = password,
                Role = "Student"
            };

            Console.WriteLine("Registration successful! Press any key to continue...");
            Console.ReadKey();
        }

        static bool LoginUser()
        {
            Console.Clear();
            Console.WriteLine("=== Login ===");
            Console.Write("Enter your email: ");
            string email = Console.ReadLine();
            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            if (currentUser != null && currentUser.Login(email, password))
            {
                return true;
            }
            Console.WriteLine("Login failed. Press any key to try again.");
            Console.ReadKey();
            return false;
        }

        static void ViewProfile()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== View and Edit Profile ===");
                Console.WriteLine($"Name: {currentUser.Name}");
                Console.WriteLine($"Email: {currentUser.Email}");
                Console.WriteLine($"Role: {currentUser.Role}");
                Console.WriteLine();
                Console.WriteLine("1. Edit Name");
                Console.WriteLine("2. Edit Email");
                Console.WriteLine("3. Reset Password");
                Console.WriteLine("4. Back to Main Menu");
                Console.Write("Select an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        EditUserName();
                        break;
                    case "2":
                        EditUserEmail();
                        break;
                    case "3":
                        ResetUserPassword();
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

        static void EditUserName()
        {
            Console.Write("Enter new name: ");
            string newName = Console.ReadLine();
            currentUser.UpdateProfile(newName);
            Console.WriteLine("Name updated successfully. Press any key to return.");
            Console.ReadKey();
        }

        static void EditUserEmail()
        {
            Console.Write("Enter new email: ");
            string newEmail = Console.ReadLine();
            currentUser.Email = newEmail;
            Console.WriteLine("Email updated successfully. Press any key to return.");
            Console.ReadKey();
        }

        static void ResetUserPassword()
        {
            Console.Write("Enter new password: ");
            string newPassword = Console.ReadLine();
            currentUser.ResetPassword(newPassword);
            Console.WriteLine("Password reset successfully. Press any key to return.");
            Console.ReadKey();
        }

    }
}
