using System;

namespace SyncMate.Models
{
    internal class Profile
    {
        public string ProfileID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string ContactInfo { get; set; }

        public void EditProfile(string newUserName, string newEmail)
        {
            UserName = newUserName;
            Email = newEmail;
            Console.WriteLine("Profile updated successfully.");
        }

        public void ViewProfile()
        {
            Console.WriteLine($"Profile - Name: {UserName}, Email: {Email}");
        }
    }
}
