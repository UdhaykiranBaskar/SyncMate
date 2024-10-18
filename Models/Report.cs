using System;

namespace SyncMate.Models
{
    internal class Report
    {
        public string ReportID { get; set; }
        public string ReportType { get; set; } // e.g., "Task", "Group Performance"
        public DateTime GeneratedDate { get; set; }
        public string Data { get; set; } // Store report data in a string for simplicity

        public void GenerateTaskReport()
        {
            Console.WriteLine("Generating task report...");
        }

        public void GenerateGroupPerformanceReport()
        {
            Console.WriteLine("Generating group performance report...");
        }
    }
}
