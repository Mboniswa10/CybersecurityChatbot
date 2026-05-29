using System;
using System.Collections.Generic;

namespace CybersecurityChatbot
{
    public class ChatBot
    {
        private KeywordResponder _keywords;
        private SentimentDetector _sentiment;
        private MemoryStore _memory;

        private bool _awaitingName = true;
        private bool _awaitingStudentNumber = false;

        private string _lastTopic = "";

        private Random _random = new Random();

        public ChatBot()
        {
            _keywords = new KeywordResponder();
            _sentiment = new SentimentDetector();
            _memory = new MemoryStore();
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

            // ASK FOR NAME
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

            // ASK FOR STUDENT NUMBER
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

            // REMEMBER NAME
            if (lowerInput.Contains("what is my name"))
            {
                return
                    $"Your name is {_memory.Recall("name")}.";
            }

            // REMEMBER STUDENT NUMBER
            if (lowerInput.Contains("what is my student number"))
            {
                return
                    $"Your student number is {_memory.Recall("student")}.";
            }

            // SAD USER
            if (lowerInput.Contains("sad") ||
                lowerInput.Contains("depressed") ||
                lowerInput.Contains("upset"))
            {
                List<string> jokes = new List<string>
                {
                    "Why did the hacker go broke? Because he used all his cache 😂",
                    "Why was the computer cold? It left Windows open 😂",
                    "Why do programmers hate nature? Too many bugs 😂"
                };

                return
                    $"Hey {_memory.UserName}, do not be sad ❤️\n\n" +
                    jokes[_random.Next(jokes.Count)];
            }

            // ANGRY USER
            if (lowerInput.Contains("angry"))
            {
                return
                    "Take a deep breath 😊\n" +
                    "Even computers freeze sometimes.";
            }

            // TIRED USER
            if (lowerInput.Contains("tired"))
            {
                return
                    "You should rest 😴\n" +
                    "Cybersecurity experts need sleep too.";
            }

            // FOLLOW-UP
            if (lowerInput.Contains("tell me more") ||
                lowerInput.Contains("explain more"))
            {
                return GetFollowUpResponse();
            }

            // STORE INTEREST
            if (lowerInput.Contains("interested in"))
            {
                foreach (string keyword in _keywords.GetAllKeywords())
                {
                    if (lowerInput.Contains(keyword))
                    {
                        _memory.FavouriteTopic = keyword;

                        return
                            $"I will remember that you are interested in {keyword}.";
                    }
                }
            }

            // SENTIMENT
            Sentiment detected =
                _sentiment.Detect(lowerInput);

            string sentimentText =
                _sentiment.GetSentimentResponse(detected);

            // KEYWORD RESPONSE
            string keywordResponse =
                _keywords.GetResponse(lowerInput);

            if (keywordResponse != null)
            {
                foreach (string keyword in _keywords.GetAllKeywords())
                {
                    if (lowerInput.Contains(keyword))
                    {
                        _lastTopic = keyword;
                        break;
                    }
                }

                return
                    sentimentText + "\n" +
                    _memory.GetPersonalisedOpener() + "\n\n" +
                    keywordResponse;
            }

            // FALLBACK
            return
                "I can answer cybersecurity questions about:\n\n" +
                "• Passwords\n" +
                "• Phishing\n" +
                "• Malware\n" +
                "• VPN\n" +
                "• Privacy\n" +
                "• Scams\n" +
                "• Ransomware\n" +
                "• Firewalls\n" +
                "• Spyware\n" +
                "• Viruses\n" +
                "• Trojans\n" +
                "• Encryption\n" +
                "• Hackers\n" +
                "• Cyberbullying\n" +
                "• Data Breaches\n" +
                "• Social Media Safety\n" +
                "• Two-Factor Authentication\n" +
                "• Identity Theft\n" +
                "• Wi-Fi Security\n" +
                "• Antivirus\n" +
                "• Online Banking Safety\n" +
                "• Fake Websites\n\n" +
                "Ask me any cybersecurity question.";
        }

        private string GetFollowUpResponse()
        {
            switch (_lastTopic)
            {
                case "password":
                    return
                        "Strong passwords should:\n\n" +
                        "✔ Be at least 12 characters\n" +
                        "✔ Include uppercase letters\n" +
                        "✔ Include symbols and numbers\n" +
                        "✔ Never be shared";

                case "phishing":
                    return
                        "Phishing attacks trick users into revealing passwords or banking details.\n\n" +
                        "Always verify suspicious emails before clicking links.";

                case "malware":
                    return
                        "Malware includes:\n\n" +
                        "• Viruses\n" +
                        "• Spyware\n" +
                        "• Trojans\n" +
                        "• Ransomware";

                case "vpn":
                    return
                        "VPN stands for Virtual Private Network.\n\n" +
                        "It protects your internet connection and privacy.";

                case "privacy":
                    return
                        "Protect your privacy by limiting personal information shared online.";

                case "scam":
                    return
                        "Scammers often create urgency to pressure victims.";

                case "firewall":
                    return
                        "Firewalls block unauthorized access to your computer or network.";

                case "encryption":
                    return
                        "Encryption converts data into secure code to protect information.";

                case "virus":
                    return
                        "Computer viruses spread between files and devices.";

                case "spyware":
                    return
                        "Spyware secretly monitors user activity.";

                default:
                    return
                        "Please ask about a cybersecurity topic first.";
            }
        }
    }
}