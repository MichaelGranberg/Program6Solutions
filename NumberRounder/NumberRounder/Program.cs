using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberRounder
{
    class Program
    {
        /// <summary>
        /// Number Rounder
        /// </summary>
        /// <param name="args">Integer to round</param>
        static void Main(string[] args)
        {
        }
        static int NumberRounder(int numberToRound)
        {
            int remainder = numberToRound % 5;
            // ex. 18
            // 18 - 3 = 15 + 5 = 20
            if (remainder > 2)
            {
                return (numberToRound - remainder + 5);
            }
            else
            {
                // ex 17
                // 17 - 2 = 15
                return (numberToRound - remainder);
            }


        }
        // annoying textifyer, makes every letter uppercase
        /// <summary>
        /// Take in a string, it will return a string with letters alternation between upper and lowercase
        /// </summary>
        /// <param name="notAnnoyingString">string to make annoying</param>
        /// <returns>hard to read string</returns>
        static string AnnoyingTextIfyer(string notAnnoyingString)
        {
            //input nickelnack
            //output NiCkLeBaCk
            //declare a return string or our output
            string returnString = string.Empty;

            for (int i = 0; i < notAnnoyingString.Length; i++)
            {
               string currentLetter = notAnnoyingString[i].ToString();
                // if position of the letter is odd or even
               if (i % 2 == 0)
               {
                   //even, make it capital
                   returnString += currentLetter.ToUpper();
               }
               else
               {
                   returnString += currentLetter.ToLower();
               }

            }
            return returnString;
        }
    }
}
