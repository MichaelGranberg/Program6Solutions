using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge147
{
    class Program
    {
        static void Main(string[] args)
        {
            CheckValidFootballScore();

             Console.ReadKey();
        }
        static void CheckValidFootballScore()
        {
            Console.WriteLine("Please Enter a number to check to see if it is a valid American Football Score:\n" +
            "\nThis program will also return what types of scores may be contained within.\n");

            int input = int.Parse(Console.ReadLine());
                                  
                CheckValid(input);
                       
        }


        static void CheckValid (int input)
        {
            switch (input)
            {
                case 0:
                    {
                        Console.WriteLine("Valid Football Score; {0} No points scored yet", input);
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Valid Football Score: {0} Score contains a fieldgoal", input);
                        break;
                    }
                case 1:
                case 2:
                case 4:
                case 5:
                    {
                        Console.WriteLine("Invalid Football Score : {0} ", input);
                        break;
                    }
                default:
                    {
                        if ((input % 6 == 0) || (input % 3 == 0))
                        {
                            Console.WriteLine("Valid Football Score: {0} Score contains touchdowns or fieldgoals", input);
                        }
                        else if(( input % 6 == 1) || (input % 3 == 1))
                        {
                            Console.WriteLine("Valid Football Score: {0} Score contains an extra point", input);
                        }
                        else if(( input % 6 ==2) || (input % 3 == 2))
                        {
                            Console.WriteLine("Valid Football Score: {0} Score could contain an extra point or two pt conversion", input);
                        }
                       
                        break;
                    }
              }
        }

        
    }
}
