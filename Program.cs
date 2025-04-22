using System;
using System.Collections.Generic;

namespace OldPhonePadApp
{
    class Program
    {
        // Convert input to a message
        public static string OldPhonePad(string input)
        {
            // Dictionary
            var keypad = new Dictionary<char, string>()
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
                {'0', " "} // Space
            };

            // Store final message
            string result = "";

            // Pressed last
            char lastChar = '\0';  // Nothing pressed
            int count = 0;         // How many times we've pressed that button

            // Go through each character the user pressed
            foreach (char c in input)
            {
                if (c == '#')
                {
                    // End of message - stop reading
                    break;
                }
                else if (c == '*')
                {
                    // Backspace - remove last letter from result
                    if (result.Length > 0)
                    {
                        result = result.Substring(0, result.Length - 1);
                    }
                }
                else if (c == ' ')
                {
                    // Pause - reset last key pressed
                    lastChar = '\0';
                    count = 0;
                }
                else
                {
                    // If it's the same button as before
                    if (c == lastChar)
                    {
                        count++; // press again
                    }
                    else
                    {
                        // If it's a different button and last one wasn't empty, resolve last one
                        if (lastChar != '\0')
                        {
                            string letters = keypad[lastChar];
                            int index = (count - 1) % letters.Length;
                            result += letters[index]; // add letter to result
                        }

                        // Update to new button
                        lastChar = c;
                        count = 1;
                    }
                }
            }

            // At the end, add the last character if needed
            if (lastChar != '\0')
            {
                string letters = keypad[lastChar];
                int index = (count - 1) % letters.Length;
                result += letters[index];
            }

            // Return final message
            return result;
        }

        // TEST
        static void Main(string[] args)
        {
            Console.WriteLine(OldPhonePad("33#"));                     // E
            Console.WriteLine(OldPhonePad("227*#"));                  // B
            Console.WriteLine(OldPhonePad("4433555 555666#"));        // HELLO
            Console.WriteLine(OldPhonePad("8 88777444666*664#"));     // TURING
        }
    }
}


