using System;
using System.Collections.Generic;
using System.IO;

namespace Doppel
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Incorrect number of arguments. Usage: doppel <file1> <file2>");
                return;
            }

            if (!File.Exists(args[0]) || !File.Exists(args[1]))
            {
                Console.WriteLine("Invalid input file. Please ensure you provide a valid filepath.");
                return;
            }

            string rawText1 = File.ReadAllText(args[0]);
            string rawText2 = File.ReadAllText(args[1]);

            var parser = new TextParser();
            IDictionary<string, int> wordCounts1 = parser.CountWords(rawText1);
            IDictionary<string, int> wordCounts2 = parser.CountWords(rawText2);

            var analyzer = new TextAnalyzer();
            double similarityScore = analyzer.Compare(wordCounts1, wordCounts2);
            Console.WriteLine("The documents are {0:0}% similar.", similarityScore * 100);
        }
    }
}
