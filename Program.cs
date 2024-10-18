using System;
using SyncMate.Models;

namespace SyncMate
{
    class Program
    {
        static User currentUser = null; // Holds the current logged-in user

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
                Console.WriteLine("2. Create Group");
                Console.WriteLine("3. View Profile");
                Console.WriteLine("4. Logout");
                Console.Write("Select an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        ManageTasks();
                        break;
                    case "2":
                        CreateGroup();
                        break;
                    case "3":
                        ViewProfile();
                        break;
                    case "4":
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

        static void ManageTasks()
        {
            Console.Clear();
            Console.WriteLine("=== Manage Tasks ===");
            // Implement task management logic here
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }

        static void CreateGroup()
        {
            Console.Clear();
            Console.WriteLine("=== Create Group ===");
            // Implement group creation logic here
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }

        static void ViewProfile()
        {
            Console.Clear();
            Console.WriteLine("=== View Profile ===");
            // Display user profile details
            Console.WriteLine($"Name: {currentUser.Name}");
            Console.WriteLine($"Email: {currentUser.Email}");
            Console.WriteLine($"Role: {currentUser.Role}");
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }
    }
}
