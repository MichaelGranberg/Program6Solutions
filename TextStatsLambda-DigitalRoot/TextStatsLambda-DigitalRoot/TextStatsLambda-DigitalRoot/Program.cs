using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextStatsLambda_DigitalRoot
{
    class Program
    {
        public static int vowelsCounter = 0;
        static void Main(string[] args)
        {
            DigitalRoot("7");
            DigitalRoot("31337");
            
            TextStats("I have to say that Lambdas are cool. They enable us to use less code. The solution is more compact.");
              
        }
        /// <summary>
        /// This function checks the digits in a string to see if they add up to a check sum
        /// </summary>
        /// <param name="rootThisNumber">string rootThisNumber</param>
        /// <returns>int numberRoot</returns>
        public static int DigitalRoot(string rootThisNumber)
        {
            int numberRoot = 0;
            String numberRootString = rootThisNumber;
            //
            //checks to see if it is 1 digit and moves it to the return value
            if (numberRootString.Length == 1)
            {
                numberRoot = int.Parse(rootThisNumber.ToString());
            }
            /// If the string is longer than 1 digit we have tlo keep adding until it is 1 digit
            while (numberRootString.Length > 1)
            {
                numberRoot = 0;
                // parses each character and turns it into an integer to add
                foreach (char digit in numberRootString)
                {
                    numberRoot += int.Parse(digit.ToString());
                }
                // if integer is larger than 1 digit, move it to the value for the while loop to keep going
                if (numberRoot >= 10)
                {
                    // save string to keep going
                    numberRootString = numberRoot.ToString();
                     
                }
                else
                {
                   
                    break;
                }

            } 
            
            Console.WriteLine(numberRoot);
            return numberRoot;
            
        }
        /// <summary>
        /// Function to call all of the subfunctions for the string
        /// </summary>
        /// <param name="inputString">inputString to work on</param>
        public static void TextStats (string inputString)
        {
            Console.WriteLine("Number of Characters: " + inputString.Length);
            Console.WriteLine("Number of Words: " + NumberOfWords(inputString));
            Console.WriteLine("Number of Vowels: " + NumberOfVowels(inputString));
            Console.WriteLine("Number of Consonants: " + NumberOfConsonants(inputString));
            Console.WriteLine("Number of Special Characters: " + NumberOfSpecialCharacters(inputString));
            Console.WriteLine("Longest Word: " + LongestWord(inputString));
            Console.WriteLine("Shortest Word: " + ShortestWord(inputString));
            //
            Console.ReadKey();
         }
        /// <summary>
        /// Function to calculate Number of Words
        /// </summary>
        /// <param name="inputString">String to process</param>
        /// <returns>int number of words</returns>
        public static int NumberOfWords(string inputString)
        {
            // splits the string on spaces and counts words
            int numberWords = inputString.Split(' ').OrderBy(x=>x.Length).Count();
            return numberWords;
        }
        /// <summary>
        /// Function to count number of vowels
        /// </summary>
        /// <param name="inputString"String to process></param>
        /// <returns>int number of vowels </returns>
        public static int NumberOfVowels(string inputString)
        {
            // checks to see if string contains a vowel and counts them
            int returnVowels = inputString.Count(x=>"aeiou".Contains(x.ToString().ToLower()));
            return returnVowels;
        }
        /// <summary>
        /// Function to count number of consonants
        /// </summary>
        /// <param name="inputString">String to process</param>
        /// <returns>int number of consonants</returns>
        public static int NumberOfConsonants(string inputString)
        {
            // checks to see if the string contains a consonant and counts them
            int returnconsonants = inputString.Count(x =>"bcdfghjklmnpqrstvwxyz".Contains(x.ToString().ToLower()));
            return returnconsonants;
        }
        /// <summary>
        /// Function to count number of special characters
        /// </summary>
        /// <param name="inputString">String to process</param>
        /// <returns>int number of special characters</returns>
        public static int NumberOfSpecialCharacters(string inputString)
        {
            // .,?;'!@#$%^&*() and spaces are considered special characters
            // checks to see if the string contains a special character and counts them
            int returnSpecChars = inputString.Count(x=>" .,?;'!@#$%^&*()".Contains(x.ToString()));
            return returnSpecChars;
        }
        /// <summary>
        /// Function to get the longest word
        /// </summary>
        /// <param name="inputString">String to process</param>
        /// <returns>string longest word</returns>
        public static string LongestWord(string inputString)
        {
            // splits the string on spaces and orders from longest to shortest and grabs the first word
            string longestWord = inputString.Split(' ').OrderByDescending(x=>x.Length).First();
            return longestWord;
        }
        /// <summary>
        /// Function to get the shortest word
        /// </summary>
        /// <param name="inputString">String to process</param>
        /// <returns>srring shortest word</returns>
        public static string ShortestWord(string inputString)
        {
            // splits the string on spaces abd orders for shortest to longest and grabs the first word
            string shortestWord = inputString.Split(' ').OrderBy(x => x.Length).First();
            return shortestWord;
        }


    }
}
