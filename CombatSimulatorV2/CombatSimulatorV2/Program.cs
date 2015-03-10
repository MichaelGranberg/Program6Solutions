using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// object combat sim
namespace CombatSimulatorV2
{
    class Program
    {
        static void Main(string[] args)
        {
            // instance a new game and play it
            Game game = new Game();
            game.PlayGame();
        }
    }
    public class Game
    {
        //properties
        public  Player player { get; set;}
        public  Enemy enemy  { get; set;}
       /// <summary>
       /// sets up a new player and enemy
       /// </summary>
        public Game ()
        {
            // instance a new player and enemy
             this.player = new Player("HellBoy", 100);
             this.enemy = new Enemy("HellHound", 200);

        }
        /// <summary>
        /// displays player and enemy name and health points
        /// </summary>
        public void DisplayCombatInfo()
        {
            Console.WriteLine(" The player {0}   has {1} Health points left", player.Name, player.HP);
            Console.WriteLine(" The enemy  {0} has {1} Health points left", enemy.Name,  enemy.HP);
        }
       
         /// <summary>
         /// Logic to play game
         /// </summary>
  
         public void PlayGame()
         {
           // whileboth players are alive
           while (this.player.IsAlive && this.enemy.IsAlive)
            {
                
                DisplayCombatInfo();
               // player attacks enemy and then enemy attacks player
                this.player.DoAttack(this.enemy);
                this.enemy.DoAttack(this.player);
               
            }
             // logic to see if player is alive, then won or if not then enemy wins
            if (this.player.IsAlive)
            {
                Console.WriteLine( "You Won !!");
            }
            else
            {
                Console.WriteLine(" You Lost!!");
              }
            Console.ReadKey();
            }
    
        public class Actor
    {
         public static int trashing = 0;
       
        // Properties
        public string Name { get; set; }
        public int HP { get; set; }
        // sets property is alive if HP > 0
       // public bool IsAlive {get { return this.HP > 0; } }
        public bool IsAlive
        { 
            get
             {
                    if (HP > 0)
	                  { return true;}
		               
                       else { return false;}
        

              }     
 
        }
        public Random RNG { get; set; }

        // Constructors
        public Actor(string name, int hp)
        {
            this.Name = name;
            this.HP = hp;
            this.RNG = new Random();


        }
        // empty for Actor
        public virtual void DoAttack(Actor actor)
        {

        }
    }
    /// <summary>
    /// Class for Enemy inherits from Actor
    /// </summary>
    public class Enemy : Actor
    {
        
        // properties - could be empty
        public Enemy(string name, int hp) :base(name, hp)
        {
            this.HP= hp;

        }
        /// <summary>
        /// Logic for the enemy to attack player
        /// </summary>
        /// <param name="player">parameter for player</param>
        public override void DoAttack(Actor player)
        {

            //
            base.DoAttack(player);
            //
            if (RNG.Next(1, 11) < 9)
            {
                // it's a hit, determine the damage
                trashing = RNG.Next(10, 16);

                Console.WriteLine(" The Hellhound slimed you for: {0} HP\n", trashing);
                // subtracts HP from player
                player.HP -= trashing;
            }
            else
            {
                Console.WriteLine(" The slime flies by, missing you completely\n");
            }

        }
    
    }
    /// <summary>
    /// Clas for player, inherits from enemy 
    /// </summary>
    public class Player : Actor
    {
       
        // variables used in Player
        private  int healing = 0;
        private string attackType = String.Empty;
        private  int cigarsSmoked = 0;
        private  bool sixcigar = true;
        

        /// <summary>
        /// Enum for Attack Type
        /// </summary>
        public enum AttackType
            {
            AttackWithFists =1,
            SmokeACigar,
            EatACat,
            UseLighter,
            Default
            
            
            }

        // properties 
        public Player (string name, int hp) :base(name, hp)
        {
          this.HP= hp;
        }
        /// <summary>
        /// This is logic for player to attack enemy
        /// </summary>
        /// <param name="enemy">parameter for enemy attack</param>
        public override void DoAttack(Actor enemy)
        {
            //
            base.DoAttack(enemy);
            //
            // variable to hold value to compare AttackType to 
            AttackType attack = ChooseAttack();

            
        
        if ( attack == AttackType.AttackWithFists) 
        {
            // attack with Fists does 20-35 damage, but only 70% of time
            if (RNG.Next(1, 11) < 8)
            {
                // it's a hit, determine the damage
                trashing = RNG.Next(20, 36);
                Console.WriteLine(" You punched the Hellhound for: {0} HP", trashing);
                enemy.HP -= trashing;
            }
            else
            {
                // if miss
                Console.WriteLine(" Sloppy Punch, you missed completely");
            }
        }
       
        else if ( attack == AttackType.SmokeACigar)
        {
            // smoke a Cigar always does 10-15 damage
            
            trashing = RNG.Next(10, 16);
            Console.WriteLine(" You blew smoke in the hellhound's face for: {0} HP", trashing);
            enemy.HP -= trashing;
            // add 1 to the cigars smoked counter
            cigarsSmoked ++;
        }
       
        else if (attack == AttackType.EatACat)
        {
            // eat a cat restores Hellboys health by 10-15 heal

           healing = RNG.Next(10, 16);
            Console.WriteLine(" You ate a cat for: {0} HP", healing);
            this.HP += healing;
        }
       
        else if (attack == AttackType.UseLighter)
        {
            // use a lighter does 45-60 damage,  80% of time
            if (RNG.Next(1, 11) < 9)
            {
                // it's a hit, determine the damage
                trashing = RNG.Next(45, 61);
                Console.WriteLine(" You torched the demon for: {0} HP", trashing);
                enemy.HP-= trashing;
            }
            else
            {
                Console.WriteLine(" Whoa Cowboy don't burn yourself, you missed completely");
            }
        }
        }
        /// <summary>
        /// function for choosing attack
        /// </summary>
        /// <returns>Attack Type</returns>
        public AttackType ChooseAttack()
        {   // calls attack choice display
            DisplayHellboyAttackChoice();
            // allows player to input choice
            string attackInput = Console.ReadLine();
            Console.Clear();
         
                // logic to determine which enum gets returned
                if (cigarsSmoked < 6)
                {
                    if (attackInput == "1") { return AttackType.AttackWithFists; }
                    if (attackInput == "2") { return AttackType.SmokeACigar; }
                    if (attackInput == "3") { return AttackType.EatACat; }
                    else { return AttackType.Default; }

                }
                else
                {
                    if (attackInput == "1") { return AttackType.AttackWithFists; }
                    if (attackInput == "2") { return AttackType.SmokeACigar; }
                    if (attackInput == "3") { return AttackType.EatACat; }
                    if (attackInput == "4") { return AttackType.UseLighter; }
                    else { return AttackType.Default; }
                }


                

          
        }
        /// <summary>
        /// function to determine which console choice gets displayed
        /// 
        /// </summary>
        public void DisplayHellboyAttackChoice()
        {
            // displays options if less than 6 cigars smoked
            if (cigarsSmoked < 6)
            {
                Console.WriteLine(" Below are a list of options that you can use when fighting the demon\n");
                Console.WriteLine(" 1. Fists \n" + " 2. Blow Cigar Smoke \n" + " 3. Eat a Cat \n");
                Console.WriteLine(" Okay, Make your choice wisely");
            }
            //if 6 cigars smoke
            else if (cigarsSmoked == 6)
            {
                // fist time - display extra message
                if (sixcigar)
                {
                    Console.WriteLine(" Congratulations, you smoked 6 cigars and have earned a new weapon,\n" +
                        "a lighter that doubles as a flamethrower, you da boss!!!\n");
                    // set first time to false
                    sixcigar = false;
                }
                Console.WriteLine(" Below are a list of options that you can use when fighting the demon\n");
                Console.WriteLine(" 1. Fists \n" + " 2. Blow Cigar Smoke \n" + " 3. Eat a Cat \n" + " 4. Use Flamethrower\n");
                Console.WriteLine(" Okay, Make your choice wisely");

            }
            // more than 6 cigars
            else
            {
                Console.WriteLine(" Below are a list of options that you can use when fighting the demon\n");
                Console.WriteLine(" 1. Fists \n" + " 2. Blow Cigar Smoke \n" + " 3. Eat a Cat \n" + " 4. Use Flamethrower\n");
                Console.WriteLine(" Okay, Make your choice wisely");
            }

        }

    }
    }

} 



