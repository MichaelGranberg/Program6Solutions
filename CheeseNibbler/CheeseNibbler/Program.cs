using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheeseNibbler
{
    class Program
    {
        static void Main(string[] args)
        {
            CheeseNibbler game = new CheeseNibbler();
            game.PlayGame();
        }
    }


    public class Point
    {
        public enum PointStatus
        {

            Empty = 1,
            Cheese,
            Mouse
        }
        public int X { get; set; }
        public int Y { get; set; }
        public PointStatus Status { get; set; }
        public Point(int x, int y)
        {
            this.X = x; this.Y = y; this.Status = PointStatus.Empty;
        }

    }
    public class CheeseNibbler
    {
        public int Round { get; set; }
        public Point Mouse { get; set; }
        public Point Cheese { get; set; }
        public Point[,] Grid { get; set; }
        public Random RNG { get; set; }


        public CheeseNibbler()
        {
            // initializing the grid array
            // Point[,] Grid  = new Point[10, 10];
            this.Grid = new Point[10, 10];
            // initialize the round
            this.Round = 1;
            // 
            Random RNG = new Random();



            //loop through every x/y value in the grid
            for (int y = 0; y < 10; y++)
            {
                //for each row 
                for (int x = 0; x < 10; x++)
                {
                    //setting a new point into each coordinate of the grid,
                    // uses Point class constructor to set to Empty
                    this.Grid[x, y] = new Point(x, y);
                }
            }
            // this.mouse = Grid
            // generating the mouse values 
            int mouseX = RNG.Next(0, 10);
            int mouseY = RNG.Next(0, 10);
            // placing the mouse
            this.Grid[mouseX, mouseY].Status = Point.PointStatus.Mouse;
            this.Mouse = this.Grid[mouseX, mouseY];
            // another way to do status
            // this.Mouse.Status = Point.PointStatus.Mouse;

            // generating the cheese values
            //   int cheeseX = RNG.Next(0, 10);
            //   int cheeseY = RNG.Next(0, 10);

            // if they are both on the same point
            //   if (mouseX  == cheeseX &&  mouseY == cheeseY)
            //   { 
            //       // redo the generator
            //        cheeseX = RNG.Next(0, 10);
            //        cheeseY = RNG.Next(0, 10);
            //   }
            //   else
            //   {
            //       // set the status and store the cheese
            //        this.Grid[cheeseX, cheeseY].Status = Point.PointStatus.Cheese;
            //        this.Cheese = this.Grid[cheeseX, cheeseY];

            //   }  
            // new logic to keep looking
            do
            {
                this.Cheese = Grid[RNG.Next(0, 10), RNG.Next(0, 10)];

            } while (this.Cheese.Status != Point.PointStatus.Empty);
            this.Cheese.Status = Point.PointStatus.Cheese;
        }
        public void PlayGame()
        {
            // cheese found is our end ganme condition
            bool foundCheese = false;
            // ply game while cheese not found
            while (!foundCheese)
            {
                // draw the grid
                this.DrawGrid();
                // actually move the mouse and determine if game is over
                foundCheese = this.MoveMouse(this.GetUserMove());
                // add to round
                this.Round++;

            }
            Console.WriteLine(" You found the cheese in {0} rounds", this.Round);


            Console.ReadKey();

        }
        void DrawGrid()
        {
            Console.Clear();
            // for (int y = 0; y < this.Grid.GetLength(1); y++) - will expand and contract for any grid size
            for (int y = 0; y < 10; y++)
            {
                //for each row 
                // for (int x; x < this.Grid.GetLength(0); x++) - goes with above 
                for (int x = 0; x < 10; x++)
                {
                    switch (this.Grid[x, y].Status)
                    {
                        // found an Empty
                        case Point.PointStatus.Empty: Console.Write("[ ]");
                            break;
                        // found a Cheese
                        case Point.PointStatus.Cheese: Console.Write("[C]");
                            break;
                        // found a Mouse
                        case Point.PointStatus.Mouse: Console.Write("[M]");
                            break;
                        // default put a space
                        default:
                            Console.Write("[ ]");
                            break;
                    }


                }
                // create a new line at the end 
                Console.WriteLine();
            }

        }
        public ConsoleKey GetUserMove()
        {
            // keeps the actual key pressed out of the console(true)
            ConsoleKeyInfo userInput = Console.ReadKey(true);

            // check for valid input
            switch (userInput.Key)
            {
                case ConsoleKey.LeftArrow:

                    break;
                case ConsoleKey.RightArrow:

                    break;
                case ConsoleKey.UpArrow:

                    break;
                case ConsoleKey.DownArrow:

                    break;
                default:
                    // tell user is invalid key
                    Console.WriteLine("Not a valid move, dude");
                    break;
            }
            // return the key
            return userInput.Key;
        }
        /// <summary>
        /// Fuction is to see if the next move is on the grid
        /// </summary>
        /// <param name="input">Input from user</param>
        /// <returns>bool</returns>
        public bool ValidMove(ConsoleKey input)
        {

            switch (input)
            {
                // are we within the bounds of the grid ?
                case ConsoleKey.LeftArrow:
                    return this.Mouse.X > 0;
                case ConsoleKey.RightArrow:
                    return this.Mouse.X < 9;
                case ConsoleKey.UpArrow:
                    return this.Mouse.Y > 0;
                case ConsoleKey.DownArrow:
                    return this.Mouse.Y < 9;
            }
            // out of range 
            Console.WriteLine("Out of Range");

            return false;
        }
        /// <summary>
        /// Changes the value of where the mouse is 
        /// </summary>
        /// <param name="input">input</param>
        /// <returns>bool</returns>
        public bool MoveMouse(ConsoleKey input)
        {
            if (ValidMove(input))
            {
                // current x,y of the mouse
                int mouseMoveX = this.Mouse.X;
                int mouseMoveY = this.Mouse.Y;

                switch (input)
                {
                    case ConsoleKey.LeftArrow:
                        mouseMoveX--;
                        break;

                    case ConsoleKey.RightArrow:
                        mouseMoveX++;
                        break;

                    case ConsoleKey.UpArrow:
                        mouseMoveY--;
                        break;

                    case ConsoleKey.DownArrow:
                        mouseMoveY++;
                        break;

                    default:
                        break;

                }
                // get the point form the grid for the new position
                Point newMousePosition = this.Grid[mouseMoveX, mouseMoveY];
                // check to see if it is a cheese
                if (newMousePosition.Status == Point.PointStatus.Cheese)
                {
                    // cheese
                    //this.Mouse.Status = Point.PointStatus.Empty;
                    // this.Mouse = newMousePosition;
                    // this.Mouse.Status = Point.PointStatus.Mouse;
                    return true;
                }
                else
                {
                    // must be an empty space
                    // before we move 
                    // clearing the old status
                    this.Mouse.Status = Point.PointStatus.Empty;
                    // set the new position to the type mouse
                    this.Mouse = newMousePosition;
                    // update the property to have the x,y values
                    this.Mouse.Status = Point.PointStatus.Mouse;
                    return false;
                }



            }
            // out of range 
            Console.WriteLine("Out of Range");

            return false;

        }

    }
}
   

