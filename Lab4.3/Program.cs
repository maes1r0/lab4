using Lab4.Shared;
using System;
using System.Linq;
using System.Text;

namespace Lab4._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            var texts = new Reader(args).Read();

            foreach (var text in texts)
            {
                Console.WriteLine($"Analyzing text {text.fileName}...");
                Console.WriteLine();

                var analyzer = new Analyzer(text.content);
                var letterToProbabilityList = analyzer.Process(3);

                Console.WriteLine($"Output in descending probability order:");
                var letterToProbabilityListSortedByProbabilityDesc = letterToProbabilityList.OrderByDescending(_ => _.Value);
                foreach (var letterToProbability in letterToProbabilityListSortedByProbabilityDesc)
                {
                    Console.WriteLine($"{letterToProbability.Key} - {letterToProbability.Value}");
                }

                Console.WriteLine();

                Console.WriteLine($"30 sequences with biggest probability:");
                var letterToProbabilityListTop30 = letterToProbabilityList.OrderByDescending(_ => _.Value).Take(30);
                foreach (var letterToProbability in letterToProbabilityListTop30)
                {
                    Console.WriteLine($"{letterToProbability.Key} - {letterToProbability.Value}");
                }
            }
        }
    }
}
