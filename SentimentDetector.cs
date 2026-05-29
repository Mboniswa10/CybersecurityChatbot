using System.Collections.Generic;

namespace CybersecurityChatbot
{
    public enum Sentiment
    {
        Neutral,
        Worried,
        Curious,
        Frustrated,
        Happy,
        Sad,
        Angry,
        Tired
    }

    public class SentimentDetector
    {
        private Dictionary<Sentiment, List<string>> _triggers;

        public SentimentDetector()
        {
            _triggers =
                new Dictionary<Sentiment, List<string>>
            {
                {
                    Sentiment.Worried,
                    new List<string>
                    {
                        "worried",
                        "afraid",
                        "scared",
                        "unsafe"
                    }
                },

                {
                    Sentiment.Curious,
                    new List<string>
                    {
                        "curious",
                        "interested",
                        "wondering"
                    }
                },

                {
                    Sentiment.Frustrated,
                    new List<string>
                    {
                        "frustrated",
                        "confused",
                        "annoyed"
                    }
                },

                {
                    Sentiment.Happy,
                    new List<string>
                    {
                        "great",
                        "awesome",
                        "happy"
                    }
                },

                {
                    Sentiment.Sad,
                    new List<string>
                    {
                        "sad",
                        "depressed",
                        "upset"
                    }
                },

                {
                    Sentiment.Angry,
                    new List<string>
                    {
                        "angry",
                        "mad",
                        "furious"
                    }
                },

                {
                    Sentiment.Tired,
                    new List<string>
                    {
                        "tired",
                        "exhausted",
                        "sleepy"
                    }
                }
            };
        }

        public Sentiment Detect(string input)
        {
            foreach (var pair in _triggers)
            {
                foreach (string trigger in pair.Value)
                {
                    if (input.Contains(trigger))
                    {
                        return pair.Key;
                    }
                }
            }

            return Sentiment.Neutral;
        }

        public string GetSentimentResponse(Sentiment s)
        {
            switch (s)
            {
                case Sentiment.Worried:
                    return "Do not worry. You are learning and improving your cybersecurity knowledge.\n";

                case Sentiment.Curious:
                    return "I love your curiosity about cybersecurity.\n";

                case Sentiment.Frustrated:
                    return "Cybersecurity can be challenging, but you are doing great.\n";

                case Sentiment.Happy:
                    return "Your positive attitude is awesome.\n";

                case Sentiment.Sad:
                    return "Here is a joke to cheer you up:\nWhy did the hacker stay calm? Because they kept their emotions encrypted.\n";

                case Sentiment.Angry:
                    return "Take a deep breath. Even computers need restarting sometimes.\n";

                case Sentiment.Tired:
                    return "Cybersecurity tip: even hackers need sleep sometimes.\n";

                default:
                    return "";
            }
        }
    }
}