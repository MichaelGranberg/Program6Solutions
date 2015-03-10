using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flippingCoins
{
    class Program
    {
        static Random randomNumberGenerator = new Random();
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(FlipACoin());
            }
            //keep the window open
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(FlipForHeads());
            }
            
            Console.ReadKey();
        }
        /// <summary>
        /// Flips a coin
        /// </summary>
        /// <returns>a string of either heads or tails</returns>
        static string FlipACoin()
        {
            int theFlip = randomNumberGenerator.Next(0, 2);
            if (theFlip == 0)
            {
                return "Heads";
            }
            return "Tails";
        }
        /// <summary>
        /// Tells whether heads has been flipped
        /// </summary>
        /// <returns></returns>
        static int FlipForHeads()
        {
            bool headsHasNotBeenFlipped = true;
            int howManyFlips = 0;
            while (headsHasNotBeenFlipped)
            {
                string theFlip = FlipACoin();
                howManyFlips++;
                if (theFlip == "Heads")
                {
                    headsHasNotBeenFlipped = false;
                }
            }
            return howManyFlips;
        }
    }
}
