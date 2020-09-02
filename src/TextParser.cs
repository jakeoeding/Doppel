using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Doppel
{
    public class TextParser
    {
        public IDictionary<string, int> CountWords(string text)
        {
            string[] tokens = StandardizeText(text).Split();
            var wordCounts = new Dictionary<string, int>();

            foreach (string token in tokens)
            {
                if (token.Length == 0)
                {
                    continue;
                }

                if (wordCounts.ContainsKey(token))
                {
                    wordCounts[token]++;
                }
                else
                {
                    wordCounts[token] = 1;
                }
            }

            return wordCounts;
        }

        public string StandardizeText(string text)
        {
            string textLessPunctuation = RemovePunctuation(text);
            string cleanText = RemoveLineEndings(textLessPunctuation);
            return cleanText.ToLower();
        }

        public string RemoveLineEndings(string text)
        {
            return text.Replace("\n", " ").Replace("\r", " ").Trim();
        }

        public string RemovePunctuation(string text)
        {
            return Regex.Replace(text, @"(\p{P})", string.Empty);
        }
    }
}
