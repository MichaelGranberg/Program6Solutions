using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disemvoweler
{
    class Program
    {
        static void Main(string[] args)
        {
            Disemvoweler("Nickleback is my favorite band. Their songwriting can't be beat!");
            //
            //blank line for spacing
            Console.WriteLine("");
            //
            Disemvoweler("How many bears could bear grylls grill if bear grylls could grill bears?");
            //
            //blank line for spacing
            Console.WriteLine("");
            //
            Disemvoweler("I'm a code ninja baby. I make the functions and I make the calls");
            //
            // keep the console open 
            Console.ReadKey();
        }
        /// <summary>
        /// This function will take an input string and take out spaces and special characters, create a string of the vowels
        /// and a string of the disemvoweled text and return the disemvoweled text to execute the test cases
        /// </summary>
        /// <param name="input">an imnput string</param>
        /// <returns>a string containing the disemvoweled text</returns>
        public static string Disemvoweler(string input)
        {
           
            // original input string
            string originalInput = input.ToString();

            // a string to hold all the removed special characters
            string spacesRemoved = String.Empty;

            // the disemvoweled string
            string disEmvoweled = String.Empty;

            // the string containing all the vowels that were rmoved
            string vowelsRemoved = String.Empty;

            // goes throuhg the input string
            for (int i = 0; i < input.Length - 1; i++)
            {
                // stores the current character to test
                string aCharacter = input[i].ToString();

                //  checks for lower and upper case vowels
                if ("aeiouAEIOU".Contains(aCharacter))
                {
                    // creates a string of removed vowels
                    vowelsRemoved += aCharacter;
                }
                // checks for special characters
                else if (" .,!'".Contains(aCharacter))
                {
                    // creates a string of removed special characters
                    spacesRemoved += aCharacter;
                }
                else
                {
                    // creates a string of disemvoweled text
                    disEmvoweled += aCharacter;
                }
            }

                // Write out the various string results
            Console.WriteLine("Original: " + originalInput);
            Console.WriteLine("Disemvoweled: " + disEmvoweled);
            Console.WriteLine("Vowels Removed: " + vowelsRemoved ); 

            // Return the Disemvoweled string as well for testing
            return disEmvoweled;
        }
    }
}
