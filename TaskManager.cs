using System.IO;
using System.Linq;
using System;
using System.Collections.Generic;

namespace CybersecurityChatbot
{
    public class TaskManager
    {
        private void SaveTasks() => File.WriteAllLines(
                "Tasks.txt",
                tasks.Select(t => t.ToString()));
        private List<TaskItem> tasks = new List<TaskItem>();

        public void AddTask(string title, DateTime reminder)
        {
            tasks.Add(new TaskItem
            {
                Title = title,
                ReminderDate = reminder,
                Completed = false
            });

            ActivityLogger.Add("Task added: " + title);
            SaveManager.SaveTasks(tasks);
        }

        public List<TaskItem> GetTasks()
        {
            return tasks;
        }

        public void CompleteTask(int index)
        {
            if (index >= 0 && index < tasks.Count)
            {
                tasks[index].Completed = true;

                ActivityLogger.Add(
                    "Task completed: " +
                    tasks[index].Title);

                SaveManager.SaveTasks(tasks);
            }
        }

        public void DeleteTask(int index)
        {
            if (index >= 0 && index < tasks.Count)
            {
                ActivityLogger.Add(
                    "Task deleted: " +
                    tasks[index].Title);

                tasks.RemoveAt(index);

                SaveManager.SaveTasks(tasks);
            }
        }
    }
}