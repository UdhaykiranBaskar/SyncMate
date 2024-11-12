using System;
using System.Collections.Generic;

namespace SyncMate.Models
{
    internal class Group
    {
        public string GroupID { get; set; }
        public string GroupName { get; set; }
        public List<User> Members { get; set; } = new List<User>();

        private static List<Group> groups = new List<Group>();

        public static void ManageCollaboration()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== Collaboration Menu ===");
                Console.WriteLine("1. Create Group");
                Console.WriteLine("2. Edit Group");
                Console.WriteLine("3. Delete Group");
                Console.WriteLine("4. View All Groups");
                Console.WriteLine("5. Manage Group");
                Console.WriteLine("6. Back to Main Menu");
                Console.Write("Select an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        CreateGroup();
                        break;
                    case "2":
                        EditGroup();
                        break;
                    case "3":
                        DeleteGroup();
                        break;
                    case "4":
                        ViewAllGroups();
                        Console.WriteLine("Press any key to return...");
                        Console.ReadKey();
                        break;
                    case "5":
                        ManageGroup();
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

        private static void CreateGroup()
        {
            Console.Write("Enter Group Name: ");
            string groupName = Console.ReadLine();
            Group newGroup = new Group { GroupName = groupName };
            groups.Add(newGroup);
            Console.WriteLine($"Group '{groupName}' created successfully.");
            Console.ReadKey();
        }

        private static void EditGroup()
        {
            Console.Write("Enter group name to edit: ");
            string groupName = Console.ReadLine();
            Group group = groups.Find(g => g.GroupName == groupName);

            if (group != null)
            {
                Console.Write("Enter new group name: ");
                group.GroupName = Console.ReadLine();
                Console.WriteLine($"Group name changed to '{group.GroupName}'.");
            }
            else
            {
                Console.WriteLine("Group not found.");
            }
            Console.ReadKey();
        }

        private static void DeleteGroup()
        {
            Console.Write("Enter group name to delete: ");
            string groupName = Console.ReadLine();
            Group group = groups.Find(g => g.GroupName == groupName);

            if (group != null)
            {
                groups.Remove(group);
                Console.WriteLine("Group deleted successfully.");
            }
            else
            {
                Console.WriteLine("Group not found.");
            }
            Console.ReadKey();
        }

        private static void ViewAllGroups()
        {
            Console.WriteLine("=== All Groups ===");
            if (groups.Count > 0)
            {
                foreach (var group in groups)
                {
                    Console.WriteLine($"- {group.GroupName}");
                }
            }
            else
            {
                Console.WriteLine("No groups available.");
            }
        }

        private static void ManageGroup()
        {
            Console.WriteLine("Available Groups:");
            foreach (var group in groups)
            {
                Console.WriteLine($"- {group.GroupName}");
            }

            Console.Write("Enter the group name to manage: ");
            string groupName = Console.ReadLine();
            Group selectedGroup = groups.Find(g => g.GroupName == groupName);

            if (selectedGroup != null)
            {
                selectedGroup.ManageMembers();
            }
            else
            {
                Console.WriteLine("Group not found.");
                Console.ReadKey();
            }
        }

        private void ManageMembers()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine($"=== Manage Members for Group: {GroupName} ===");
                DisplayMembers(); // Show current members before each action
                Console.WriteLine("1. Add Member by ID or Email");
                Console.WriteLine("2. Remove Member by ID or Email");
                Console.WriteLine("3. Back to Group Menu");
                Console.Write("Select an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        AddMemberPrompt();
                        break;
                    case "2":
                        RemoveMemberPrompt();
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

        private void AddMemberPrompt()
        {
            Console.Write("Enter member ID or email to add: ");
            string memberIdentifier = Console.ReadLine();
            if (Members.Exists(m => m.Name == memberIdentifier))
            {
                Console.WriteLine("Member already exists in this group.");
            }
            else
            {
                AddMember(new User { Name = memberIdentifier });
                Console.WriteLine($"User '{memberIdentifier}' added to group '{GroupName}'.");
            }
            DisplayMembers(); // Show updated member list after adding
            Console.ReadKey();
        }

        private void RemoveMemberPrompt()
        {
            Console.Write("Enter member ID or email to remove: ");
            string memberToRemove = Console.ReadLine();
            User userToRemove = Members.Find(m => m.Name == memberToRemove);

            if (userToRemove != null)
            {
                RemoveMember(userToRemove);
                Console.WriteLine($"User '{memberToRemove}' removed from group '{GroupName}'.");
            }
            else
            {
                Console.WriteLine("Member not found.");
            }
            DisplayMembers(); // Show updated member list after removal
            Console.ReadKey();
        }

        private void DisplayMembers()
        {
            Console.WriteLine("Current Members:");
            if (Members.Count > 0)
            {
                foreach (var member in Members)
                {
                    Console.WriteLine($"- {member.Name}");
                }
            }
            else
            {
                Console.WriteLine("No members in this group.");
            }
            Console.WriteLine();
        }

        private void AddMember(User user)
        {
            Members.Add(user);
        }

        private void RemoveMember(User user)
        {
            Members.Remove(user);
        }
    }
}
