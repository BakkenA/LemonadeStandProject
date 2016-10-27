using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotionShop
{
    class Game
    {
        Day day;
        Player player;
        string nameMessage = "Alright, I just need one more signature before your grand opening.\nJust sign your name here:";
        string playerstoreMessage = "Okay good.\nAnd before I leave, let me just make sure I have the name of your shop right.";

        public Game()
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
                    Console.Clear();
                    CreateGame();
                }
                else if (menuChoice == "TUTORIAL")
                {
                    Console.Clear();
                    RunTutorial();
                }
                else if (menuChoice == "HINT")
                {
                    Console.Clear();
                    DisplayHint();
                }
                else if (menuChoice == "666")
                {
                    Console.Clear();
                    RunHardMode();
                }
                else if (menuChoice == "REPENT")
                {
                    Console.Clear();
                    RunHardMode();
                }
                else
                {
                    Console.WriteLine("Invalid choice, please choose again.");
                    Console.Clear();
                }
            }
        }
        //CreateGame is working, don't touch this either
        public void CreateGame()
        {
            Console.WriteLine(nameMessage);
            day.player = new Player(playerstoreMessage);
            Console.WriteLine("Very well then, {0}'s {1}.\nDoes that sound right to you?", player.name, player.store.name);
            string response = Console.ReadLine().ToUpper();
            if (response == "YES")
            {
                Console.WriteLine("Fantastic, {0}'s {1}!\nDare it if I may say so myself, but it does have a certain ring to it, doesn't it?.\nAh well..\nBest of luck to you, I'll be back next week to check on your progress.", player.name, player.store.name);
                Console.ReadLine();
                day.BeginGame();
            }
            else if (response == "NO")
            {
                nameMessage = ("Your name again?");
                playerstoreMessage = ("And the name of your player.store?");
                CreateGame();
            }
            else
            {
                Console.WriteLine("It was a yes or no question.");
                nameMessage = ("What is your NAME?");
                playerstoreMessage = ("And what do you want to call your player.store?");
                CreateGame();
            }
        }
        public void RunTutorial()
        {
            Console.WriteLine("This is Potion Shop a game based on the 1979 Apple II classic Lemonade Stand.\nIn this game you are the proud proprietor of a new potion shop in the town of Pritzlaffburg.\nPritzlaffburg has a large population of adventurers.\nThese adventurers have created a large demand for health potions and mana potions.\nYour shop exists to satisfy that demand, and to make you rich in the process!\nAt the end of each day you'll be able to choose how to allocate your funds in order to operate the next day.\nAfter the first day you'll be able to stock your shelves as you see fit based on the materials you have.\nIt would be wise to take the day's forecast into account before choosing what to stock.\nYou have seven days to make the most money out of your initial inventory.\nGOOD LUCK!!!");
            Console.ReadLine();
            Console.Clear();
            LaunchGame();
        }
        public void DisplayHint()
        {
            Console.WriteLine("When danger appears high, they want to buy...");
            Console.ReadLine();
            Console.Clear();
            LaunchGame();
        }
        public void RunHardMode()
        {
            if (Console.BackgroundColor == ConsoleColor.Black)
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
