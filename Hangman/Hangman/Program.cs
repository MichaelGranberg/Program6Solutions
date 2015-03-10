using System;
using System.Collections.Generic;
using System.Linq; 
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Program
    {
        // these are all of the variables that need to be defined globally,
        //    so they can be used it the functions
        public static Random rng = new Random();
        public static string maskedWord;
        public static string lettersGuessed = String.Empty;
        public static int guessesLeft = 7;
        public static string wordForHangman;
        public static bool wordGuessed;
        public static bool playing;
        
        /// <summary>
        /// This is the main program functions
        /// </summary>
        /// <param name="args">no specific args</param>
        static void Main(string[] args)
        {


            //Let the user know the name of the game
            Console.WriteLine("HANGMAN\n");
            // ask for the user's name
            Console.WriteLine("Please enter your name\n");
            // read the user's name as input
            string userName = Console.ReadLine();

            // Welcome the user to the game using new line to save on console write lines
            Console.WriteLine("\nWelcome to the game of Hangman, " + userName + ", I hope you have fun !!\n" +
            "\nTo play this game you will be guessing letters for each of the underscores\n" +
            "on your screen. If you guess a wrong letter, it will let you know.\n" +
            "If you guess correctly, it will replace the underscore with the letter.\n" +
            "It will also display the letters that you have guessed, \n" +
            "along with the guesses that you have left.\n" + " If you know the word you can guess it as well");

            //Array wordList =  words for input into hangman 
            List<string> wordList = new List<string>() { "javascript", "agile", "database", "seedpaths", "opensource" };

            //Randomly select a word from the string
            wordForHangman = wordList[rng.Next(0, wordList.Count)];
           
            //
            playing = true;
            wordGuessed = false;
            
            
            // while you are playing the game
            while (playing) 
            {
              
                
                // if out of guesses
                if (guessesLeft == 0)
                {
                    Console.WriteLine(" You ran out of guesses, better luck next time");
                    playing = false;
                }
                // main logic in game playing - Guesses left and Word wasn't guessed
                if (guessesLeft > 0 && wordGuessed == false)
                {
                    

                    Console.WriteLine("");
                    // call function to return string to print to user screen
                    Console.WriteLine(PopMaskedWord(lettersGuessed, wordForHangman));
                    // if word isn't guessed, then write out letter guesses
                    if (!wordGuessed)
                    {
                    // call function to get user input
                    GuessInput();
                   
                   
                        Console.WriteLine(" Guesses Left: " + guessesLeft);
                        Console.WriteLine(" Letters that you have guessed: " + lettersGuessed);
                    }

                 } 
            }
            // Keep the Console Open
            
            Console.ReadKey();
        }
        /// <summary>
        /// This function will take in the string of letters guessed and the word generated and create a string to return
        /// </summary>
        /// <param name="lettersGuessed">a string containing the letters guessed</param>
        /// <param name="wordForHangman">a string for the random word that was pulled from the list of words for hangman</param>
        /// <returns>the string created with the letters and the underscores for letters not guessed yet</returns>
        public static string PopMaskedWord(string lettersGuessed, string wordForHangman)
        {
            maskedWord = String.Empty;
            // parses through the word by character
            for (int i = 0; i < wordForHangman.Length; i++)
            {
                // checks for a letter in the letters guessed string 
                if (lettersGuessed.Contains(wordForHangman[i]))
                {
                    //writes it to the output string to be displayed to the console
                    maskedWord += wordForHangman[i];
                }
                else
                {
                    // writes an underscore and space for readability
                    maskedWord += "_ ";
                }


            }
            
            // if the returned string equals the original word
            if (maskedWord == wordForHangman)
            {
                // excellent job you guessed it and it stops play
                Console.WriteLine("You guessed it, dude - Congratulations !!!!!");
                wordGuessed = true;
                playing = false;
                
            }
            // return string in all cases
            return maskedWord;
        }
        /// <summary>
        /// This is the function for guess input
        /// </summary>
        public static void GuessInput()
        {
            Console.WriteLine("Please enter a valid letter or if you know the word enter it");
            // this code reads the line and converts string to lower
            string userInput = Console.ReadLine().ToString().ToLower();
            // if the user is trying to guess the word
            if (userInput.Length > 1)
            {
                // if the guess equals the word
                if (userInput == wordForHangman)
                {
                    Console.WriteLine(" You guessed the word, How awesome are you !!!!");
                    // setting variables
                    wordGuessed = true;
                    playing = false;
                }
                else
                {
                    Console.WriteLine(" Not the right word");
                    guessesLeft--;
                }
            }
            if (!wordGuessed)
            {
                // this checks to see if the user entered a letter
                if ("abcdefghijklmnopqrstuvwxyz".Contains(userInput))
                {
                    lettersGuessed += userInput;
                    // if the word contains the letter entered
                    if (wordForHangman.Contains(userInput))
                    {
                        Console.WriteLine("You guessed a letter !!!");

                    }
                    else
                    {
                        // otherwise no letter
                        Console.WriteLine("You didn't get the letter !");
                        guessesLeft--;
                    }
                }
                else
                {
                    // if not alphabetic
                    Console.WriteLine("You have entered an invalid letter, please try again");
                }
            }
        }
    }
}
//
// requirements specification did not have asking user to replay game, but the code would look like the following:
//
//                if (wordGuessed)
//                {
//                   Console.WriteLine("\nWould you like to play again? y for yes or n for no");
//                   if (Console.ReadLine() == "y")
//                    {
//                        playing = true;
//                    }
//                    else
//                    {
//                        playing = false;
//                    }
//                }