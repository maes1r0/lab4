using Lab4._4.Helpers;
using Lab4._4.Settings;
using Lab4.Shared;
using System;
using System.Linq;
using System.Text;

namespace Lab4._4
{
    class Program
    {
        static readonly char[] forbiddenSymbols = new char[]
            {
                '.', ',', ':' ,'-', '*', '!', '?', '\'',
                '\"', '—', '\n', '\r', '[', ']', '(', ')',
                '…', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', ';'
            };

        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            var cipherer = new Cipherer(new CipherSettings
            {
                A = 19,
                B = 10,
                AReverted = 9
            });

            var belikCipherer = new Cipherer(new CipherSettings
            {
                A = 5,
                B = 7,
                AReverted = 7
            });

            var semenchenkoCipherer = new Cipherer(
                new CipherSettings
                {
                    A = 5,
                    B = 10,
                    AReverted = 7
                }
            );

            var melnykCipherer = new Cipherer(
                    new CipherSettings
                    {
                        A = 5,
                        B = 11,
                        AReverted = 7
                    }
                );

            var texts = new Reader(args).Read();

            foreach (var text in texts)
            {
                if (text.fileName == "belik.txt")
                {
                    var decodedBelik = belikCipherer.Decode(text.content);

                    Console.WriteLine(text.fileName);
                    Console.WriteLine();
                    Console.WriteLine(text.content);
                    Console.WriteLine();
                    Console.WriteLine(decodedBelik);
                    Console.WriteLine();
                    Console.WriteLine();

                    continue;
                }

                if (text.fileName == "semenchenko.txt")
                {
                    var decodedSemenchenko = semenchenkoCipherer.Decode(text.content);

                    Console.WriteLine(text.fileName);
                    Console.WriteLine();
                    Console.WriteLine(text.content);
                    Console.WriteLine();
                    Console.WriteLine(decodedSemenchenko);
                    Console.WriteLine();
                    Console.WriteLine();

                    continue;
                }

                if (text.fileName == "melnyk.txt")
                {
                    var decodedMelnyk = melnykCipherer.Decode(text.content);

                    Console.WriteLine(text.fileName);
                    Console.WriteLine();
                    Console.WriteLine(text.content);
                    Console.WriteLine();
                    Console.WriteLine(decodedMelnyk);
                    Console.WriteLine();
                    Console.WriteLine();

                    continue;
                }

                var filtered = FilterForbiddenSymbols(text.content.ToLower());

                var encoded = cipherer.Encode(filtered);
                var decoded = cipherer.Decode(encoded);

                Console.WriteLine(text.fileName);
                Console.WriteLine();
                Console.WriteLine(encoded);
                Console.WriteLine();
                Console.WriteLine(decoded);
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    
        static string FilterForbiddenSymbols(string text)
        {
            var filtered = text.Where(_ => !forbiddenSymbols.Contains(_)).ToArray();
            return new string(filtered);
        }
    }
}
