using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatSimulator
{
    class Program
    {
        // variables used in the program
        public static Random rng = new Random();
        public static int hellBoyHP = 100;
        public static int hellHoundHP = 200;
        public static string hellBoyChoice = String.Empty;
        public static int trashing = 0;
        public static int healing = 0;
        public static int cigarsSmoked = 0;
        public static bool sixcigar = true;



        static void Main(string[] args)
        {
            //Let the user know the name of the game
            Console.WriteLine("\t\t\t\t Demon Slayer\n");
              
            // Welcome the user to the game using new line to save on console write lines
            Console.WriteLine(
            "\n In this game you will be Hellboy, fighting a Hellhound from another world.\n" +
            "\n You will have the choice of three weapons, including an option to heal Hellboy.\n" +
            "\n The first choice, his fist, does the most damage but works 70 % of the time." +
            "\n The second choice, his cigar, does less damage but always works." +
            "\n The third choice, eating cats, restores his health." +
            "\n There is a hidden choice that will show up when triggered correctly.\n" +
            "\n After you choose an option, Hellboy will attack the Hellhound, then the\n " +
            "Hellhound will attack Hellboy and the program will show you the results\n" +
            " of the attack.\n " +
            "\n When Hellboy or the Hellhound runs out of life points;\n" +
            " the game will let you know if Hellboy or the demon won. \n\n" +
            "\n Good Luck and remember the fate of the world rests on Hellboy's ability" + 
            "\n to defeat the demon.\t Hit any key to continue: ");
          //
            // continues the program
            Console.ReadKey();
            // clears the screens
            Console.Clear();
            //runs the main program
            CombatSimulator();

            
        }
        /// <summary>
        /// This function will have the main logic to control the game
        /// </summary>
        static void CombatSimulator()
        {
            
            // while both are alive         
            while (hellBoyHP > 0 && hellHoundHP > 0)
            {
                // call function to display healt
                GetHealthInfo();
                // call function to display attack choices
                DisplayHellboyAttackChoice();
                // call function validate choices
                GetHellboyAttackChoice();

                Console.Clear();

                if ( hellBoyChoice == "1")
                {
                    // call function to attack with fists
                    attackWithFists();
                }
                else if ( hellBoyChoice == "2" )
                {
                    // call function to blow smoke
                    smokeACigar();
                }
                else if ( hellBoyChoice == "3" )
                {
                    // call function to restore health
                    eatACat();
                }
                // checks to see if smoked 6 cigars 
                else if (cigarsSmoked >=6)
                {
                    // adds another choice to menu
                    if ( hellBoyChoice == "4")
                    {
                        // 4th menu choice, use lighter
                        useLighter();
                    }
                    else
                    {
                        // lose turn, invalid choice
                        Console.WriteLine(" You lose the turn, The demon attacks anyway!!");
                    }
                }
                else
                {
                    // lose turn invalid choice
                    Console.WriteLine(" You lose the turn, The demon attacks anyway!!");
                }                
                // calls function for hell hound attack
                GetHellhoundAttack();

            }
            // gets executed if both are not alive
            // hellboy alive
            if (hellBoyHP > 0)
            {
                Console.WriteLine("Congratulations, you kicked his butt back to Hell,\n" +
                    "and he'll think twice before he slithers back\n");
            }
            // heelhound alive
            else if (hellHoundHP > 0)
            {
                Console.WriteLine("You failed Earth, the demon won,\n" +
                    "and now we're all living in fear");
            }
            // both dead
            else
            {
                Console.WriteLine("You're both dead, Earth is safe, but we need another hero");
            }
            Console.ReadKey();
        }
        /// <summary>
        /// Function to display health points
        /// </summary>
        static void GetHealthInfo()
        {
            Console.WriteLine("HellBoy   HP: {0}", hellBoyHP);
            Console.WriteLine("HellHound HP: {0}\n", hellHoundHP);
       }
        /// <summmary>Function to display hellboy's choices</summmary>
        /// </summary>
        static void DisplayHellboyAttackChoice()
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
        /// <summary>
        /// Validates attack choice
        /// </summary>
        /// <returns>string with numeric value</returns>
        static string GetHellboyAttackChoice()
        {
            // get Hellboy's attack of choice
            hellBoyChoice = Console.ReadLine();
            // validates 3 menu choices if less than 6 cigars
            if (cigarsSmoked < 6)
            { 
                 if (hellBoyChoice == "1" || hellBoyChoice  == "2" || hellBoyChoice == "3")
                 {
                     return hellBoyChoice;
                 }
                 else
                 { 
                     hellBoyChoice = "5";
                     return hellBoyChoice;
                 }
            }
            // validates 4 menu choices if 6 or more cigars
            else
            {
                if (hellBoyChoice == "1" || hellBoyChoice == "2" || hellBoyChoice == "3" || hellBoyChoice == "4")
                {
                    return hellBoyChoice;
                }
                else
                {
                    hellBoyChoice = "5";
                    return hellBoyChoice;
                }
            }
        }
        /// <summary>
        /// Function to calculate damage for fist attack
        /// </summary>
        static void attackWithFists()
        {
            // attack with Fists does 20-35 damage, but only 70% of time
            if (rng.Next(1, 11) < 8)
            {
                // it's a hit, determine the damage
                trashing = rng.Next(20, 36);
                Console.WriteLine(" You punched the Hellhound for: {0} HP", trashing);
                hellHoundHP -= trashing;
            }
            else
            {
                // if miss
                Console.WriteLine(" Sloppy Punch, you missed completely");
            }
        }
        /// <summary>
        /// Function to calculate damage for blowing smoke attack
        /// </summary>
        static void smokeACigar()
        {
            // smoke a Cigar always does 10-15 damage
            
            trashing = rng.Next(10, 16);
            Console.WriteLine(" You blew smoke in the hellhound's face for: {0} HP", trashing);
            hellHoundHP -= trashing;
            // add 1 to the cigars smoked counter
            cigarsSmoked ++;
        }
        /// <summary>
        /// Function to determine additional health points for eating a cat
        /// </summary>
        static void eatACat()
        {
            // eat a cat restores Hellboys health by 10-15 heal

           healing = rng.Next(10, 16);
            Console.WriteLine(" You ate a cat for: {0} HP", healing);
            hellBoyHP += healing;
        }
        /// <summary>
        /// New Function after 6 cigars to use a lighter to torch Hellhound
        /// </summary>
        static void useLighter()
        {
            // use a lighter does 45-60 damage,  80% of time
            if (rng.Next(1, 11) < 9)
            {
                // it's a hit, determine the damage
                trashing = rng.Next(45, 61);
                Console.WriteLine(" You torched the demon for: {0} HP", trashing);
                hellHoundHP -= trashing;
            }
            else
            {
                Console.WriteLine(" Whoa Cowboy don't burn yourself, you missed completely");
            }
        }

        /// <summary>
        /// Function to claculate damage for Hellhounds attack
        /// </summary>
        static void GetHellhoundAttack()
        {
            // Hellhound attack does 10-15 damage, but only 80% of time
            if (rng.Next(1, 11) < 9)
            {
                // it's a hit, determine the damage
                trashing = rng.Next(10, 16);
                Console.WriteLine(" The Hellhound slimed you for: {0} HP\n", trashing);
                hellBoyHP -= trashing;
            }
            else
            {
                Console.WriteLine(" The slime flies by, missing you completely\n");
            }
        }

    }

}
