using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;

namespace Lab4.Shared
{
    public abstract class Writer : IDisposable
    {
        protected readonly Dictionary<string, double> probabilities;
        protected readonly CsvWriter writer;

        public Writer(Dictionary<string, double> probabilities, string outputFile)
        {
            this.probabilities = probabilities;
            var stream = new StreamWriter(outputFile);
            writer = new CsvWriter(stream, CultureInfo.CurrentCulture);
        }

        public abstract void Write();

        public void Dispose()
        {
            writer.Dispose();
        }
    }
}
