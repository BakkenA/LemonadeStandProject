using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotionShop
{
    public class Player
    {
        public Wallet wallet;
        public Store store;
        public string name;
        public int manaJuice;
        public int healthJuice;
        public int lemons;
        public int sugar;
        public int bottles;
        public int quantity;
        public int recipeAmount;
        public int healthJuiceAmount;
        public int healthSugarAmount;
        public int manaJuiceAmount;
        public int manaSugarAmount;
        public int healthPotion;
        public int manaPotion;
        public int lemonade;
        public Player(string message)
        {
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
            wallet = new Wallet();
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
        public void SetHealthRecipe()
        {
            quantity = recipeAmount;
            Console.WriteLine("What should today's Health Potion Recipe be?\nHealth Potions require health concentrate, sugar, and bottles\nYou currently have:\n{0} health concentrate\n{1} sugar\n{2} bottles",healthJuice, sugar, bottles);
            Console.WriteLine("How much health concentrate do you want to use per batch today?");
            ChooseQuantity();
            if (recipeAmount <= healthJuice)
            {
                recipeAmount = healthJuiceAmount; 
            }
            else
            {
                Console.WriteLine("You don't have enough Health Concentrate to do that!\nChoose a different amount");
                ChooseQuantity();
            }
            Console.WriteLine("How much sugar do you want to use per batch today?");
            ChooseQuantity();
            if (recipeAmount <= sugar)
            {
                recipeAmount = healthSugarAmount;
            }
            else
            {
                Console.WriteLine("You don't have enough Health Concentrate to do that!\nChoose a different amount");
                ChooseQuantity();
            }
        }
        public void BrewHealthPotions()
        {
            ChooseQuantity();
            if (healthJuice >= healthJuiceAmount*quantity && sugar >= healthSugarAmount*quantity && bottles >= 1*quantity)
            {
                healthJuice -= 2*quantity;
                sugar -= 1*quantity;
                bottles -= 1*quantity;
                healthPotion = 1*quantity;
            }
            else
            {
                if(healthJuiceAmount*quantity > healthJuice)
                {
                    Console.WriteLine("Sorry you don't have enough health concentrate.");
                }
                if(healthSugarAmount*quantity > sugar)
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
        public void SetManaRecipe()
        {
            quantity = recipeAmount;
            Console.WriteLine("What should today's Mana Potion recipe be?\nMana Potions require health concentrate, sugar, and bottles\nYou currently have:\n{0} mana concentrate\n{1} sugar\n{2} bottles", manaJuice, sugar, bottles);
            Console.WriteLine("How much mana concentrate do you want to use per batch today?");
            ChooseQuantity();
            if (recipeAmount <= manaJuice)
            {
                recipeAmount = manaJuiceAmount;
            }
            else
            {
                Console.WriteLine("You don't have enough mana concentrate to do that!\nChoose a different amount");
                ChooseQuantity();
            }
            Console.WriteLine("How much sugar do you want to use per batch today?");
            ChooseQuantity();
            if (recipeAmount <= sugar)
            {
                recipeAmount = manaSugarAmount;
            }
            else
            {
                Console.WriteLine("You don't have enough sugar to do that!\nChoose a different amount");
                ChooseQuantity();
            }
        }
        public void BrewManaPotions()
        {
            ChooseQuantity();
            if (manaJuice >= manaJuiceAmount * quantity && sugar >= manaSugarAmount * quantity && bottles >= 1 * quantity)
            {
                manaJuice -= manaJuiceAmount * quantity;
                sugar -= manaSugarAmount * quantity;
                bottles -= 1 * quantity;
                manaPotion = 1 * quantity;
            }
            else
            {
                if (manaJuiceAmount * quantity > manaJuice)//Change all of these to this format ADAM!!!
                {
                    Console.WriteLine("Sorry you don't have enough mana concentrate.");
                }
                if (manaSugarAmount * quantity > sugar)
                {
                    Console.WriteLine("Sorry you don't have enough sugar.");
                }
                if (1 * quantity > bottles)
                {
                    Console.WriteLine("Sorry you don't have enough bottles for that.");
                }
            }
        }
        public void SetLemonadeRecipe()
        {
            quantity = recipeAmount;
            Console.WriteLine("Okay, you might not believe this, but lemonade is a little more complicated than Health Potions or Mana Potions.\nBut don't worry, it's not that hard.\nLemonade requires lemons, sugar and ice\nWe'll be using the same bottles that we use for Health Potions and Mana Potions");
            Console.WriteLine("You currently have");
            ChooseQuantity();
            if (recipeAmount <= manaJuice)
            {
                recipeAmount = manaJuiceAmount;
            }
            else
            {
                Console.WriteLine("You don't have enough mana concentrate to do that!\nChoose a different amount");
                ChooseQuantity();
            }
            Console.WriteLine("How much sugar do you want to use per batch today?");
            ChooseQuantity();
            if (recipeAmount <= sugar)
            {
                recipeAmount = manaSugarAmount;
            }
            else
            {
                Console.WriteLine("You don't have enough sugar to do that!\nChoose a different amount");
                ChooseQuantity();
            }
        }
        public void BrewLemonade()
        {
            ChooseQuantity();
            if (lemons >= 2 * quantity && sugar >= 3 * quantity && bottles >= 1 * quantity)
            {
                lemons -= 2 * quantity;
                sugar -= 1 * quantity;
                bottles -= 1 * quantity;
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
