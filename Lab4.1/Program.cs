using Lab4.Shared;
using System;
using System.Linq;
using System.Text;

namespace Lab4._1
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
                var letterToProbabilityList = analyzer.Process(1);

                Console.WriteLine($"Output in alphabet order:");
                var letterToProbabilityListSortedByLetter = letterToProbabilityList.OrderBy(_ => _.Key);
                foreach (var letterToProbability in letterToProbabilityListSortedByLetter)
                {
                    Console.WriteLine($"{letterToProbability.Key} - {letterToProbability.Value}");
                }

                Console.WriteLine();

                Console.WriteLine($"Output in descending probability order:");
                var letterToProbabilityListSortedByProbabilityAsc = letterToProbabilityList.OrderByDescending(_ => _.Value);
                foreach (var letterToProbability in letterToProbabilityListSortedByProbabilityAsc)
                {
                    Console.WriteLine($"{letterToProbability.Key} - {letterToProbability.Value}");
                }

                Console.WriteLine();
            }            
        }
    }
}
