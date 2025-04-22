using System;
using System.Collections.Generic;
using System.Text;

namespace OldPhonePadApp
{
    class Program
    {
        // convert string to message
        public static string OldPhonePad(string input)
        {
            // dictionary
            Dictionary<char, string> keypad = new Dictionary<char, string>()
            {
                {'1', "&'("},
                {'2', "ABC"},
                {'3', "DEF"},
                {'4', "GHI"},
                {'5', "JKL"},
                {'6', "MNO"},
                {'7', "PQRS"},
                {'8', "TUV"},
                {'9', "WXYZ"},
                {'0', " "}
            };

            // final result
            StringBuilder result = new StringBuilder();

            // track
            char lastChar = '\0'; 
            int count = 0;         

            // Loop through each character
            foreach (char c in input)
            {
                if (c == '#')
                {
                    // End
                    break;
                }
                else if (c == '*')
                {
                    if (result.Length > 0)
                        result.Remove(result.Length - 1, 1);
                }
                else if (c == ' ')
                {
                    // Pause 
                    lastChar = '\0';
                    count = 0;
                }
                else
                {
                    if (c == lastChar)
                    {
                        count++;
                    }
                    else
                    {
                        if (lastChar != '\0' && keypad.ContainsKey(lastChar))
                        {
                            string letters = keypad[lastChar];
                            int index = (count - 1) % letters.Length;
                            result.Append(letters[index]);
                        }
                        lastChar = c;
                        count = 1;
                    }
                }
            }

            // Pending character
            if (lastChar != '\0' && keypad.ContainsKey(lastChar))
            {
                string letters = keypad[lastChar];
                int index = (count - 1) % letters.Length;
                result.Append(letters[index]);
            }

            // Return final message
            return result.ToString();
        }

        // Test
        static void Main(string[] args)
        {
            Console.WriteLine(OldPhonePad("33#"));                     // E
            Console.WriteLine(OldPhonePad("227*#"));                  // B
            Console.WriteLine(OldPhonePad("4433555 555666#"));        // HELLO
            Console.WriteLine(OldPhonePad("8 88777444666*664#"));     // TEST
        }
    }
}


