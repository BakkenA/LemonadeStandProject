using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotionShop
{
    public class Player
    {
        
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
        public Player()
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
            this.name = NamePlayer();
        }
        public string NamePlayer()
        {
            name = Console.ReadLine();
            return name;
        }

        //public void Purchasing()
        //{
        //
        //}
        public int ChooseQuantity()
        {
            int quantity;
            bool exit = false;
            while (!exit)
            {
                if (Int32.TryParse(Console.ReadLine(), out quantity))
                {
                    return quantity;
                }
                else
                {
                    Console.WriteLine("INVALID QUANTITY\nPlease try again.");
                }
            }
            return -1;
        }
        public void BrewHealthPotions()
        {
            if(healthJuice >= 2*quantity && sugar >= 1*quantity && bottles >= 1*quantity)
            {
                healthJuice =- 2*quantity;
                sugar =- 1*quantity;
                bottles =- 1*quantity;
                healthPotion = 1*quantity;
            }
            else
            {
                if(2*quantity/healthJuice < 1)
                {
                    Console.WriteLine("Sorry you don't have enough health concentrate.");
                }
                if(1*quantity/sugar < 1)
                {
                    Console.WriteLine("Sorry you don't have enough sugar.");
                }
                if(1*quantity/bottles < 1)
                {
                    Console.WriteLine("Sorry you don't have enough bottles for that.");
                }
            }
        }
        public void BrewManaPotions()
        {
            if (manaJuice >= 2 * quantity && sugar >= 3 * quantity && bottles >= 1 * quantity)
            {
                manaJuice = -2 * quantity;
                sugar = -1 * quantity;
                bottles = -1 * quantity;
                manaPotion = 1 * quantity;
            }
            else
            {
                if (2 * quantity / healthJuice < 1)
                {
                    Console.WriteLine("Sorry you don't have enough mana concentrate.");
                }
                if (1 * quantity / sugar < 1)
                {
                    Console.WriteLine("Sorry you don't have enough sugar.");
                }
                if (1 * quantity / bottles < 1)
                {
                    Console.WriteLine("Sorry you don't have enough bottles for that.");
                }
            }
        }
        public void BrewLemonade()
        {
            if (lemons >= 2 * quantity && sugar >= 3 * quantity && bottles >= 1 * quantity)
            {
                lemons = -2 * quantity;
                sugar = -1 * quantity;
                bottles = -1 * quantity;
                lemonade = 6 * quantity;
            }
            else
            {
                if (2 * quantity / lemons < 1)
                {
                    Console.WriteLine("Sorry you don't have enough lemons.");
                }
                if (3 * quantity / sugar < 1)
                {
                    Console.WriteLine("Sorry you don't have enough sugar.");
                }
                if (1 * quantity / bottles < 1)
                {
                    Console.WriteLine("Sorry you don't have enough bottles for that.");
                }
            }
        }
    }
}
