using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotionShop
{
    public class Player
    {

        public Store store;
        public string name;
        public int manaJuice;
        public int healthJuice;
        public int lemons;
        public int sugar;
        public int bottles;
        public int money;
        public int quantity;
        public int healthPotion;
        public int manaPotion;
        public int lemonade;
        public Player(string message)
        {
            this.money = 200;
            this.manaJuice = 6;
            this.healthJuice = 6;
            this.lemons = 6;
            this.sugar = 6;
            this.bottles = 12;
            this.healthPotion = 0;
            this.manaPotion = 0;
            this.lemonade = 0;
            NamePlayer();
            Console.WriteLine(message);
            store = new Store();
        }
        public void NamePlayer()
        {
            name = Console.ReadLine();
        }
        public void ChooseQuantity()//ChooseQuantity works do not modify
        {
            int input;
            bool exit = false;
            while (!exit)
            {
                if (Int32.TryParse(Console.ReadLine(), out input))
                {
                    quantity = input;
                    exit = true;
                }
                else
                {
                    Console.WriteLine("INVALID QUANTITY\nPlease try again.");
                }
            }
        }
        public void BrewHealthPotions()
        {
            ChooseQuantity();
            if (healthJuice >= 2*quantity && sugar >= 1*quantity && bottles >= 1*quantity)
            {
                healthJuice -= 2*quantity;
                sugar -= 1*quantity;
                bottles -= 1*quantity;
                healthPotion = 1*quantity;
            }
            else
            {
                if(2*quantity > healthJuice)
                {
                    Console.WriteLine("Sorry you don't have enough health concentrate.");
                }
                if(1*quantity > sugar)
                {
                    Console.WriteLine("Sorry you don't have enough sugar.");
                }
                if(1*quantity > bottles)
                {
                    Console.WriteLine("Sorry you don't have enough bottles.");
                }
                Console.WriteLine("Choose a different quantity.");
                BrewHealthPotions();
            }
        }
        public void BrewManaPotions()
        {
            ChooseQuantity();
            if (manaJuice >= 2 * quantity && sugar >= 3 * quantity && bottles >= 1 * quantity)
            {
                manaJuice = -2 * quantity;
                sugar = -1 * quantity;
                bottles = -1 * quantity;
                manaPotion = 1 * quantity;
            }
            else
            {
                if (2 * quantity > manaJuice)//Change all of these to this format ADAM!!!
                {
                    Console.WriteLine("Sorry you don't have enough mana concentrate.");
                }
                if (1 * quantity > sugar)
                {
                    Console.WriteLine("Sorry you don't have enough sugar.");
                }
                if (1 * quantity > bottles)
                {
                    Console.WriteLine("Sorry you don't have enough bottles for that.");
                }
            }
        }
        public void BrewLemonade()
        {
            ChooseQuantity();
            if (lemons >= 2 * quantity && sugar >= 3 * quantity && bottles >= 1 * quantity)
            {
                lemons = -2 * quantity;
                sugar = -1 * quantity;
                bottles = -1 * quantity;
                lemonade = 6 * quantity;
            }
            else
            {
                if (2 * quantity > lemons)
                {
                    Console.WriteLine("Sorry you don't have enough lemons.");
                }
                if (3 * quantity > sugar)
                {
                    Console.WriteLine("Sorry you don't have enough sugar.");
                }
                if (1 * quantity > bottles)
                {
                    Console.WriteLine("Sorry you don't have enough bottles for that.");
                }
            }
        }
    }
}
