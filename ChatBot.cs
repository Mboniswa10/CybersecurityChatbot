using System;
using System.Collections.Generic;

namespace CybersecurityChatbot
{
    public class ChatBot
    {
        private KeywordResponder _keywords;
        private SentimentDetector _sentiment;
        private MemoryStore _memory;

        private TaskManager _taskManager;
        private QuizManager _quizManager;
        private NlpProcessor _nlpProcessor;

        private bool _quizRunning = false;
        private bool _awaitingName = true;
        private bool _awaitingStudentNumber = false;

        private Random _random = new Random();

        public ChatBot()
        {
            _keywords = new KeywordResponder();
            _sentiment = new SentimentDetector();
            _memory = new MemoryStore();

            _taskManager = new TaskManager();
            _quizManager = new QuizManager();
            _nlpProcessor = new NlpProcessor();
        }

        public string GetGreeting()
        {
            return
                "WELCOME TO MY CYBERSECURITY AWARENESS ASSISTANT\n\n" +
                "Please enter your NAME:";
        }

        public string ProcessInput(string input)
        {
            input = input.Trim();

            if (_awaitingName)
            {
                _memory.UserName = input;
                _memory.Store("name", input);

                _awaitingName = false;
                _awaitingStudentNumber = true;

                return
                    $"Hello {_memory.UserName}!\n\n" +
                    "Please enter your STUDENT NUMBER:";
            }

            if (_awaitingStudentNumber)
            {
                _memory.StudentNumber = input;
                _memory.Store("student", input);

                _awaitingStudentNumber = false;

                return
                    $"Welcome {_memory.UserName} ({_memory.StudentNumber})!\n\n" +
                    "You may now ask me ANY cybersecurity question.";
            }

            string lowerInput = input.ToLower();

            ActivityLogger.Add("User input: " + input);

            // QUIZ MODE
            if (_quizRunning)
            {
                if (lowerInput == "true" || lowerInput == "false")
                {
                    QuizQuestion question =
                        _quizManager.Questions[_quizManager.CurrentQuestion];

                    string response;

                    if (lowerInput == question.Answer)
                    {
                        _quizManager.Score++;

                        response =
                            "✔ Correct!\n\n" +
                            question.Explanation;
                    }
                    else
                    {
                        response =
                            "✘ Incorrect.\n\n" +
                            question.Explanation;
                    }

                    _quizManager.CurrentQuestion++;

                    if (_quizManager.CurrentQuestion >=
                        _quizManager.Questions.Count)
                    {
                        _quizRunning = false;

                        double percentage =
                            (double)_quizManager.Score /
                            _quizManager.Questions.Count * 100;

                        string feedback;

                        if (percentage >= 90)
                            feedback = "Excellent! Outstanding cybersecurity knowledge.";
                        else if (percentage >= 70)
                            feedback = "Good job! Strong cybersecurity awareness.";
                        else if (percentage >= 50)
                            feedback = "Fair performance. Keep improving.";
                        else
                            feedback = "Needs improvement. Review cybersecurity concepts.";

                        return
                            response +
                            "\n\nFINAL SCORE: " +
                            _quizManager.Score +
                            "/" +
                            _quizManager.Questions.Count +
                            "\n\n" +
                            feedback;
                    }

                    response +=
                        "\n\nQuestion " +
                        (_quizManager.CurrentQuestion + 1) +
                        ":\n\n" +
                        _quizManager.Questions[_quizManager.CurrentQuestion].Question +
                        "\n\nAnswer True or False.";

                    return response;
                }
            }

            // NLP COMMANDS
            string intent = _nlpProcessor.DetectIntent(lowerInput);

            if (intent == "START_QUIZ")
            {
                _quizRunning = true;

                _quizManager.CurrentQuestion = 0;
                _quizManager.Score = 0;

                ActivityLogger.Add("Quiz started");

                return
                    "CYBERSECURITY QUIZ\n\nQuestion 1:\n\n" +
                    _quizManager.Questions[0].Question +
                    "\n\nAnswer True or False.";
            }

            if (intent == "ADD_TASK")
            {
                _taskManager.AddTask(
                    "Enable two-factor authentication",
                    DateTime.Now.AddDays(3));

                return
                    "Task added successfully.\n\n" +
                    "Reminder Date: " +
                    DateTime.Now.AddDays(3).ToShortDateString();
            }

            if (intent == "SHOW_TASKS")
            {
                List<TaskItem> taskList = _taskManager.GetTasks();

                if (taskList.Count == 0)
                {
                    return "There are currently no tasks.";
                }

                string tasks = "CURRENT TASKS:\n\n";
                foreach (var task in taskList)
                {
                    tasks += task + "\n";
                }

                return tasks;
            }

            if (intent == "COMPLETE_TASK")
            {
                int taskNumber = ExtractTaskNumber(lowerInput);

                _taskManager.CompleteTask(taskNumber);

                return $"Task {taskNumber + 1} marked as completed.";
            }

            if (intent == "DELETE_TASK")
            {
                int taskNumber =
                    ExtractTaskNumber(lowerInput);

                _taskManager.DeleteTask(taskNumber);

                return
                    $"Task {taskNumber + 1} deleted.";
            }

            if (intent == "SHOW_LOG")
            {
                string logs = "RECENT ACTIVITY:\n\n";

                foreach (var log in ActivityLogger.GetRecent())
                {
                    logs += log + "\n";
                }

                return logs;
            }

            // MEMORY
            if (lowerInput.Contains("what is my name"))
            {
                return
                    $"Your name is {_memory.Recall("name")}.";
            }

            if (lowerInput.Contains("what is my student number"))
            {
                return
                    $"Your student number is {_memory.Recall("student")}.";
            }

            // EMOTIONAL RESPONSES
            if (lowerInput.Contains("sad") ||
                lowerInput.Contains("upset") ||
                lowerInput.Contains("depressed"))
            {
                List<string> jokes = new List<string>
                {
                    "Why did the hacker go broke? Because he used all his cache 😂",
                    "Why was the computer cold? It left Windows open 😂",
                    "Why do programmers hate nature? Too many bugs 😂"
                };

                return
                    jokes[_random.Next(jokes.Count)];
            }

            // SENTIMENT
            Sentiment detected =
                _sentiment.Detect(lowerInput);

            string sentimentText =
                _sentiment.GetSentimentResponse(detected);

            // KEYWORDS
            string keywordResponse =
                _keywords.GetResponse(lowerInput);

            if (keywordResponse != null)
            {
                return
                    sentimentText +
                    "\n" +
                    _memory.GetPersonalisedOpener() +
                    "\n\n" +
                    keywordResponse;
            }

            return
                "I can help with:\n\n" +
                "• Passwords\n" +
                "• Phishing\n" +
                "• Malware\n" +
                "• VPN\n" +
                "• Privacy\n" +
                "• Firewalls\n" +
                "• Encryption\n" +
                "• Viruses\n" +
                "• Cybersecurity\n\n" +
                "Commands:\n" +
                "• start quiz\n" +
                "• add task\n" +
                "• show tasks\n" +
                "• show activity log";
        }


        public List<TaskItem> GetTasks()
        {
            return _taskManager.GetTasks();
        }
        public int GetQuizProgress()
        {
            return _quizManager.CurrentQuestion;
        }
        private int ExtractTaskNumber(string input)
        {
            string[] parts = input.Split(' ');

            foreach (string part in parts)
            {
                if (int.TryParse(part, out int number))
                {
                    return number - 1;
                }
            }

            return 0;
        }

    }
}