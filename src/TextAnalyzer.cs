using System;
using System.Collections.Generic;

namespace Doppel
{
    public class TextAnalyzer
    {
        public double Compare(IDictionary<string, int> wordCounts1,
                              IDictionary<string, int> wordCounts2)
        {
            SortedSet<string> uniqueWords = FindUniqueWords(wordCounts1.Keys, wordCounts2.Keys);
            int[] wordVec1 = CreateWordFrequencyVector(uniqueWords, wordCounts1);
            int[] wordVec2 = CreateWordFrequencyVector(uniqueWords, wordCounts2);
            double theta = Vector.AngleBetween(wordVec1, wordVec2);
            return 1 - (theta / (Math.PI / 2));
        }

        public SortedSet<string> FindUniqueWords(ICollection<string> wordList1,
                                                 ICollection<string> wordList2)
        {
            var wordSet = new SortedSet<string>();
            wordSet.UnionWith(wordList1);
            wordSet.UnionWith(wordList2);
            return wordSet;
        }

        public int[] CreateWordFrequencyVector(SortedSet<string> uniqueWords,
                                               IDictionary<string, int> wordCounts)
        {
            int[] freqVector = new int[uniqueWords.Count];
            int i = 0;

            foreach (string word in uniqueWords)
            {
                int wordCount = 0;

                if (wordCounts.ContainsKey(word))
                {
                    wordCount = wordCounts[word];
                }

                freqVector[i] = wordCount;
                i++;
            }

            return freqVector;
        }
    }
}
