using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessThatNumber
{
    public class Program
    {
       //these are all the variables that need to be available to functions outside the main
       public static int numberToGuess = 0;

       public static int numberOfGuesses = 0;

       public static string userInput = String.Empty;

        /// <summary>
        /// This is the main, where most of the logic and function calls take place
        /// </summary>
        /// <param name="args">takes in no args</param>
       static void Main(string[] args)
       {
           //this is the de using a RNG.number the user needs to guess.  Set its value in your
           Random rng = new Random();
           // generates a random number between 1 and 100
           numberToGuess = rng.Next(1, 101);

           // initialized variables in the main
           int userGuess = 0;
           bool playing = true; 
           // writes the title of the game once
           Console.WriteLine("Guess That Number");


           // checks to see if still playing
           while (playing)
           {

               
               //               
               // calls the function to get the user input from the screen
               getUserInput();
               // calls the function to ensure it is numeric
               if (ValidateInput(userInput))
               {
                   // converts user guess into an int
                   userGuess = Int32.Parse(userInput);
                   // checks to see if guess is between 1 and 100
                   if (userGuess >= 1 && userGuess <= 100)
                   {
                       // checks to see if the user input is equal to the random number
                       if (userGuess == numberToGuess)
                       {
                           // awesome, you got the right number
                           Console.WriteLine("Congratulations, you got the number right");
                           // ends game
                           playing = false;

                       }
                       // checks to see in the guess is higher than the number
                       if (userGuess > numberToGuess)
                       {
                           //calls the too high function
                           IsGuessTooHigh(userGuess);
                           //
                          
                       }
                       // checks to see if the guess is lower than the number
                       if (userGuess < numberToGuess)
                       {
                           // calls the too low function
                           IsGuessTooLow(userGuess);
                           //
                           
                       }
                       //


                   }
                   else
                   {
                       // writes that it is not a valid number
                       Console.WriteLine("Not a valid number, please make sure it is a valid number");

                   }
                   // adds to the number of guesses in all cases
                   numberOfGuesses++;
               }

             
           }
           // writes the number of guesses when they are equal
           Console.WriteLine(" you guessed the right number, it took you " + numberOfGuesses + " tries");
           Console.ReadKey();
       }
        /// <summary>
        /// this function tells the user what to enter and reads the input from the console
        /// </summary>
        public static void getUserInput()
        {
            Console.WriteLine(" Please input a number between 1 and 100");
            //
            userInput = Console.ReadLine();

        }
        /// <summary>
        /// This function validates the input to ensure it is numeric
        /// </summary>
        /// <param name="userInput">a string which needs to </param>
        /// <returns></returns>
        public static bool ValidateInput(string userInput)
        {
            int outnum = 0;
            if (!int.TryParse(userInput, out outnum))
            {
                //is invalid
                Console.WriteLine("Invalid input, please try again");

                return false;
            }
                

                //is valid
                return true;
        }

           
        /// <summary>
        /// This function sets number to be passed into test
        /// </summary>
        /// <param name="number">number returned for test</param>
        public static void SetNumberToGuess(int number)
        {
            numberToGuess = number;

            //  This is used only for testing methods.
        }
        /// <summary>
        /// This function returns a true if it is too high, as well as writing a console message for the new guess
        /// </summary>
        /// <param name="userGuess">user entered guess</param>
        /// <returns>bool true if it is too high</returns>
        public static bool IsGuessTooHigh(int userGuess)
        {
            if (userGuess > numberToGuess)
            {
                Console.WriteLine("Your Guess was too high, please enter a new guess");
               // System.Threading.Thread.Sleep(1000);
                
                return true;
            }
            else
            {
                return false;
            }
               
        }
        /// <summary>
        /// This function returs a true if the guess is lower than the number
        /// </summary>
        /// <param name="userGuess">user entered guess</param>
        /// <returns>true if too low</returns>
    
        public static bool IsGuessTooLow(int userGuess)
        {
            //TODO: return true if the number guessed by the user is too low
            if (userGuess < numberToGuess)
            {
                Console.WriteLine("Your Guess was too low, please enter a new guess");
                //System.Threading.Thread.Sleep(1000);
                
                return true;
            }
            else
            { 
                return false;
            }

            
        }

    }
}
