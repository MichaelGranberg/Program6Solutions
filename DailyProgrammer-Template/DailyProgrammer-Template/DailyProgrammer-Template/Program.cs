using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //test classes need to have the using statement

///     REDDIT DAILY PROGRAMMER SOLUTION TEMPLATE 
///                             http://www.reddit.com/r/dailyprogrammer
///     Your Name: Michael Granberg
///     Challenge Name: A Cube, Ball, Cylinder, Cone walk into a warehouse
///     Challenge #: 193
///     Challenge URL: http://www.reddit.com/r/dailyprogrammer/comments/2peac9/20141215_challenge_193_easy_a_cube_ball_cylinder/
///     Brief Description of Challenge:
///         A company knows the volume of their product and wants to figure out what size of different shapes of containers 
///         they would need in order to store their products.
/// 
///
///     What was difficult about this challenge?
///     
///             Figuring out the calculation, when more than one variable was unknown.
///
///     
///
///     What was easier than expected about this challenge?
///     
///        Setting up the code to do the math, putting things into functions
///
///
///
///     BE SURE TO CREATE AT LEAST TWO TESTS FOR YOUR CODE IN THE TEST CLASS
///     One test for a valid entry, one test for an invalid entry.
///     
/// 
/// 
///     REDDIT DAILY PROGRAMMER SOLUTION TEMPLATE 
///                             http://www.reddit.com/r/dailyprogrammer
///     Your Name: Michael granberg
///     Challenge Name:Easy Sports Points
///     Challenge #: 147
///     Challenge URL: http://www.reddit.com/r/dailyprogrammer/comments/1undyd/010714_challenge_147_easy_sport_points/
///     Brief Description of Challenge:
///     Input a number and the pprogram will tell you if it is a valid football score
/// 
///
///     What was difficult about this challenge?
///     
///     Figuring out some way to make it unique
///     
///     I tried to submit it, but it was archived. I talked to a moderator and he said sometimes reddit just does that 
///     
///
///     What was easier than expected about this challenge?
///     
///     Determining if it was valid or not
///
///
///     BE SURE TO CREATE AT LEAST TWO TESTS FOR YOUR CODE IN THE TEST CLASS
///     One test for a valid entry, one test for an invalid entry.

///     


namespace DailyProgrammer_Template
{
    class Program
    {

        public static string userInput = String.Empty;
        /// <summary>
        /// Main 
        /// </summary>
        /// <param name="args">void</param>
        static void Main(string[] args)
        {
            // function call to calculate dimensions
            CalculateDimensions();

            Console.ReadKey();
            // function call to check vail football score
            CheckValidFootballScore();

            Console.ReadKey();

        }
        /// <summary>
        /// function to calculate dimensions
        /// </summary>
        public static void CalculateDimensions()
        {

            double volume = 0;
            // gets and then checks valid input
            getUserInput();
            // if valid input calls the following functions passing it the double volume
            if (ValidateInput(userInput))
            {
                // takes input string and converts it to double
                volume = double.Parse(userInput);

                CubeVolume(volume);

                SphereVolume(volume);

                CylinderVolume(volume);

                ConeVolume(volume);


            }
            else
            {
                // writes out that it isn't valid
                Console.WriteLine("Not a valid number, please make sure it is a valid number");
            }


        }
        /// <summary>
        /// function to read input string
        /// </summary>
        public static void getUserInput()
        {
            Console.WriteLine(" Please Input a Volume in Cubic Meters");
            //
            userInput = Console.ReadLine();
        }
        /// <summary>
        /// Validates input to see if it's numeric
        /// </summary>
        /// <param name="userInput">string</param>
        /// <returns>bool</returns>
        public static bool ValidateInput(string userInput)
        {
            int outnum = 0;
            if (!int.TryParse(userInput, out outnum))
            {
                Console.WriteLine("Invalid input, please try again");
                return false;
            }

            return true;
        }
        /// <summary>
        /// calculate the side of cube
        /// </summary>
        /// <param name="volume">double volume</param>
        /// <returns>double cubeside</returns>
        public static double CubeVolume(double volume)
        {
            double cubeSide = Math.Pow(volume, (1.00 / 3.00));
            Console.WriteLine(" Cube:      {0:F}m in length, {0:F}m in width,    {0:F}m  in height", cubeSide);
            return cubeSide;

        }
        /// <summary>
        /// calculate sphere radius and diameter 
        /// </summary>
        /// <param name="volume">double volume</param>
        /// <returns>double sphereRadius</returns>
        public static double SphereVolume(double volume)
        {
            double sphereRadius = Math.Pow(((3 * volume) / (4 * Math.PI)), (1.00 / 3.00));
            double sphereDiameter = sphereRadius * 2;
            Console.WriteLine(" Sphere:    {0:F}m in radius, {1:F}m in diameter", sphereRadius, sphereDiameter);
            return sphereRadius;
        }
        /// <summary>
        /// calculate cylinder height and radius
        /// </summary>
        /// <param name="volume">double volume</param>
        /// <returns>double cylHeight</returns>
        public static double CylinderVolume(double volume)
        {
            double cylHeight = Math.Pow((4 * volume) / (Math.PI), (1.00 / 3.00));
            double cylRadius = (cylHeight / 2.00); // radius = .5 height, diameter = Height
            Console.WriteLine(" Cylinder:  {0:F}m in height, {1:F}m in radius,   {0:F} in diameter", cylHeight, cylRadius);
            return cylHeight;
        }
        /// <summary>
        /// calculates cone height and radius
        /// </summary>
        /// <param name="volume">double volume</param>
        /// <returns>double coneHeight</returns>
        public static double ConeVolume(double volume)
        {
            double coneHeight = Math.Pow((12 * volume) / (Math.PI), (1.00 / 3.00));
            double coneRadius = (coneHeight / 2.00); // radius = .5 height, diameter = height 
            Console.WriteLine(" Cone:      {0:F}m in height, {1:F}m in radius,   {0:F} in diameter", coneHeight, coneRadius);
            return coneHeight;
        }

        /// <summary>
        /// Checks for a valid football score
        /// </summary>
        public static void CheckValidFootballScore()
        {
            Console.WriteLine("Please Enter a number to check to see if it is a valid American Football Score:\n" +
            "\nThis program will also return what types of scores may be contained within.\n");
            // parses the input string and converts to an int
            int input = int.Parse(Console.ReadLine());

            CheckValidScore(input);

        }

        /// <summary>
        /// Function to see if input score is a valid football score
        /// If it is, it will let you know if it is just a fieldgoal, touchdown,
        /// or contains an extra point or two point conversion
        /// </summary>
        /// <param name="input">int input</param>
        public static bool CheckValidScore(int input)
        {
            switch (input)
            {
                case 0:
                    {
                        // zero is a valid score
                        Console.WriteLine("Valid Football Score; {0} No points scored yet", input);
                        return true;
                       
                    }
                case 3:
                    {
                        // three means a field goal
                        Console.WriteLine("Valid Football Score: {0} Score contains a fieldgoal", input);
                        return true;
                        
                    }
                case 1:
                case 2:
                case 4:
                case 5:
                    {
                        // invalid scores
                        Console.WriteLine("Invalid Football Score : {0} ", input);
                        return false;
                    }
                default:
                    {
                        // contains a field goal or touchdown
                        if ((input % 6 == 0) || (input % 3 == 0))
                        {
                            Console.WriteLine("Valid Football Score: {0} Score contains touchdowns or fieldgoals", input);
                        }
                        // contains an extra point
                        else if ((input % 6 == 1) || (input % 3 == 1))
                        {
                            Console.WriteLine("Valid Football Score: {0} Score contains an extra point", input);
                        }
                        // contains extra points or a two point conversion
                        else if ((input % 6 == 2) || (input % 3 == 2))
                        {
                            Console.WriteLine("Valid Football Score: {0} Score could contain an extra point or two pt conversion", input);
                        }

                        return true;
                    }
            }
        }


    }



    #region " TEST CLASS "

    //We need to use a Data Annotation [ ] to declare that this class is a Test class
    [TestFixture]
    class Test
    {
        //Test classes are declared with a return type of void.  Test classes also need a data annotation to mark them as a Test function
        [Test]
        public void MyValidDimensionTest()
        {
           //inside of the test, we can declare any variables that we'll need to testThis is for the dimensions program.  
           // this one is for the dimension test
            double result = Program.CubeVolume(27);  // this function calls the cube function with a 27
            //now we test for the result.
            Assert.IsTrue(result == 3, "This is the message that displays if it does not pass");
          
        }
        [Test]
        public void MyValidFootballTest()
        {
            // The format is:
            // Assert.IsTrue(some boolean condition, "failure message");
            bool score = Program.CheckValidScore(7);  // this function calls the football score validater with a 7
            //now we test for the result.
            Assert.IsTrue(score == true, "This is the message that displays if it does not pass");

        }
        [Test]
        public void MyInvalidDimensionTest()
        {
            //  this is the false test case for the dimension program
            double result = Program.CubeVolume(27);
            //
            Assert.IsFalse(result == 4);
           
        }
        [Test]
        public void MyInvalidFootballTest()
        {
            
            // this is the false case for the football program 
            bool score = Program.CheckValidScore(4);
            //
            Assert.IsFalse(score == true);

        }

    }
    #endregion

}

   