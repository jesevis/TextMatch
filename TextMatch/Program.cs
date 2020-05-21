using System;
using System.Collections.Generic;
using System.Linq;

namespace TextMatch
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Missing mandatory arguments");

                return;
            }

            var matches = Process(args[0], args[1]);

            if (matches.Any())
            {
                Console.WriteLine(string.Join(',', matches));
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Finds sub text first letter indexes within a given text
        /// </summary>
        public static List<int> Process(string text, string subText)
        {
            text = text.ToLower();
            subText = subText.ToLower();

            var matches = new List<int>();

            for (var i = 0; i <= text.Length - subText.Length; i++)
            {
                var firstLetterMatchPosition = i;
                var isFirstLetterMatch = text[i] == subText[0];

                if (isFirstLetterMatch)
                {
                    int matchPosition = 1;

                    while (matchPosition < subText.Length)
                    {
                        var isLetterMatch = subText[matchPosition] == text[i + matchPosition];

                        if (!isLetterMatch)
                        {
                            break;
                        }

                        matchPosition++;
                    }

                    if (matchPosition == subText.Length)
                    {
                        matches.Add(firstLetterMatchPosition + 1);

                        i += subText.Length - 1;
                    }
                }
            }

            return matches;
        }
    }
}