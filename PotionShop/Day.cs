﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotionShop
{
    public class Day
    {
        public Game game;
        public Player player;
        public Weather weather = new Weather();
        public Market market = new Market();
        public Customer customer = new Customer();
        Peasant peasant;
        Warrior warrior;
        Mage mage;
        List<Peasant> peasants;
        public List<Warrior> warriors;
        public List<Mage> mages;
        public Day()
        {
            peasants = new List<Peasant>();
            warriors = new List<Warrior>();
            mages = new List<Mage>();
        }
        public void InitializeFirstDay()
        {
            market.CreateStartingStock();
            market.CheckMinPrice();
            StartDay();

        }//This should be done
        public void StartDay()
        {
            player.store.BeginDay();
            DisplayForecast();
        }
        public void DisplayForecast()
        {
            Console.Clear();
            int currentTemp = weather.SetTemp();
            string todaysClimate = weather.SetClimate(currentTemp);
            Console.WriteLine("The weather is expected to be {0} today with a temperature of {1}.", todaysClimate, currentTemp);
            int currentThreat = weather.danger.SetThreat();
            if (player.store.daysOpen == 1)
            {
                IntroductionToPenelope();
            }
            else if (player.store.daysOpen > 1)
            {
                BeginPlayerActions();
            }
        }
        public void IntroductionToPenelope()//This function will call to Player to set recipes and brew sellables variables
        {
            Console.WriteLine("\n\n\nHi {0}! I'm Penelope, Mr. Heidegger has sent me here to act as your personal assistant for your first week of operations.",player.name);
            Console.ReadLine();
            Console.WriteLine("Why are you looking at me like that?" +
            "\n\nI'm not here to spy on you!!!\nMr. Heidegger just thought you might need some help keeping track of things around here." +
            "You've got the big job of steering this ship Captain, just consider me your First-Mate!");
            BeginPlayerActions();       
        }
        public void BeginPlayerActions()
        {
            Console.WriteLine("\n\n\nOkay {0} we have ${1} available for us to make purchases with today. Do you want to go to Syndekia's?", player.name, player.wallet.currentMoney);
            Console.ReadLine();
        }
        public void StockHealthPotion()
        {
            Console.WriteLine("You have {0} health concentrate and {1} cups of sugar and {2} bottles.\nHow many health potions should be brewed today?", player.inventory.myHealths.Count(), player.inventory.mySugar.Count(), player.inventory.myBottles.Count());
            player.SetHealthPotionBatchSize();
            player.BrewHealthPotions();
            StockManaPotion();
        }
        public void StockManaPotion()
        {
            Console.WriteLine("You have {0} mana concentrate, {1} cups of sugar and {2} bottles.\nHow many mana potions should be brewed today?", player.inventory.myManas.Count(), player.inventory.mySugar.Count(), player.inventory.myBottles.Count());
            player.SetManaPotionBatchSize();
            player.BrewManaPotions();
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
                    Console.WriteLine("Then let's make some LEMONADE!!!");
                    player.SetLemonadeRecipe();
                    player.ChooseQuantity();
                    player.BrewLemonade();
                    player.store.lemonadeForSale = player.lemonade;
                    player.BuyIngredients(market);
                }
                else if (reply == "NO")
                {
                    Console.WriteLine("Well I hope nobody gets too thirsty, maybe keep some on display next to the register?");
                    Console.ReadLine();
                    player.BuyIngredients(market);
                }
                else if (reply == "MAYBE")
                {
                    Console.WriteLine("YES OR NO");
                }
                else
                {
                    Console.WriteLine("I meant, do you want to MAKE any LEMONADE today!\nYes or No?");
                }
            }
        }
        public void RunDay()
        {
            CheckDay();
            CreateMildCustomer();
            StartDay();
        }
        public void CreateMildCustomer()
        {
            int customerBase = 3;
            if (weather.danger.currentThreat <= 10)
            {
                for (int i = 0; i < weather.danger.currentThreat * customerBase; i++)
                {
                    peasant = new Peasant(player.store);
                    peasant.PurchaseLemonade();
                    warrior = new Warrior(player.store);
                    warrior.PurchaseLemonade();
                    mage = new Mage(player.store);
                    mage.PurchaseLemonade();
                }
            }
            else
            {
                CreateMediumCustomer();
            }
        }
        public void CreateMediumCustomer()
        {
            int customerBase = 3;
            if (weather.danger.currentThreat >= 10)
            {
                for (int i = 0; i < weather.danger.currentThreat * customerBase; i++)
                {
                    peasant = new Peasant(player.store);
                    peasant.PurchaseLemonade();
                    warrior = new Warrior(player.store);
                    warrior.PurchaseLemonade();
                    mage = new Mage(player.store);
                    mage.PurchaseLemonade();
                }
            }
            else
            {
                CreateHotCustomer();
            }
        }
        public void CreateHotCustomer()
        {
            int customerBase = 5;
            if (weather.danger.currentThreat >= 8 && weather.danger.currentThreat <= 17)
            {
                for (int i = 0; i < weather.danger.currentThreat * customerBase; i++)
                {
                    peasant = new Peasant(player.store);
                    peasant.PurchaseLemonade();
                    warrior = new Warrior(player.store);
                    warrior.PurchaseLemonade();
                    mage = new Mage(player.store);
                    mage.PurchaseLemonade();
                }
            }
            else
            {
                CheckFailStatus();
            }
        }
        public void CheckFailStatus()
        {
            if (player.wallet.currentMoney <= 0)
            {
                EndBadly();
            }
            else
            {
                CheckDay();
            }
        }
        public void CheckDay()
        {
            if (player.store.daysOpen == 7)
            {
                EndWeek();
            }
        }
        public void EndWeek()
        {
            Console.WriteLine("Good morning {0}! Well let's take a look at what you've managed to do since last I left you."+
            "\nLet's take a look at what you still have on your shelves:{1} health potions\n{2} mana potions\n{3} lemonades",player.name, player.store.healthPotionForSale, player.store.manaPotionForSale, player.store.lemonadeForSale);
            Console.ReadLine();
            Console.WriteLine("Let's see you have ${0} from your initial starting funds of ${1}.", player.wallet.currentMoney, player.wallet.startingMoney);
            if (player.wallet.currentMoney >= player.wallet.startingMoney * 2)
            {
                Console.WriteLine("WOW great work, you're quite the entrepeneur!");
                Console.ReadLine();
            }
            else if (player.wallet.currentMoney <= player.wallet.startingMoney * 2)
            {
                Console.WriteLine("Hmm, well I'm afraid you haven't met the projections you promised me. I'm sorry, but we can't allow you to continue this shop.\nI want you gone by the end of the day...");
                Console.ReadLine();
            }
            game.LaunchGame();
        }
        public void EndBadly()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("{0}'s {1} is bankrupt!!!\nYou failed to successfully navigate the entrepeneurial streets of Pritzlaffburg.\nNo one will ever remember {0}'s {1}."+
                "\nIn six months you find yourself directionless and alone and have made a grim decision.\nYour final thought, ''When life gives you lemons...''"+
                "\n\n\nPlease choose one of the following:\nNew Game\nExit", player.name, player.store.name);
                string menuChoice = Console.ReadLine().ToUpper();
                if (menuChoice == "NEW GAME")
                {
                    Console.Clear();
                    game.CreateGame();
                }
                else if (menuChoice == "EXIT")
                {
                    Console.Clear();
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Invalid choice, please choose again.");
                    Console.Clear();
                }
            }
        }
    }
}
