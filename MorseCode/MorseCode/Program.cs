using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MorseCode
{
    class Program
    {
        static Dictionary<char, string> charToMorse = new Dictionary<char, string>()
        {
            {'a', ".-"},
            {'b', "-..."},
            {'c', "-.-."},
            {'d', "-.."},
            {'e', "."},
            {'f', "..-."},
            {'g', "--."},
            {'h', "...."},
            {'i', ".."},
            {'j', ".---"},
            {'k', "-.-"},
            {'l', ".-.."},
            {'m', "--"},
            {'n', "-."},
            {'o', "---"},
            {'p', ".--."},
            {'q', "--.-"},
            {'r', ".-."},
            {'s', "..."},
            {'t', "-"},
            {'u', "..-"},
            {'v', "...-"},
            {'w', ".--"},
            {'x', "-..-"},
            {'y', "-.--"},
            {'z', "--.."},

            {'0', "-----"},
            {'1', ".----"},
            {'2', "..---"},
            {'3', "...--"},
            {'4', "....-"},
            {'5', "....."},
            {'6', "-...."},
            {'7', "--..."},
            {'8', "---.."},
            {'9', "----."},

            {'.', ".-.-.-"},
            {',', "--..--"},
            {':', "---..."},
            {'?', "..--.."},
            {'!', "..--."},
            {'\'', ".----."},
            {'-', "-....-"},
            {'/', "-..-."},
            {'"', ".-..-."},
            {'@', ".--.-."},
            {'=', "-...-"}
        };

        static void Main(string[] args)
        {
            Console.Write("Plaintext:");
            string input = Console.ReadLine().ToLower().Trim();
            string rez = morseEnc(input);
            string rezD = morseDecode(rez);

            Console.WriteLine("Encode: " + rez);
            Console.WriteLine("Decode: " + rezD);
            Console.ReadKey();
        }

        public static string morseEnc(string input)
        {
            StringBuilder output = new StringBuilder();
            string[] inputArray = input.Split(' ');

            foreach (string word in inputArray)
            {
                foreach (char c in word)
                {
                    string morse = charToMorse[c];
                    output.Append(morse + "   ");
                    foreach (char x in morse)
                    {
                        if (x == '.')
                        {
                            Console.Beep(600, 100);
                            Console.Write(".");
                        }
                        else
                        {
                            Console.Write("-");
                            Console.Beep(600, 400);
                        }
                    }
                    Console.Write("   ");
                    System.Threading.Thread.Sleep(300);
                }
                System.Threading.Thread.Sleep(300);
                Console.Write("    ");
                output.Append("    ");
            }
            Console.WriteLine();
            return output.ToString();
        }

        public static string morseDecode(string input)
        {

            StringBuilder output = new StringBuilder();
            string[] inputArray = Regex.Split(input, "    ");

            foreach (string word in inputArray)
            {
                string[] morseArray = Regex.Split(word, "   ");
                foreach (string c in morseArray)
                {
                    output.Append(charToMorse.FirstOrDefault(x => x.Value == c).Key);
                }

            }

            return output.ToString();
        }
    }
}
