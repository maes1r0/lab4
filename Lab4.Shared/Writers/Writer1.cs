using Lab4.Shared;
using System.Collections.Generic;
using System.Linq;

namespace Lab4.Shared
{
    public class Writer1 : Writer
    {
        public Writer1(Dictionary<string, double> probabilities, string outputFile)
            :base(probabilities, outputFile)
        { }

        public override void Write()
        {
            foreach (var letter in probabilities.Select(_ => _.Key))
            {
                writer.WriteField(letter);
            }

            writer.NextRecord();

            foreach (var probability in probabilities.Select(_ => _.Value))
            {
                writer.WriteField(probability);
            }

            writer.Flush();
        }
    }
}
