using System.Collections.Generic;
using System.IO;

namespace CybersecurityChatbot
{
    public static class SaveManager
    {
        public static void SaveTasks(List<TaskItem> tasks)
        {
            List<string> lines = new List<string>();

            foreach (TaskItem task in tasks)
            {
                lines.Add(
                    task.Title + "|" +
                    task.ReminderDate.ToShortDateString() + "|" +
                    task.Completed);
            }

            File.WriteAllLines("tasks.txt", lines);
        }
    }
}