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

            AppendUserMessage(input);

            string response =
                _chatBot.ProcessInput(input);

            AppendBotMessage(response);

            UserInput.Clear();
        }

        private void AppendUserMessage(string message)
        {
            ChatDisplay.Text +=
                "\nYOU: " + message + "\n";
        }

        private void AppendBotMessage(string message)
        {
            ChatDisplay.Text +=
                "\nBOT: " + message + "\n";
        }
    }
}