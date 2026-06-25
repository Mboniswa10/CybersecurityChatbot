using System;

namespace CybersecurityChatbot
{
    public class TaskItem
    {
        public string Title { get; set; }

        public DateTime ReminderDate { get; set; }

        public bool Completed { get; set; }

        public override string ToString()
        {
            return $"{Title} - {ReminderDate.ToShortDateString()}";
        }
    }
}