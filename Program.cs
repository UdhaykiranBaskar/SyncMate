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
        static Profile userProfile = null; // User profile for managing user details and calendar

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
                Console.WriteLine("3. Manage Events");
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
                        userProfile.ViewProfile(); // Display profile with calendar management
                        break;
                    case "3":
                        ManageEvents();
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


        static void ManageEvents()
        {
            if (userProfile.UserCalendar.CurrentEmail == null)
            {
                Console.WriteLine("No calendar connected. Please connect a calendar.");
                userProfile.ConnectCalendar();
            }
            else
            {
                userProfile.UserCalendar.TriggerEventActions();
            }
        }

        static void ManageGroups()
        {
           

            // Call ManageGroup() in Group.cs

            Group.ManageCollaboration();
        }


        static void ManageNotifications()
        {
            // Call ManageNotifications() in Notification.cs
            userNotification.ManageNotifications();
        }


        static void GenerateReports()
        {
            // Call ManageReports() in Report.cs
            reportManager.ManageReports();
        }


        static void RegisterUser()
        {
            Register register = new Register();
            currentUser = register.RegisterNewUser();
            userProfile = new Profile(currentUser.Name, currentUser.Email);
        }

        static bool LoginUser()
        {
            Login login = new Login();
            return login.Authenticate(currentUser);
        }
    }
}
