using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedditChallenge193
{
    class Program
    {
       public static string userInput = String.Empty;

        static void Main(string[] args)
        {
            CalculateDimensions();
            
            Console.ReadKey();            
            
        }
        static void CalculateDimensions()
        {
            double volume = 0;

            getUserInput();

            if (ValidateInput(userInput))
            {
                volume = double.Parse(userInput);

                CubeVolume(volume);

                SphereVolume(volume);

                CylinderVolume(volume);

                ConeVolume(volume);


            }
            else
            {
                Console.WriteLine("Not a valid number, please make sure it is a valid number");
            }
            


        }
        static void getUserInput()
        {
            Console.WriteLine(" Please Input a Volume in Cubic Meters");
            //
            userInput = Console.ReadLine();
        }
        static bool ValidateInput(string userInput)
        {
            int outnum = 0;
            if (!int.TryParse(userInput, out outnum))
            {
                Console.WriteLine("Invalid input, please try again");
                return false;
            }
                                  
            return true;
        }
        static void CubeVolume(double volume)
        {
            double cubeSide = Math.Pow(volume, (1.00 / 3.00));
            Console.WriteLine(" Cube:      {0:F}m in length, {0:F}m in width,    {0:F}m  in height", cubeSide);
        }
        static void SphereVolume(double volume)
        {
            double sphereRadius = Math.Pow(((3 * volume) / (4 * Math.PI)), (1.00 / 3.00));
            double sphereDiameter = sphereRadius * 2;
            Console.WriteLine(" Sphere:    {0:F}m in radius, {1:F}m in diameter", sphereRadius, sphereDiameter);
        }
        static void CylinderVolume (double volume)
        {
            double cylHeight = Math.Pow((4 * volume) / ( Math.PI ) , (1.00 / 3.00));
            double cylRadius = (cylHeight / 2.00); // radius = .5 height, diameter = Height
            
            Console.WriteLine(" Cylinder:  {0:F}m in height, {1:F}m in radius,   {0:F} in diameter", cylHeight, cylRadius);
        }
        static void ConeVolume( double volume)
        {
            double coneHeight = Math.Pow((12 * volume) / (Math.PI), (1.00 /3.00));
            double coneRadius = (coneHeight/ 2.00); // radius = .5 height, diameter = height 
            
            Console.WriteLine(" Cone:      {0:F}m in height, {1:F}m in radius,   {0:F} in diameter", coneHeight, coneRadius);
        }

    }
}
