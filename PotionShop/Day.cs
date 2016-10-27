using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotionShop
{
    public class Day
    {
        public Player player;
        Weather weather = new Weather();
        Market market = new Market();
        Customer customer;
        string nameMessage = "Alright, I just need one more signature before your grand opening.\nJust sign your name here:";
        string playerstoreMessage = "Okay good.\nAnd before I leave, let me just make sure I have the name of your shop right.";
        public Day()
        {
        }
        public void BeginGame()
        {
            player.store.BeginDay();
            CheckReport();
        }
        public void CheckReport()
        {
            Console.Clear();
            int currentTemp = weather.SetTemp();
            string todaysClimate = weather.SetClimate(currentTemp);
            int currentThreat = weather.danger.SetThreat();
            Console.WriteLine("The weather is expected to be {0} today with a temperature of {1}.", todaysClimate, currentTemp);
            StockHealthPotion();
        }
        public void StockHealthPotion()
        {
            Console.WriteLine("You have {0} health concentrate and {1} cups of sugar and {2} bottles.\nHow many health potions should be brewed today?", player.healthJuice, player.sugar, player.bottles);
            player.SetHealthRecipe();
            player.BrewHealthPotions();
            player.store.healthPotions = player.healthPotion;
            StockManaPotion();
        }
        public void StockManaPotion()
        { 
            Console.WriteLine("You have {0} mana concentrate, {1} cups of sugar and {2} bottles.\nHow many mana potions should be brewed today?", player.manaJuice, player.sugar, player.bottles);
            player.SetManaRecipe();
            player.BrewManaPotions();
            player.store.manaPotions = player.manaPotion;
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
                    player.store.lemonades = player.lemonade;
                    RunDay();
                }
                else if (reply == "NO")
                {
                    Console.WriteLine("Well I hope nobody gets too thirsty, maybe keep some on display next to the register?");
                    Console.ReadLine();
                    RunDay();
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
            CreateCustomers();
            BeginGame();
        }
        public void CreateCustomers()
        {
            if(weather.danger.currentThreat >= 10)
            {
                customer = new Warrior(player.store);
            }
            if(weather.danger.currentThreat >= 8 && weather.danger.currentThreat <= 17)
            {
                customer = new Mage(player.store);
            }
            if(weather.danger.currentThreat <= 10)
            {
                customer = new Peasant(player.store);
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
            Console.WriteLine("Good morning {0}! Well let's take a look at what you've managed to do since last I left you.\nLet's take a look at what you still have on your shelves:{1} health potions\n{2} mana potions\n{3} lemonades", player.name, player.store.healthPotions, player.store.manaPotions, player.store.lemonades);
            Console.ReadLine();
            Environment.Exit(0);
        }
    }
}
