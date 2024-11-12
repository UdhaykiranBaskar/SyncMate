using System;

namespace SyncMate.Models
{
    internal class Login
    {
        public bool Authenticate(User currentUser)
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
    }
}
