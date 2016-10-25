using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotionShop
{
    class PotionShop
    {
        Player player;
        Store store;
        Weather weather = new Weather();
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
                    Console.Clear();
                    CreateGame();
                }
                else if (menuChoice == "TUTORIAL")
                {
                    Console.Clear();
                    RunTutorial();
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
        public void CreateGame()
        {
            Console.WriteLine("Alright, I just need one more signature before your grand opening.\nJust sign your name here:");
            player = new Player();
            Console.WriteLine("Okay good.\nAnd before I leave, let me just make sure I have the name of your shop right.");
            store = new Store();
            Console.WriteLine("Very well then, {0}'s {1}.\nI do say it has a nice ring to it.\nBest of luck, I'll be back next week to check on your progress.\nUntil then...", player.name, store.name);
            Console.ReadLine();
            BeginGame();
        }
        public void RunTutorial()
        {
            Console.WriteLine("This is Potion Shop a game based on the 1979 Apple II classic Lemonade Stand.\nIn this game you are the proud proprietor of a new potion shop in the town of Pritzlaffburg.\nPritzlaffburg has a large population of adventurers.\nThese adventurers have created a large demand for health potions and mana potions.\nYour shop exists to satisfy that demand, and to make you rich in the process!\nAt the end of each day you'll be able to choose how to allocate your funds in order to operate the next day.\nAfter the first day you'll be able to stock your shelves as you see fit based on the materials you have.\nIt would be wise to take the day's forecast into account before choosing what to stock.\nYou have seven days to make the most money out of your initial inventory.\nGOOD LUCK!!!");
            Console.ReadLine();
            Console.Clear();
            LaunchGame();
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
        public void BeginGame()
        {
            store.BeginDay();
            CheckReport();
        }
        public void CheckReport()
        {
            int currentTemp = weather.SetTemp();
            string todaysClimate = weather.SetClimate(currentTemp);
            Console.Clear();
            Console.WriteLine("The weather is expected to be {0} today with a temperature of {1}.", todaysClimate, currentTemp );
            StockHealthPotion();
        }
        public void StockHealthPotion()
        {
            Console.WriteLine("How many health potions should be brewed today?");
            player.ChooseQuantity();
            StockManaPotion();
        }
        public void StockManaPotion()
        {
            Console.WriteLine("How many mana potions should be brewed today?");
            player.ChooseQuantity();
            StockLemonade();
        }
        public void StockLemonade()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Lemonade?");
                string reply = Console.ReadLine().ToUpper(); 
                if (reply == "YES")
                {
                    Console.WriteLine("Then let's make some LEMONADE!!!\nHow much lemonade should we make today?");
                    player.ChooseQuantity();
                    RunDay();
                }
                else if (reply == "NO")
                {
                    Console.WriteLine("Well I hope nobody gets too thirsty, maybe keep some on display next to the register?");
                    RunDay();
                }
                else if (reply == "MAYBE")
                {
                    Console.WriteLine("YES OR NO");
                }
                else
                {
                    Console.WriteLine("I meant do you want to make any lemonade today.\nYes or No?");
                }
            }
        }
        public void RunDay()
        {
            store.CheckDay();
            BeginGame();
        }
        public void EndWeek()
        {

        }
    }
}
