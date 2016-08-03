using System;
using System.Collections.Generic;


namespace Tester
{
    static class Mathh
    {
        public static float Pot(int tal, int eksponent)
        {
            bool isFraction = false;
            if (eksponent < 0)
            {
                eksponent = -eksponent;
                isFraction = true;
            }
            float value = 1;

            //Ganger return værdi med talet "eksponent gange"
            for (int i = 0; i < eksponent; i++)
            {

                if (value == 1)
                {
                    value = tal;
                    continue;
                }

                value *= tal;

                //Hvis nummeret er for stort til int
                if (value.ToString().Length > 6)
                {
                    Console.WriteLine("ERROR: NUMBER TOO BIG!");
                }

            }
            if (isFraction == true)
                return 1 / value;
            else
                return value;
        }


        public static float Round(float f, int digits)
        {
            bool deci = false;
            float result;
            string sf = f.ToString();
            string sResult = "";
            for (int i = 0; i < sf.Length; i++)
            {
                if (digits == 0)
                    break;
                else if (deci == true)
                    digits--;
                else if (sf[i] == '.' || sf[i] == ',')
                    deci = true;
                sResult += sf[i].ToString();
            }

            result = stringToFloat(sResult);
            return result;



        }

        //Returnerer -1 hvis string er faulty
        public static float stringToFloat(string input)
        {
            //Variabler
            int længde = 0;
            bool komma = false;
            string tal = "";
            float PositivTal = 0;

            //Finder længde før komma og fjerner komma
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '.' || input[i] == ',')
                {
                    if (komma == true)
                        return 0;
                    komma = true;
                    continue;
                }
                else if (komma == false)
                    længde++;
                tal += input[i].ToString();
            }

            //Omdanner stringen til float ved at gå igennem hvert char
            for (int i = 0; i < tal.Length; i++)
            {
                switch (tal[i])
                {
                    case '0':
                        break;
                    case '1':
                        PositivTal += Mathh.Pot(10, længde - (i + 1)) * 1;
                        break;
                    case '2':
                        PositivTal += Mathh.Pot(10, længde - (i + 1)) * 2;
                        break;
                    case '3':
                        PositivTal += Mathh.Pot(10, længde - (i + 1)) * 3;
                        break;
                    case '4':
                        PositivTal += Mathh.Pot(10, længde - (i + 1)) * 4;
                        break;
                    case '5':
                        PositivTal += Mathh.Pot(10, længde - (i + 1)) * 5;
                        break;
                    case '6':
                        PositivTal += Mathh.Pot(10, længde - (i + 1)) * 6;
                        break;
                    case '7':
                        PositivTal += Mathh.Pot(10, længde - (i + 1)) * 7;
                        break;
                    case '8':
                        PositivTal += Mathh.Pot(10, længde - (i + 1)) * 8;
                        break;
                    case '9':
                        PositivTal += Mathh.Pot(10, længde - (i + 1)) * 9;
                        break;
                    default:
                        return 0;
                }
            }
            return PositivTal;
        }
    }
}
