using System.Windows;
using System.Windows.Input;

namespace CybersecurityChatbot
{
    public partial class MainWindow : Window
    {
        private ChatBot _chatBot;

    public MainWindow()
        {
            InitializeComponent();

            _chatBot = new ChatBot();

            AppendBotMessage(_chatBot.GetGreeting());
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            SendMessage();
        }

        private void UserInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SendMessage();
            }
        }

        private void SendMessage()
        {
            string input = UserInput.Text.Trim();

            if (string.IsNullOrWhiteSpace(input))
            {
                return;
            }

            // Show user message
            AppendUserMessage(input);

            // Get chatbot response
            string response = _chatBot.ProcessInput(input);

            // Show bot response
            AppendBotMessage(response);

            // Refresh task and activity panels
            RefreshTasks();
            RefreshActivityLog();
            RefreshQuizProgress();

            // Clear input
            UserInput.Clear();
        }

        private void AppendUserMessage(string message)
        {
            ChatDisplay.Text += "\n✔ YOU: " + message + "\n";
        }

        private void AppendBotMessage(string message)
        {
            ChatDisplay.Text += "\n🤖 BOT: " + message + "\n";
        }

        private void RefreshTasks()
        {
            TaskList.Items.Clear();

            foreach (var task in _chatBot.GetTasks())
            {
                TaskList.Items.Add(task.ToString());
            }
        }

        private void RefreshActivityLog()
        {
            ActivityList.Items.Clear();

            foreach (var log in ActivityLogger.GetRecent())
            {
                ActivityList.Items.Add(log.ToString());
            }
        }

        private void RefreshQuizProgress()
        {
            QuizProgressBar.Value =
                _chatBot.GetQuizProgress();
        }


    }

}
