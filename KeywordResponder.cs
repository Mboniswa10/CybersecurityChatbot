using System;
using System.Collections.Generic;

namespace CybersecurityChatbot
{
    public class KeywordResponder
    {
        private Dictionary<string, List<string>> _responses;

        private Random _random = new Random();

        public KeywordResponder()
        {
            _responses =
                new Dictionary<string, List<string>>
            {
                {
                    "password",
                    new List<string>
                    {
                        "Use strong passwords with symbols and numbers.",
                        "Never share your passwords online.",
                        "A password manager can help keep passwords safe."
                    }
                },

                {
                    "phishing",
                    new List<string>
                    {
                        "Phishing emails often pretend to be trusted companies.",
                        "Never click suspicious links in emails.",
                        "Always verify email senders carefully."
                    }
                },

                {
                    "privacy",
                    new List<string>
                    {
                        "Protect your personal information online.",
                        "Review your privacy settings regularly.",
                        "Avoid sharing sensitive information publicly."
                    }
                },

                {
                    "malware",
                    new List<string>
                    {
                        "Malware can damage your device.",
                        "Install antivirus software for protection.",
                        "Avoid downloading unknown files."
                    }
                },

                {
                    "scam",
                    new List<string>
                    {
                        "Scammers often create fake urgency.",
                        "Never send money to strangers online.",
                        "Always verify suspicious messages."
                    }
                },

                {
                    "vpn",
                    new List<string>
                    {
                        "VPNs encrypt your internet traffic.",
                        "VPNs help protect your privacy online.",
                        "Using a VPN on public Wi-Fi is recommended."
                    }
                },

                {
                    "hacker",
                    new List<string>
                    {
                        "Ethical hackers help improve cybersecurity.",
                        "Hackers exploit weak passwords and vulnerabilities.",
                        "Cybersecurity experts help stop hackers."
                    }
                },

                {
                    "firewall",
                    new List<string>
                    {
                        "Firewalls help block unauthorized access.",
                        "A firewall protects your computer network.",
                        "Always keep your firewall enabled."
                    }
                },

                {
                    "encryption",
                    new List<string>
                    {
                        "Encryption protects sensitive information.",
                        "Encrypted data is harder to steal.",
                        "Banks use encryption to protect transactions."
                    }
                },

                {
                    "wifi",
                    new List<string>
                    {
                        "Avoid unsecured public Wi-Fi.",
                        "Use strong Wi-Fi passwords.",
                        "Change your router password regularly."
                    }
                },

                {
                    "cyberbullying",
                    new List<string>
                    {
                        "Report cyberbullying immediately.",
                        "Block harmful users online.",
                        "Talk to someone you trust about cyberbullying."
                    }
                },

                {
                    "identity theft",
                    new List<string>
                    {
                        "Protect your personal information carefully.",
                        "Never share banking PINs online.",
                        "Monitor your accounts regularly."
                    }
                },

                {
                    "social media",
                    new List<string>
                    {
                        "Be careful what you post online.",
                        "Review your social media privacy settings.",
                        "Avoid accepting unknown friend requests."
                    }
                },

                {
                    "spyware",
                    new List<string>
                    {
                        "Spyware secretly monitors user activity.",
                        "Keep software updated to prevent spyware.",
                        "Use antivirus protection regularly."
                    }
                },

                {
                    "ransomware",
                    new List<string>
                    {
                        "Ransomware locks files until payment is made.",
                        "Backup your files regularly.",
                        "Avoid suspicious downloads and links."
                    }
                },

                {
                    "data breach",
                    new List<string>
                    {
                        "Change passwords after a data breach.",
                        "Use two-factor authentication.",
                        "Monitor accounts after breaches."
                    }
                },

                {
                    "2fa",
                    new List<string>
                    {
                        "Two-factor authentication adds extra security.",
                        "2FA helps prevent unauthorized access.",
                        "Always enable 2FA where possible."
                    }
                },

                {
                    "cybersecurity",
                    new List<string>
                    {
                        "Cybersecurity protects systems and information.",
                        "Learning cybersecurity improves online safety.",
                        "Cybersecurity awareness helps prevent attacks."
                    }
                },

                {
                    "trojan",
                    new List<string>
                    {
                        "Trojans disguise themselves as safe software.",
                        "Avoid downloading cracked applications.",
                        "Keep your antivirus updated."
                    }
                },

                {
                    "virus",
                    new List<string>
                    {
                        "Computer viruses spread between files.",
                        "Avoid opening unknown attachments.",
                        "Scan USB devices before use."
                    }
                }
            };
        }

        public string GetResponse(string input)
        {
            foreach (var pair in _responses)
            {
                if (input.Contains(pair.Key))
                {
                    List<string> replies = pair.Value;

                    return replies[
                        _random.Next(replies.Count)];
                }
            }

            return null;
        }

        public List<string> GetAllKeywords()
        {
            return new List<string>(_responses.Keys);
        }
    }
}