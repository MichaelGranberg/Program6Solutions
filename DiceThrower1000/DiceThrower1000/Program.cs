using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceThrower1000
{
    class Program
    {
        static void Main(string[] args)
        {
        throwDice("3d20");

        Console.ReadKey();
        }
        static void throwDice(String diceString)
        {
            List<string> DieThrows = diceString.Split('d').ToList();
            int numberThrows = int.Parse(DieThrows[0]);
            int numFaces = int.Parse(DieThrows[1]);
            string resultsString = String.Empty;


            Random rng = new Random();


            while (numberThrows > 0)
            {
                // call the rng with the  parameter from the input number of faces
                int randomNumber = rng.Next(1, numFaces + 1);
                //add the number returned to the results string
                resultsString += randomNumber + " ";
                numberThrows = numberThrows--;
            }
            Console.WriteLine("throwing: " + diceString);
            Console.WriteLine("results: " + resultsString);
        }
    }
}