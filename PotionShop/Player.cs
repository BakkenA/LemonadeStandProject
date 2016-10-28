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
        public Market market;
        public Inventory inventory;
        public Day day;
        public string name;
        public int quantity;
        public double sellingPrice;
        public int recipeAmount;
        public int healthPotion;
        public int manaPotion;
        public int lemonade;
        public double lemonadePrice;
        public int lemonadeMade;
        int[] lemonadeRecipe = new[] { 0, 0, 0, 0 };
        

        public Player(string message)
        {
            this.healthPotion = 0;
            this.manaPotion = 0;
            this.lemonade = 0;
            NamePlayer();
            Console.WriteLine(message);
            store = new Store(this);
            wallet = new Wallet();
            inventory = new Inventory();
        }
        public void NamePlayer()
        {
            Console.Write("NAME:");
            name = Console.ReadLine();
        }
        public bool CheckFunds(double cost)
        {
            double cash = wallet.currentMoney;
            ChooseQuantity();
            if (cost * quantity <= cash)
            {
                return true;
            }
            else
            {
                Console.WriteLine("I'm sorry, but your card was declined...\nMaybe try selecting fewer items");
                Console.ReadLine();
                return false;
            }
        }
        public void BuyIngredients(Market market)
        {
            this.market = market;
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n\nWelcome to Sendykia's Grocery Store!\nWe have a wide variety to choose from, but you look like you're interested in some pretty specific items...\nHere's what we have for someone in your line of work:\nLemons\nSugar\nIce\nBottles\nHealth Concentrate\nMana Concentrate\nFertilizer\nPlastic");
                Console.Write("Just tell me what you want to buy, otherwise you can just LEAVE.");
                switch (Console.ReadLine().ToUpper())
                    {
                        case "LEMONS":
                            BuyLemons();
                            break;
                        case "SUGAR":
                            BuySugar();
                            break;
                        case "ICE":
                            BuyIce();
                            break;
                        case "BOTTLES":
                            BuyBottles();
                            break;
                        case "HEALTH CONCENTRATE":
                            BuyHealthConcentrate();
                            break;
                        case "MANA CONCENTRATE":
                            BuyManaConcentrate();
                            break;
                        case "FERTILIZER":
                            BuyBad();
                            break;
                        case "PLASTIC":
                            BuyBad();
                            break;
                        case "LEAVE":
                        Console.Clear();
                        exit = true;
                        SetLemonadeRecipe();
                            break;
                        default:
                            break;
                    }
              }
            SetLemonadeRecipe();
        }
        public void BuyLemons()
        {
            Console.WriteLine("We currently have {0} Lemons and they are going for ${1} a piece.", market.lemons.Count(), market.lemonCost);
            Console.Write("How many do you want?");
            if (CheckFunds(market.lemonCost) && market.lemons.Count() >= quantity)
            {
                //Lemon lemon = new Lemon(987);//This line was part of a deeper-dive into the philosophy of teleportation, if you're Mike, you'll know what this is, if you're not, ask Mike.
                for (int i = 0; i < quantity; i++)
                {
                    //market.lemons.Add(lemon);
                    inventory.myLemons.Add(market.lemons[0]);
                    market.lemons.RemoveAt(0);
                }
             }
            else if(market.lemons.Count() < quantity)
            {
                Console.WriteLine("Hey, I checked in the back, we don't have that many.");
                BuyLemons();
            }
            else if (!CheckFunds(market.lemonCost))
            {
                BuyLemons();
            }
        }
        public void BuySugar()
        {
            Console.WriteLine("We currently have {0} units of sugar that we are selling for ${1} per unit.", market.sugars.Count(), market.sugarCost);
            Console.Write("How many do you want?");
            if (CheckFunds(market.sugarCost) && market.sugars.Count() >= quantity)
            {
                for (int i = 0; i < quantity; i++)
                {
                    inventory.mySugar.Add(market.sugars[0]);
                    market.sugars.RemoveAt(0);
                }
            }
            else if (market.sugars.Count() < quantity)
            {
                Console.WriteLine("Hey, I checked in the back, we don't have that many.");
                BuyLemons();
            }
            else if (!CheckFunds(market.sugarCost))
            {
                BuySugar();
            }
        }
        public void BuyIce()
        {
            Console.WriteLine("We currently have {0} bags of ice, that we are selling for ${1} per bag.", market.bagsOfIce.Count(), market.iceCost);
            Console.Write("How many do you want?");
            if (CheckFunds(market.iceCost) && market.bagsOfIce.Count() >= quantity)
            {
                for (int i = 0; i < quantity; i++)
                {
                    inventory.myBagsOfIce.Add(market.bagsOfIce[0]);
                    market.bagsOfIce.RemoveAt(0);
                }
            }
            else if (market.bagsOfIce.Count() < quantity)
            {
                Console.WriteLine("Hey, I checked in the back, we don't have that many.");
                BuyIce();
            }
            else if (!CheckFunds(market.iceCost))
            {
                BuyIce();
            }
        }
        public void BuyBottles()
        {
            Console.WriteLine("We currently have {0} bottles, that we always sell for ${1} a bottle.", market.bottles.Count(), market.bottleCost);
            Console.Write("How many do you want?");
            if (CheckFunds(market.bottleCost) && market.bottles.Count() >= quantity)
            {
                for (int i = 0; i < quantity; i++)
                {
                    inventory.myBottles.Add(market.bottles[0]);
                    market.bottles.RemoveAt(0);
                }
            }
            else if (market.bottles.Count() < quantity)
            {
                Console.WriteLine("Hey, I checked in the back, we don't have that many.");
                BuyBottles();
            }
            else if (!CheckFunds(market.sugarCost))
            {
                BuyBottles();
            }
        }
        public void BuyHealthConcentrate()
        {
            Console.WriteLine("We currently have {0} vials of health concentrate, we're selling them for ${1} today.", market.healths.Count(), market.healthConcentrateCost);
            Console.Write("How many do you want?");
            if (CheckFunds(market.healthConcentrateCost) && market.healths.Count() >= quantity)
            {
                for (int i = 0; i < quantity; i++)
                {
                    inventory.myHealths.Add(market.healths[0]);
                    market.healths.RemoveAt(0);
                }
            }
            else if (market.healths.Count() < quantity)
            {
                Console.WriteLine("Hey, I checked in the back, we don't have that many.");
                BuyHealthConcentrate();
            }
            else if (!CheckFunds(market.healthConcentrateCost))
            {
                BuyHealthConcentrate();
            }
        }
        public void BuyManaConcentrate()
        {
            Console.WriteLine("We currently have {0} vials of mana concentrate we're selling them for ${1} today.", market.manas.Count(), market.manaConcentrateCost);
            Console.Write("How many do you want?");
            if (CheckFunds(market.manaConcentrateCost) && market.manas.Count() >= quantity)
            {
                for (int i = 0; i < quantity; i++)
                {
                    inventory.myManas.Add(market.manas[0]);
                    market.manas.RemoveAt(0);
                }
            }
            else if (market.manas.Count() < quantity)
            {
                Console.WriteLine("Hey, I checked in the back, we don't have that many.");
                BuyManaConcentrate();
            }
            else if (!CheckFunds(market.manaConcentrateCost))
            {
                BuyManaConcentrate();
            }
        }
        public void BuyBad()
        {
            Console.WriteLine("Why would you want that? You're not trying to get into the ''jet'' trade are you?");
            Console.ReadLine();
            Console.WriteLine("I know the money is appealling, but that stuff ruins lives!\nWhy don't you choose something else");
            Console.ReadLine();
            BuyIngredients(market);
        }
        public void ChooseQuantity()//ChooseQuantity works, do not modify in any way
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
        public void ChooseQuantityDouble()
        {
            double input;
            bool exit = false;
            while (!exit)
            {
                if (Double.TryParse(Console.ReadLine(), out input))
                {
                    sellingPrice = input;
                    exit = true;
                }
                else
                {
                    Console.WriteLine("That's not a valid number here, are you trying to break this?\nPlease try again.");
                }
            }
        }
        //public void SetHealthRecipe()
        //{
        //    quantity = recipeAmount;
        //    Console.WriteLine("What should today's Health Potion Recipe be?\nHealth Potions require health concentrate, sugar, and bottles\nYou currently have:\n{0} health concentrate\n{1} sugar\n{2} bottles",healthJuice, sugar, bottles);
        //    Console.WriteLine("How much health concentrate do you want to use per batch today?");
        //    ChooseQuantity();
        //    if (recipeAmount <= )
        //    {
        //        recipeAmount = healthJuiceAmount; 
        //    }
        //    else
        //    {
        //        Console.WriteLine("You don't have enough Health Concentrate to do that!\nChoose a different amount");
        //        ChooseQuantity();
        //    }
        //    Console.WriteLine("How much sugar do you want to use per batch today?");
        //    ChooseQuantity();
        //    if (recipeAmount <= )
        //    {
        //        recipeAmount = healthSugarAmount;
        //    }
        //    else
        //    {
        //        Console.WriteLine("You don't have enough Health Concentrate to do that!\nChoose a different amount");
        //        ChooseQuantity();
        //    }
        //}
        //public void BrewHealthPotions()
        //{
        //    ChooseQuantity();
        //    if ( >= healthJuiceAmount*quantity &&  >= healthSugarAmount*quantity &&  >= 1*quantity)
        //    {
        //         -= 2*quantity;
        //         -= 1*quantity;
        //         -= 1*quantity;
        //        healthPotion = 1*quantity;
        //    }
        //    else
        //    {
        //        if(healthJuiceAmount*quantity > )
        //        {
        //            Console.WriteLine("Sorry you don't have enough health concentrate.");
        //        }
        //        if(healthSugarAmount*quantity > )
        //        {
        //            Console.WriteLine("Sorry you don't have enough sugar.");
        //        }
        //        if()
        //        {
        //            Console.WriteLine("Sorry you don't have enough bottles.");
        //        }
        //        Console.WriteLine("Choose a different quantity.");
        //        BrewHealthPotions();
        //    }
        //}
        //public void SetManaRecipe()
        //{
        //    quantity = recipeAmount;
        //    Console.WriteLine("What should today's Mana Potion recipe be?\nMana Potions require health concentrate, sugar, and bottles\nYou currently have:\n{0} mana concentrate\n{1} sugar\n{2} bottles", manaJuice, sugar, bottles);
        //    Console.WriteLine("How much mana concentrate do you want to use per batch today?");
        //    ChooseQuantity();
        //    if (recipeAmount <= manaJuice)
        //    {
        //        recipeAmount = manaJuiceAmount;
        //    }
        //    else
        //    {
        //        Console.WriteLine("You don't have enough mana concentrate to do that!\nChoose a different amount");
        //        ChooseQuantity();
        //    }
        //    Console.WriteLine("How much sugar do you want to use per batch today?");
        //    ChooseQuantity();
        //    if (recipeAmount <= sugar)
        //    {
        //        recipeAmount = manaSugarAmount;
        //    }
        //    else
        //    {
        //        Console.WriteLine("You don't have enough sugar to do that!\nChoose a different amount");
        //        ChooseQuantity();
        //    }
        //}
        //public void BrewManaPotions()
        //{
        //    ChooseQuantity();
        //    if (manaJuice >= manaJuiceAmount * quantity && sugar >= manaSugarAmount * quantity && bottles >= 1 * quantity)
        //    {
        //        manaJuice -= manaJuiceAmount * quantity;
        //        sugar -= manaSugarAmount * quantity;
        //        bottles -= 1 * quantity;
        //        manaPotion = 1 * quantity;
        //    }
        //    else
        //    {
        //        if (manaJuiceAmount * quantity > manaJuice)//Change all of these to this format ADAM!!!
        //        {
        //            Console.WriteLine("Sorry you don't have enough mana concentrate.");
        //        }
        //        if (manaSugarAmount * quantity > sugar)
        //        {
        //            Console.WriteLine("Sorry you don't have enough sugar.");
        //        }
        //        if (1 * quantity > bottles)
        //        {
        //            Console.WriteLine("Sorry you don't have enough bottles for that.");
        //        }
        //    }
        //}
        public void SetLemonadeRecipe()
        {
            quantity = recipeAmount;
            Console.WriteLine("Okay, you might not believe this, but lemonade is a little more complicated than Health Potions or Mana Potions.\nBut don't worry, it's not that hard.\nLemonade requires lemons, sugar and ice\nWe'll be using the same bottles that we use for Health Potions and Mana Potions");
            Console.WriteLine("You currently have {0} lemons, {1} units of sugar, available ice is {2} and you have {3} bottles.", inventory.myLemons.Count(), inventory.mySugar.Count(), inventory.myBagsOfIce.Count(), inventory.myBottles.Count());
            Console.Write("How many lemons do you want in today's batch?");
            ChooseQuantity();
            if (recipeAmount <= inventory.myLemons.Count())
            {
                lemonadeRecipe[0] = recipeAmount;
            }
            else
            {
                Console.Write("You don't have enough lemons to do that!\nChoose a different amount");
                ChooseQuantity();
            }
            Console.Write("How much sugar do you want in today's batch?");
            ChooseQuantity();
            if (recipeAmount <= inventory.mySugar.Count())
            {
                lemonadeRecipe[1] = recipeAmount;
            }
            else
            {
                Console.Write("You don't have enough sugar to do that!\nChoose a different amount");
                ChooseQuantity();
            }
            Console.Write("How much ice do you want to use in todays batch? You should probably just use one.");
            ChooseQuantity();
            if (recipeAmount <= inventory.myBagsOfIce.Count())
            {
                lemonadeRecipe[2] = recipeAmount;
            }
            else
            {
                Console.Write("You don't have enough ice to do that!\nChoose a different amount");
                ChooseQuantity();
            }
            Console.WriteLine("All that's left to do is set our selling price!");
            SetLemonadePrice();
        }
        public void SetLemonadePrice()
        {
            Console.WriteLine("Alright, the lemonade looks great!");
            Console.Write("How much do you want to charge for it?");
            ChooseQuantityDouble();
            if(sellingPrice >= 10.00)
            {
                Console.WriteLine("Are you nuts? No one is going to buy a glass of lemonade at that price!");
                Console.Write("Try something a little more reasonable");
                ChooseQuantityDouble();
            }
            else
            {
                lemonadePrice = sellingPrice;
            }
        }
        //public void BrewLemonade()
        //{
        //    ChooseQuantity();
        //    if (lemons >= 2 * quantity && sugar >= 3 * quantity && bottles >= 1 * quantity)
        //    {
        //        lemons -= 2 * quantity;
        //        sugar -= 1 * quantity;
        //        bottles -= 1 * quantity;
        //        lemonade = 6 * quantity;
        //    }
        //    else
        //    {
        //        if (2 * quantity > lemons)
        //        {
        //            Console.WriteLine("Sorry you don't have enough lemons.");
        //        }
        //        if (3 * quantity > sugar)
        //        {
        //            Console.WriteLine("Sorry you don't have enough sugar.");
        //        }
        //        if (1 * quantity > bottles)
        //        {
        //            Console.WriteLine("Sorry you don't have enough bottles for that.");
        //        }
        //    }
        //}
    }
}
