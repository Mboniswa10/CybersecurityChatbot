using System.Collections.Generic;

namespace CybersecurityChatbot
{
    public class QuizManager
    {
        public List<QuizQuestion> Questions { get; set; }

    public int CurrentQuestion { get; set; }

        public int Score { get; set; }

        public QuizManager()
        {
            Questions = new List<QuizQuestion>()
        {
            new QuizQuestion
            {
                Question = "Strong passwords should contain numbers.",
                Answer = "true",
                Explanation = "Numbers improve password strength."
            },

            new QuizQuestion
            {
                Question = "You should click suspicious links.",
                Answer = "false",
                Explanation = "Suspicious links may contain malware."
            },

            new QuizQuestion
            {
                Question = "Two-factor authentication improves security.",
                Answer = "true",
                Explanation = "It adds an extra layer of protection."
            },

            new QuizQuestion
            {
                Question = "Antivirus software helps protect computers.",
                Answer = "true",
                Explanation = "Antivirus software detects threats."
            },

            new QuizQuestion
            {
                Question = "Sharing passwords with friends is safe.",
                Answer = "false",
                Explanation = "Passwords should never be shared."
            },

            new QuizQuestion
            {
                Question = "Phishing emails try to steal information.",
                Answer = "true",
                Explanation = "Phishing attacks target personal data."
            },

            new QuizQuestion
            {
                Question = "Public Wi-Fi is always secure.",
                Answer = "false",
                Explanation = "Public Wi-Fi can expose your information."
            },

            new QuizQuestion
            {
                Question = "VPN stands for Virtual Private Network.",
                Answer = "true",
                Explanation = "VPN protects internet traffic."
            },

            new QuizQuestion
            {
                Question = "Ransomware encrypts files and demands payment.",
                Answer = "true",
                Explanation = "That is how ransomware attacks work."
            },

            new QuizQuestion
            {
                Question = "Cyberbullying is harmless.",
                Answer = "false",
                Explanation = "Cyberbullying can seriously affect people."
            }
        };

            CurrentQuestion = 0;
            Score = 0;
        }
    }

}
