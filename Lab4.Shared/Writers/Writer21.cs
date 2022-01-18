using System.Collections.Generic;
using System.Linq;

namespace Lab4.Shared
{
    public class Writer21 : Writer
    {
        public Writer21(Dictionary<string, double> probabilities, string outputFile)
            : base(probabilities, outputFile)
        { }

        public override void Write()
        {
            var count = probabilities.Count / 30;

            for (int i = 0; i < count; i++)
            {
                Write(i * 30, 30);
            }

            Write(count * 30, probabilities.Count % 30);

            writer.Flush();
        }

        private void Write(int skip, int take)
        {
            var takenProbabilities = probabilities.Skip(skip).Take(take);

            foreach (var letter in takenProbabilities.Select(_ => _.Key))
            {
                writer.WriteField(letter);
            }

            writer.NextRecord();

            foreach (var probability in takenProbabilities.Select(_ => _.Value))
            {
                writer.WriteField(probability.ToString("N5"));
            }

            writer.NextRecord();
        }
    }
}
