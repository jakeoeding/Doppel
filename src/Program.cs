using System;
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

        }
    }
}
