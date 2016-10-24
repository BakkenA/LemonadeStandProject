using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotionShop
{
    class PotionShop
    {
        public PotionShop()
        {
        }

        public void LaunchGame()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Welcome to Potion Shop!\nPlease choose one of the following:\nNEW GAME\nTUTORIAL");
                string menuChoice = Console.ReadLine().ToUpper();
                if (menuChoice == "NEW GAME")
                {
                    CreateGame();
                }
                else if (menuChoice == "TUTORIAL")
                {
                    RunTutorial();
                }
                else if (menuChoice == "666")
                {
                    Console.Clear();
                    RunHardMode();
                }
                else
                {
                    Console.WriteLine("Invalid choice, please choose again.");
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                }
            }
        }
        public void CreateGame()
        {

        }
        public void RunTutorial()
        {

        }
        public void RunHardMode()
        {
            if(Console.BackgroundColor == ConsoleColor.Black)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Clear();
                Console.WriteLine("HARD MODE ENGAGED!!!");
                LaunchGame();
            }
            else if (Console.BackgroundColor == ConsoleColor.Red)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Clear();
                Console.WriteLine("HARD MODE DISENGAGED!!!");
                LaunchGame();
            }
        }
    }
}
