using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipMania
{
    class Program
    {
        
        /// <summary>
        /// This function generates a random number
        /// </summary>
        public static Random randomNumberGenerator = new Random();

        /// <summary>
        /// This is the main where the function to flip a coin and to flip for heads is called from with a passed parameter to show number of flips
        /// </summary>
        /// <param name="args">arguments passed are number of times that you want the functions to process  </param>
        static void Main(string[] args)
        {
            FlipCoins(10000);
            FlipForHeads(10000);
            //
            Console.ReadKey();

        }
        /// <summary>
        /// Flips a coin
        /// </summary>
        /// <returns>returns an int containing the number of Heads and a separate one for tails </returns>
        static void FlipCoins(int numberOfFlips)
        {
            if (numberOfFlips > 0)
            {
                int numberOfHeads = 0;
                int numberOfTails = 0;

                // Flip a coin a number of times
                for (int i = 0; i < numberOfFlips; i++)
                {
                    if (randomNumberGenerator.Next(0, 2) == 0)
                    {
                        numberOfHeads++;
                    }
                    else
                    {
                        numberOfTails++;
                    }
                }
                     // write results to Console
                    Console.WriteLine("We flipped a coin " + numberOfFlips + " times");
                    Console.WriteLine("Number 0f Heads: " + numberOfHeads);
                    Console.WriteLine("Number of Tails: " + numberOfTails);
                }
            }

               
           
        /// <summary>
        /// This function keeps track of the number of total flips as well as the number of times that heads is flipped
        /// </summary>
        /// <param name="numberOfHeads">a field to track the number of times that your flip os heads</param>
        static void FlipForHeads( int numberOfHeads)
        {
            if (numberOfHeads > 0)
            {
                int numberOfHeadsFlipped = 0;
                int totalFlips = 0;
            
                while (numberOfHeadsFlipped <=  numberOfHeads)
                {
                //generates the random number to tell you if it's heads or tails and checks if it's heads and adds it to the counter
                if (randomNumberGenerator.Next(0, 2) == 0)
                {
                numberOfHeadsFlipped++;
                }
                totalFlips++;
           }
                Console.WriteLine("We are flipping a coin until we find " + numberOfHeadsFlipped + " heads");
                Console.WriteLine("It took " + totalFlips + " to find " + numberOfHeadsFlipped + " heads");
                    
            
    
    
        }
    
        }
    }
}

