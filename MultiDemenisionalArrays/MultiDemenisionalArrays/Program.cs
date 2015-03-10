using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiDemenisionalArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            // how to make a 1d array
            int[] My1DArray = new int[10];

            // how to make a 2d array

            int[,] My2DArray = new int[3, 3];

            // populate our 2D array with values
            
            int counter = 1;
           for (int y = 0; y < 3; y++)
            {

                for (int x = 0; x < 3; x++)
               {
                    My2DArray[x, y] = counter;


                   counter++;
           
                   Console.Write("[{0}] ", My2DArray[x, y]);
                   
                    // using arrows for movement

                   ConsoleKeyInfo input = Console.ReadKey();
                    
                    switch (input.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            break;
        
                        case ConsoleKey.RightArrow:
                            break;

                        case ConsoleKey.DownArrow:
                            break;
                        case ConsoleKey.UpArrow:
                            break;
                        default:
                            Console.WriteLine("Not a valid Input");
                            break;
                    }

             
                    
                    Console.ReadKey();


                }
                // Create a twoD array of points
                Point[,] pointArray = new Point[10, 10];

                for(int y = 0; y < 10; y++)
                {
                    // for each row
                    for (int x = 0; x < 10; x++)
                    {
                        pointArray[x,y] = new Point(x,y);
                    }
                }

            }
        }





    }

    public class Point
    {
        Point   x { get; set;}
        
        Point  y { get; set;}
    }
}
    
        
    

