using System;
using System.Collections.Generic;

namespace BudgetProgram
{
    static class HingeIO
    {
        public static float GetPosTal(string prompt)
        {
            float result;
            string input;

            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();
                result = Mathh.stringToFloat(input);
            }
            while (result == 0);

            return result;
        }
        public static string GetString(string prompt, int length)
        {
            string value;
            do
            {
                Console.Write(prompt);
                value = Console.ReadLine();
            }
            while (value.Length > length);

            return value;
        }
    }
}
