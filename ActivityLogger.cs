using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Linq;

namespace CybersecurityChatbot
{
    public static class ActivityLogger
    {
        private static List<ActivityLog> logs = new List<ActivityLog>();

        private static void SaveLog()
        {
            File.WriteAllLines(
                "ActivityLog.txt",
                logs.Select(l => l.ToString()));
        }
        public static void Add(string action)
        {
            logs.Add(new ActivityLog
            {
                TimeStamp = DateTime.Now,
                Description = action
            });
        }

        public static List<ActivityLog> GetRecent()
        {
            return logs.TakeLast(10).ToList();
        }
    }

}
