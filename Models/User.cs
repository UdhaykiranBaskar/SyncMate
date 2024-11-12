using System;

namespace SyncMate.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } // e.g., Student, Faculty, Staff

        public bool Login(string email, string password)
        {
            if (email == Email && password == Password)
            {
                Console.WriteLine($"Welcome, {Name}!");
                return true;
            }
            Console.WriteLine("Invalid login credentials.");
            return false;
        }

        public void Logout()
        {
            Console.WriteLine($"{Name} has logged out.");
        }

        public void ResetPassword(string newPassword)
        {
            Password = newPassword;
            Console.WriteLine("Password has been reset successfully.");
        }

        public void UpdateProfile(string newName)
        {
            Name = newName;
            Console.WriteLine("Profile updated successfully.");
        }
    }
}