using System;

namespace SyncMate.Models
{
    internal class Register
    {
        public User RegisterNewUser()
        {
            Console.Clear();
            Console.WriteLine("=== Register ===");
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.Write("Enter your email: ");
            string email = Console.ReadLine();
            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            User newUser = new User
            {
                Name = name,
                Email = email,
                Password = password,
                Role = "Student"
            };

            Console.WriteLine("Registration successful! Press any key to continue...");
            Console.ReadKey();
            return newUser;
        }
    }
}
