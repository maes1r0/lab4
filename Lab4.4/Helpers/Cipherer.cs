using Lab4._4.Settings;
using System;
using System.Text;

namespace Lab4._4.Helpers
{
    public class Cipherer
    {
        public Cipherer(CipherSettings settings)
        {
            Settings = settings;
        }

        public CipherSettings Settings { get; }

        public string Encode(string text)
        {
            StringBuilder builder = new StringBuilder();

            foreach (var symbol in text)
            {
                var x = Array.IndexOf(Settings.Alphabet, symbol);
                var encodedSymbolIndex = (Settings.A * x + Settings.B) % Settings.Alphabet.Length;
                
                builder.Append(Settings.Alphabet[encodedSymbolIndex]);
            }

            return builder.ToString();
        }

        public string Decode(string text)
        {
            StringBuilder builder = new StringBuilder();
            
            foreach (var symbol in text)
            {
                var x = Array.IndexOf(Settings.Alphabet, symbol);
                var decodedSymbolIndex = Settings.AReverted * (x - Settings.B + Settings.Alphabet.Length) % Settings.Alphabet.Length;

                builder.Append(Settings.Alphabet[decodedSymbolIndex]);
            }

            return builder.ToString();
        }
    }
}
