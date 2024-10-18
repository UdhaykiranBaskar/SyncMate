using System;
using System.Collections.Generic;

namespace SyncMate.Models
{
    internal class Group
    {
        public string GroupID { get; set; }
        public string GroupName { get; set; }
        public List<User> Members { get; set; } = new List<User>();

        public void CreateGroup()
        {
            Console.WriteLine($"Group '{GroupName}' created successfully.");
        }

        public void AddMember(User user)
        {
            Members.Add(user);
            Console.WriteLine($"User '{user.Name}' added to group '{GroupName}'.");
        }

        public void RemoveMember(User user)
        {
            Members.Remove(user);
            Console.WriteLine($"User '{user.Name}' removed from group '{GroupName}'.");
        }
    }
}
