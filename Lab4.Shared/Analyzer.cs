using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lab4.Shared
{
    public class Analyzer
    {
        private readonly string text;
        private readonly char[] forbiddenSymbols = new char[]
        {
            '.', ',', ':' ,'-', '*', '!', '?', '\'',
            '\"', '—', '\n', '\r', '[', ']', '(', ')',
            '…', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', ';'
        };
        
        public Analyzer(string text)
        {
            this.text = FilterForbiddenSymbols(text.ToLower());
        }

        public Dictionary<string, double> Process(int subsequenceLength)
        {
            var subsequences = GetSubsequences(subsequenceLength);
            return subsequences.ToDictionary(_ => _, _ => GetProbability(_));
        }

        public string FilterForbiddenSymbols(string text)
        {
            var filtered = text.Where(_ => !forbiddenSymbols.Contains(_)).ToArray();
            return new string(filtered);
        }

        private HashSet<string> GetSubsequences(int subsequenceLength)
        {
            var result = new HashSet<string>();

            for (int i = 0; i < text.Length - (subsequenceLength - 1); i++)
            {
                var subsequence = text.Skip(i).Take(subsequenceLength).ToArray();
                result.Add(
                        new string(subsequence)
                    );
            }

            return result;
        }

        private double GetProbability(string subsequence)
        {
            double subsequencesCount = (text.Length - (subsequence.Length - 1)) / subsequence.Length;
            double countOfSubsequenceInText = Regex.Matches(text, subsequence, RegexOptions.IgnoreCase).Count;

            return countOfSubsequenceInText / subsequencesCount;
        }
    }
}
