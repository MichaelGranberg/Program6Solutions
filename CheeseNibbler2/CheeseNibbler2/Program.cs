using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheeseNibbler2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool keepPlaying = true;
          
                while (keepPlaying)
                {
                    new CheeseNibbler().PlayGame();
                    Console.WriteLine("Would You like to Play Again?");
                    string input = Console.ReadLine();
                    keepPlaying = (input.ToLower() == "y");
                }
                

                
            }
         
        }
    }
/// <summary>
/// Class Structure for Point
/// </summary>
    public class Point
    {
        public enum PointStatus
        {

            Empty = 1,
            Cheese,
            Mouse,
            Cat,
            CatAndCheese,
            MouseHole
        }
        //properties for point
        public int X { get; set; }
        public int Y { get; set; }
        public PointStatus Status { get; set; }
        // init properties
        public Point(int x, int y)
        {
            this.X = x; this.Y = y; this.Status = PointStatus.Empty;
        }

    }
/// <summary>
/// Class Structure for Mouse
/// </summary>
    public class Mouse
    {
        // properties for mouse
        public Point Position  { get; set; }
        public int Energy { get; set;}
        public bool HasBeenPounceOn { get; set; }
        // constructor for mouse
        public Mouse()
        {
            this.Energy = 50;
        }
        // method for mouse
        public void EatCheese()
        {
            this.Energy += 10;
        }

    } 
    // Class Structure for Cat
    public class Cat
    {
        // property for Cat
        public Point Position { get; set;}
        // empty constructor
       public Cat()
    {

    }}

    
    // Class for CheeseNibbler
    public class CheeseNibbler
    {
        // Properties for CheeseNibbler
    
        public Point[,] Grid { get; set; }
        public Point Cheese { get; set; }
        public Mouse Mouse { get; set; }
        
        public int CheeseCount {get; set;}
        public List<Cat> Cats { get; set; }
        
    
        public Random RNG { get; set; }

        

        // Constructor for CheeseNibbler
        public CheeseNibbler()
        
        {
            // initializing the grid array
            this.Grid = new Point[10, 10];
            // new instance of Cats List
            this.Cats = new List<Cat>();          
            // new instance of Mouse
            this.Mouse = new Mouse();
            // new random number generator
            this.RNG = new Random();


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

            // generating the mouse values  and placing it
            this.Mouse.Position = this.Grid[RNG.Next(0, 10), RNG.Next(0, 10)];
            //Method to place cheese
            PlaceCheese();
        }
        /// <summary>
        /// This will place the cheese
        /// </summary>
        void PlaceCheese()
        { 
            
            // new logic to keep looking
            do
            {
                this.Cheese = Grid[RNG.Next(0, 10), RNG.Next(0, 10)];

            } while (this.Cheese.Status != Point.PointStatus.Empty);
            this.Cheese.Status = Point.PointStatus.Cheese;

         }
        /// <summary>
        /// This method plays the game
        /// </summary>
         public void PlayGame()
         {
            //  mouse alive (has energy) and not been pounced on
             while (this.Mouse.Energy > 0 && !this.Mouse.HasBeenPounceOn)
             {
                 // draw the grid
                 this.DrawGrid();
                 // actually move the mouse and determine if game is over
                 this.MoveMouse(this.GetUserMove());
                 // move cats
                 foreach (Cat cat in this.Cats)
                 {
                     MoveCat(cat);
                 }

             }
             DrawGrid();
             // checks to see if mouse has been pounced on
             if (Mouse.HasBeenPounceOn)
             {
                 Console.WriteLine(" Youn died a heinous death !!!");
             }
             // display when done 
             Console.WriteLine("You big cheeseeater, you ate {0} cheeses", CheeseCount);
             Console.ReadKey();

         }  
         // method to Drawthe grid
         void DrawGrid()
        {
             // clear the screen
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
                       
                        // found a Cheese
                        case Point.PointStatus.Cheese: Console.Write("[C]");
                            break;
                        // found a Mouse
                        case Point.PointStatus.Mouse: Console.Write("[M]");
                            break;
                        // found a Cat
                        case Point.PointStatus.Cat:   Console.Write("[X]");
                            break;
                        // found a Cat and Cheese
                        case Point.PointStatus.CatAndCheese: Console.Write("[K]");
                            break;
                        default: // found an Empty
                                  Console.Write("[ ]");
                            break;
                    }
                    
                }
                // create a new line at the end 
                Console.WriteLine();

            }
            Console.WriteLine("you have {0} energy left", this.Mouse.Energy);
        }
        // Method to Get User Move
         public ConsoleKey GetUserMove()
         {
             // keeps the actual key pressed out of the console(true)
             ConsoleKeyInfo userInput = Console.ReadKey();

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
        /// Method is to see if the next move is on the grid
        /// </summary>
        /// <param name="input">Input from user</param>
        /// <returns>bool</returns>
        public bool ValidMouseMove(ConsoleKey input)
        {
            //initialize the x,y variables
            int mouseX = this.Mouse.Position.X;
            int mouseY = this.Mouse.Position.Y;
        // makes sure mouse is on the grid
            switch (input)
            {
                // are we within the bounds of the grid ?
                case ConsoleKey.LeftArrow: 
                    return this.Mouse.Position.X > 0;
                case ConsoleKey.RightArrow:
                    return this.Mouse.Position.X < 9;
                case ConsoleKey.UpArrow:
                    return this.Mouse.Position.Y > 0;
                case ConsoleKey.DownArrow:
                    return this.Mouse.Position.Y < 9;
                
                
            }
            // out of range 
            Console.WriteLine("Out of Range");
            return false;
        }

       
        // Method to Move Mouse
        public void MoveMouse(ConsoleKey input)
        {
            if (ValidMouseMove(input))
            {
                //decrease energy
                this.Mouse.Energy--;

                // current x,y of the mouse
                int mouseMoveX = this.Mouse.Position.X;
                int mouseMoveY = this.Mouse.Position.Y;
                // moves mouse in direction of arrows pressed
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
                   
                    // doesn't move
                    default:
                        break;

                }
                // get the point from the grid for the new position
                Point newMousePosition = this.Grid[mouseMoveX, mouseMoveY];
                // check to see if it is a cheese
                if (newMousePosition.Status == Point.PointStatus.Cheese)
                {
                    //mouse got cheese, update cheese counter
                    this.CheeseCount++;
                    // gives energy
                    this.Mouse.EatCheese();
                    // replace cheese
                    PlaceCheese();
                    // check to add a new cat
                    // two cheeses down add cat
                    if (this.CheeseCount % 2 == 0)
                    {
                        // add new cat
                        AddCat();
                    }
                    // new mouse position
                    newMousePosition.Status = Point.PointStatus.Mouse;
                }
                else if (newMousePosition.Status  == Point.PointStatus.Mouse)
                {
                    
                    // update the property to have the x,y values
                    this.Mouse.HasBeenPounceOn = true;
                    newMousePosition.Status = Point.PointStatus.Cat;
                }
                else 
                { 
                    newMousePosition.Status = Point.PointStatus.Mouse; 
                } 
 
 
                //move the mouse 
                this.Mouse.Position.Status = Point.PointStatus.Empty; 
                this.Mouse.Position = newMousePosition; 

            }
            // out of range 
            Console.WriteLine("Out of Range");

        
        }
        // Method to add a cat
        void AddCat()
        {
            // new instance of Cat
            Cat newCat = new Cat();
            // place the cat
            PlaceCat(newCat);
            // add a cat to the list
            this.Cats.Add(newCat);
            

        }
        void DeleteCat()
        {

                     
        }
        // Method to place a cat
        void PlaceCat(Cat cat)
        {
            
            
            bool placeCat = false;
            while (!placeCat)
            {
                // new logic to keep looking for a place to put the cat

                Point point = this.Grid[RNG.Next(0, 10), RNG.Next(0, 10)];
                placeCat = true;

                point.Status = Point.PointStatus.Cat;
                cat.Position = point;
            }
        }
        void MoveCat(Cat cat)
        {
            // 80% chance to move
            if (RNG.Next(11) > 2)
            {
                // variables 
                int x = this.Mouse.Position.X - cat.Position.X; 
                int y = this.Mouse.Position.Y - cat.Position.Y; 
                bool validMove = false; 
                Point targetPosition = cat.Position; 
                bool tryLeft = (x < 0); 
                bool tryRight = (x > 0); 
                bool tryUp = (y < 0); 
                bool tryDown = (y > 0); 

 
                while (!validMove && (tryLeft || tryRight || tryUp || tryDown)) 
                { 
                    int targetX = cat.Position.X; 
                    int targetY = cat.Position.Y;


                    if (tryLeft)
                    {
                        targetPosition = Grid[--targetX, targetY];
                        tryLeft = false;
                    }
                    else if (tryRight)
                    {
                        targetPosition = Grid[++targetX, targetY];
                        tryRight = false;
                    }
                    else if (tryUp)
                    {
                        targetPosition = Grid[targetX, --targetY];
                        tryUp = false;
                    } 
                    else if (tryDown)
                    {
                        targetPosition = Grid[targetX, ++targetY];
                        tryDown = false;
                    }
                   // check to see if valid cat move
                   validMove = IsValidCatMove(targetPosition); 
                   } 
                   //
                       
                  if (cat.Position.Status == Point.PointStatus.CatAndCheese) 
                  { 
                   cat.Position.Status = Point.PointStatus.Cheese; 
                  }  
                  else 
                  { 
                    cat.Position.Status = Point.PointStatus.Empty; 
                  } 
                  // if target location has a mouse 
                  if (targetPosition.Status == Point.PointStatus.Mouse) 
                  { 
                      // and has been pounced on, make it a cat
                     this.Mouse.HasBeenPounceOn = true; 
                     targetPosition.Status = Point.PointStatus.Cat; 
                   } 
                   // if it's a cheese turn it into cat and cheese
                   else if (targetPosition.Status == Point.PointStatus.Cheese) 
                   { 
                   targetPosition.Status = Point.PointStatus.CatAndCheese;
                   //DeleteCat();
                   } 
                   // otherwise, it's just  
                   else 
                   { 
                   targetPosition.Status = Point.PointStatus.Cat; 
                   } 
             cat.Position = targetPosition; 
             } 
         } 
         private bool IsValidCatMove(Point targetPosition) 
         { 
            return (targetPosition.Status == Point.PointStatus.Empty || targetPosition.Status == Point.PointStatus.Mouse); 
         } 
    } 


        

    


