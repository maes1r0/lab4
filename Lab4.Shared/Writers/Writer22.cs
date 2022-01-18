using System.Collections.Generic;
using System.Linq;

namespace Lab4.Shared
{
    public class Writer22 : Writer
    {
        private IEnumerable<char> alphabet;

        public Writer22(Dictionary<string, double> probabilities, string outputFile)
        : base(probabilities, outputFile)
        {
            alphabet = probabilities.Keys.SelectMany(_ => _).Distinct();
        }

        public override void Write()
        {
            WriteHeader();

            foreach (var firstLetter in alphabet)
            {
                writer.WriteField(firstLetter);

                foreach (var secondLetter in alphabet)
                {
                    var probability = GetProbability(firstLetter, secondLetter);
                    writer.WriteField((probability ?? 0).ToString("N4"));
                }

                writer.NextRecord();
            }

            writer.Flush();
        }

        private void WriteHeader()
        {
            writer.WriteField("");
            foreach (var letter in alphabet)
            {
                writer.WriteField(letter);
            }

            writer.NextRecord();
        }
    
        private double? GetProbability(char firstLetter, char secondLetter)
        {
            var key = probabilities.Keys.FirstOrDefault(_ => _[0] == firstLetter && _[1] == secondLetter);
            return key != null ? probabilities[key] : null;            
        }
    }
}
