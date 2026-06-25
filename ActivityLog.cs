using System;

namespace CybersecurityChatbot
{
    public class ActivityLog
    {
        public DateTime TimeStamp { get; set; }

        public string Description { get; set; }

        public override string ToString()
        {
            return $"{TimeStamp:G} - {Description}";
        }
    }
}