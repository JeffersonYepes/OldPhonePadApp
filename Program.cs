using System;
using System.Collections.Generic;
using System.Text;

namespace OldPhonePadApp
{
    class Program
    {
        // Method to convert input string to message based on old phone keypad
        public static string OldPhonePad(string input)
        {
            // 1. Define a dictionary to map numbers to letters.
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

            // 2. Create a StringBuilder to build the final result.
            StringBuilder result = new StringBuilder();

            // 3. Declare variables to track:
            char lastChar = '\0';  // the last pressed character
            int count = 0;         // number of consecutive presses

            // 4. Loop through each character in the input string.
            foreach (char c in input)
            {
                if (c == '#')
                {
                    // End of input
                    break;
                }
                else if (c == '*')
                {
                    // Backspace operation
                    if (result.Length > 0)
                        result.Remove(result.Length - 1, 1);
                }
                else if (c == ' ')
                {
                    // Pause between keypresses
                    lastChar = '\0';
                    count = 0;
                }
                else
                {
                    // If the same as the last button pressed
                    if (c == lastChar)
                    {
                        count++;
                    }
                    else
                    {
                        // If there's a previous character to resolve
                        if (lastChar != '\0' && keypad.ContainsKey(lastChar))
                        {
                            string letters = keypad[lastChar];
                            int index = (count - 1) % letters.Length;
                            result.Append(letters[index]);
                        }
                        // Update for new keypress
                        lastChar = c;
                        count = 1;
                    }
                }
            }

            // 5. Handle any last pending character after the loop
            if (lastChar != '\0' && keypad.ContainsKey(lastChar))
            {
                string letters = keypad[lastChar];
                int index = (count - 1) % letters.Length;
                result.Append(letters[index]);
            }

            // 6. Return the final message
            return result.ToString();
        }

        // Test cases to verify the method
        static void Main(string[] args)
        {
            Console.WriteLine(OldPhonePad("33#"));                     // Expected: E
            Console.WriteLine(OldPhonePad("227*#"));                  // Expected: B
            Console.WriteLine(OldPhonePad("4433555 555666#"));        // Expected: HELLO
            Console.WriteLine(OldPhonePad("8 88777444666*664#"));     // Expected: TEST
        }
    }
}


