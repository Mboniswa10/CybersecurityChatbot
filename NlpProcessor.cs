namespace CybersecurityChatbot
{
    public class NlpProcessor
    {
        public string DetectIntent(string input)
        {
            input = input.ToLower();

            // ADD TASK
            if (input.Contains("add task") ||
                input.Contains("create task") ||
                input.Contains("new task") ||
                input.Contains("remind me") ||
                input.Contains("set reminder"))
            {
                return "ADD_TASK";
            }

            // SHOW TASKS
            if (input.Contains("show tasks") ||
                input.Contains("show my tasks") ||
                input.Contains("view tasks") ||
                input.Contains("display tasks"))
            {
                return "SHOW_TASKS";
            }

            // START QUIZ
            if (input.Contains("start quiz") ||
                input.Contains("begin quiz") ||
                input.Contains("quiz"))
            {
                return "START_QUIZ";
            }
            if (input.Contains("restart quiz"))
            {
                return "RESTART_QUIZ";
            }

            // SHOW ACTIVITY LOG
            if (input.Contains("show activity log") ||
                input.Contains("activity log") ||
                input.Contains("show log") ||
                input.Contains("recent activity"))
            {
                return "SHOW_LOG";
            }

            if (input.Contains("complete task"))
            {
                return "COMPLETE_TASK";
            }

            if (input.Contains("delete task"))
            {
                return "DELETE_TASK";
            }
            return "UNKNOWN";
        }
    }
}