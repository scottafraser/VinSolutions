using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace VIN_Solutions
{
    public static class Program
    {
        public static string FormatWord(string word)
        {
            string middle = word.Substring(1, word.Length - 2);
            int count = middle.Distinct().Count();
            return String.Concat(word.First(), count, word.Last());
        }
        public static bool EndsWithSpecialCharacter(string word)
        {
            Regex rgx = new Regex("[^A-Za-z0-9]");
            var last = word.Last().ToString();
            return rgx.IsMatch(last);
        }

        public static string ParseSentence(string input)
        {
            string[] sentence = input.Split(" ");
            string newSentence = "";

            //parse through each word
            foreach (string word in sentence)
            {
                //skip for single characters like "a", "I"
                if (word.Length == 1)
                {
                    newSentence = String.Concat(newSentence, " ", word);
                }
                else
                {
                    var i = word;
                    //check for special characters at the end of a word like "," and "!"
                    if (Program.EndsWithSpecialCharacter(word))
                    {
                        //remove character before format logic
                        i = word.TrimEnd(word.Last());
                    }

                    //find middle of the word and count, put sentance back together so far
                    newSentence = String.Concat(newSentence, " ", Program.FormatWord(i));

                    if (EndsWithSpecialCharacter(word))
                    {
                        //add character back to end of word
                        newSentence = String.Concat(newSentence, word.Last());
                    }
                }
            }
            return newSentence.Trim();
        }

        public static void Main()
        {
            bool TryAgain = true;
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Oh hello, this program parses a sentence and replaces each word with the following: first letter, number of distinct characters between first and last character, and last letter. For example, \"You should hire Scott\" would become \"Y1u s4d h2e S3t\".");
            Console.WriteLine("");

            while (TryAgain == true)
            {
                Console.WriteLine("Please type a sentence...");
                Console.WriteLine("");

                string input = Console.ReadLine();

                //checked for empty input
                if (String.IsNullOrEmpty(input))
                {
                    Console.WriteLine("You gotta type SOMETHING, man");
                    Console.WriteLine("");
                    continue;
                }
                else if (!String.IsNullOrEmpty(input))
                {
                    Console.WriteLine("");
                    string result = ParseSentence(input);
                    Console.WriteLine(result);

                    Console.WriteLine("");
                    Console.WriteLine("Nice, try agian? [y/n]");
                    string answer = Console.ReadLine();

                    Console.WriteLine("");
                    if (answer == "y" || answer == "Y")
                    {
                        TryAgain = true;
                    }
                    else
                    {
                        Console.WriteLine("Thanks, have a wonderful day!");
                        TryAgain = false;
                    }
                } else
                {
                    continue;
                }

            }
        }
    }
}
