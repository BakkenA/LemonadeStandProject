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
        public int desiredQuantity;
        public double sellingPrice;
        public double healthPotionSellingPrice;
        public double manaPotionSellingPrice;
        public int batchSize;
        public int healthPotionBatchSize;
        public int healthPotionMade;
        public int manaPotionBatchSize;
        public int manaPotionMade;
        public int lemonade;
        public double lemonadePrice;
        public double healthPotionPrice;
        public double manaPotionPrice;
        public int lemonadeMade;
        int[] lemonadeRecipe = new[] { 0, 0, 0, 0 };
        public int healthConcentrateHealthPotionRequirement = 2;
        public int sugarHealthPotionRequirement = 1;
        public int bottleHealthPotionRequirement = 1;
        public int manaConcentrateManaPotionRequirement = 3;
        public int sugarManaPotionRequirement = 3;
        public int bottleManaPotionRequirement = 1;

        public Player(string message)
        {
            this.healthPotionMade = 0;
            this.manaPotionMade = 0;
            this.lemonadeMade = 0;
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
            if (cost * desiredQuantity <= cash)
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
            if (CheckFunds(market.lemonCost) && market.lemons.Count() >= desiredQuantity)
            {
                //Lemon lemon = new Lemon(987);//This line was part of a deeper-dive into the philosophy of teleportation, if you're Mike, you'll know what this is, if you're not, ask Mike.
                for (int i = 0; i < desiredQuantity; i++)
                {
                    //market.lemons.Add(lemon);
                    inventory.myLemons.Add(market.lemons[0]);
                    market.lemons.RemoveAt(0);
                }
             }
            else if(market.lemons.Count() < desiredQuantity)
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
            if (CheckFunds(market.sugarCost) && market.sugars.Count() >= desiredQuantity)
            {
                for (int i = 0; i < desiredQuantity; i++)
                {
                    inventory.mySugar.Add(market.sugars[0]);
                    market.sugars.RemoveAt(0);
                }
            }
            else if (market.sugars.Count() < desiredQuantity)
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
            if (CheckFunds(market.iceCost) && market.bagsOfIce.Count() >= desiredQuantity)
            {
                for (int i = 0; i < desiredQuantity; i++)
                {
                    inventory.myBagsOfIce.Add(market.bagsOfIce[0]);
                    market.bagsOfIce.RemoveAt(0);
                }
            }
            else if (market.bagsOfIce.Count() < desiredQuantity)
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
            if (CheckFunds(market.bottleCost) && market.bottles.Count() >= desiredQuantity)
            {
                for (int i = 0; i < desiredQuantity; i++)
                {
                    inventory.myBottles.Add(market.bottles[0]);
                    market.bottles.RemoveAt(0);
                }
            }
            else if (market.bottles.Count() < desiredQuantity)
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
            if (CheckFunds(market.healthConcentrateCost) && market.healths.Count() >= desiredQuantity)
            {
                for (int i = 0; i < desiredQuantity; i++)
                {
                    inventory.myHealths.Add(market.healths[0]);
                    market.healths.RemoveAt(0);
                }
            }
            else if (market.healths.Count() < desiredQuantity)
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
            if (CheckFunds(market.manaConcentrateCost) && market.manas.Count() >= desiredQuantity)
            {
                for (int i = 0; i < desiredQuantity; i++)
                {
                    inventory.myManas.Add(market.manas[0]);
                    market.manas.RemoveAt(0);
                }
            }
            else if (market.manas.Count() < desiredQuantity)
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
                    desiredQuantity = input;
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
        public void SetHealthPotionBatchSize()
        {
            healthPotionBatchSize = desiredQuantity;
            Console.WriteLine("\n\nHere's what we have if we want to make any health potions today.\nHealth potions require 2 health concentrate, 1 sugar, and 1 bottle\nYou currently have:\n{0} Health concentrate\n{1} sugar\n{2} bottles", inventory.myHealths.Count(), inventory.mySugar.Count(), inventory.myBottles.Count());
            Console.WriteLine("How many health potions should we make today?");
            ChooseQuantity();
            if (batchSize <= inventory.myHealths.Count()*healthConcentrateHealthPotionRequirement && batchSize <= inventory.mySugar.Count()*sugarHealthPotionRequirement && batchSize <= inventory.myBottles.Count()*bottleHealthPotionRequirement)
            {
                healthPotionBatchSize = healthPotionMade;
                BrewHealthPotions();
            }
            else if(batchSize > inventory.myHealths.Count()*healthConcentrateHealthPotionRequirement)
            {
                Console.WriteLine("You don't have enough health concentrate to do that!\nChoose a different amount.");
                ChooseQuantity();
            }
            else if (batchSize > inventory.mySugar.Count()*sugarHealthPotionRequirement)
            {
                Console.WriteLine("You don't have enough sugar to do that!\nChoose a different amount.");
                ChooseQuantity();
            }
            else if (batchSize > inventory.myBottles.Count()*bottleHealthPotionRequirement)
            {
                Console.WriteLine("You don't have enough bottles to do that!\nChoose a different amount.");
                ChooseQuantity();
            }
        }
        public void BrewHealthPotions()
        {
            healthPotionMade = healthPotionBatchSize;
        }
        public void SetManaPotionBatchSize()
        {
            manaPotionBatchSize = desiredQuantity;
            Console.WriteLine("\n\nHere's what we have if we want to make any health potions today.\nHealth potions require 2 health concentrate, 1 sugar, and 1 bottle\nYou currently have:\n{0} Mana concentrate\n{1} sugar\n{2} bottles", inventory.myManas.Count(), inventory.mySugar.Count(), inventory.myBottles);
            Console.WriteLine("How many mana potions should we make today?");
            ChooseQuantity();
            if (batchSize <= inventory.myManas.Count() * manaConcentrateManaPotionRequirement && batchSize <= inventory.mySugar.Count() * sugarManaPotionRequirement && batchSize <= inventory.myBottles.Count() * bottleManaPotionRequirement)
            {
                manaPotionBatchSize = healthPotionMade;
                BrewManaPotions();
            }
            else if (batchSize > inventory.myManas.Count() * manaConcentrateManaPotionRequirement)
            {
                Console.WriteLine("You don't have enough mana concentrate to do that!\nChoose a different amount.");
                ChooseQuantity();
            }
            else if (batchSize > inventory.mySugar.Count() * sugarManaPotionRequirement)
            {
                Console.WriteLine("You don't have enough sugar to do that!\nChoose a different amount.");
                ChooseQuantity();
            }
            else if (batchSize > inventory.myBottles.Count() * bottleManaPotionRequirement)
            {
                Console.WriteLine("You don't have enough bottles to do that!\nChoose a different amount.");
                ChooseQuantity();
            }
        }
        public void SetManaPotionPrice()
        {
            Console.WriteLine("Okay, we have mana potion to sell!");
            Console.Write("How much do you want to charge for it?");
            ChooseQuantityDouble();
            if (manaPotionSellingPrice >= 10.00)
            {
                Console.WriteLine("Are you nuts? No one is going to buy a glass of lemonade at that price!");
                Console.Write("Try something a little more reasonable");
                ChooseQuantityDouble();
            }
            else
            {
                manaPotionPrice = manaPotionSellingPrice;
            }
        }
        public void BrewManaPotions()
        {
            manaPotionMade = manaPotionBatchSize;
        }
        public void SetLemonadeRecipe()
        {
            desiredQuantity = batchSize;
            Console.WriteLine("Okay, you might not believe this, but lemonade is a little more complicated than Health Potions or Mana Potions.\nBut don't worry, it's not that hard.\nLemonade requires lemons, sugar and ice\nWe'll be using the same bottles that we use for Health Potions and Mana Potions");
            Console.WriteLine("You currently have {0} lemons, {1} units of sugar, available ice is {2} and you have {3} bottles.", inventory.myLemons.Count(), inventory.mySugar.Count(), inventory.myBagsOfIce.Count(), inventory.myBottles.Count());
            Console.Write("How many lemons do you want in today's batch?");
            ChooseQuantity();
            if (batchSize <= inventory.myLemons.Count())
            {
                lemonadeRecipe[0] = batchSize;
            }
            else
            {
                Console.Write("You don't have enough lemons to do that!\nChoose a different amount");
                ChooseQuantity();
            }
            Console.Write("How much sugar do you want in today's batch?");
            ChooseQuantity();
            if (batchSize <= inventory.mySugar.Count())
            {
                lemonadeRecipe[1] = batchSize;
            }
            else
            {
                Console.Write("You don't have enough sugar to do that!\nChoose a different amount");
                ChooseQuantity();
            }
            Console.Write("How much ice do you want to use in todays batch? You should probably just use one.");
            ChooseQuantity();
            if (batchSize <= inventory.myBagsOfIce.Count())
            {
                lemonadeRecipe[2] = batchSize;
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
        public void ConfirmLemonadePrice()
        {
            Console.WriteLine("The selling price of your lemonade is now ${0}, is that okay?", lemonadePrice);
            Console.Write("YES or NO");
            string response = Console.ReadLine().ToUpper();
            if (response == "YES")
            {
                Console.WriteLine("Alright, we'll be selling lemonade at ${0} per glass.", lemonadePrice);
                Console.ReadLine();
            }
            else if (response == "NO")
            {
                Console.WriteLine("Alright, then let's change it.");
                Console.ReadLine();
                Console.Clear();
                SetLemonadePrice();
            }
            BrewLemonade();
        }
        public void BrewLemonade()
        {
            if (lemonadeRecipe[0] <= inventory.myLemons.Count() && lemonadeRecipe[1] <= inventory.mySugar.Count()  && lemonadeRecipe[2] <= inventory.myBagsOfIce.Count())
            {

                lemonadeMade += 1;
                                
            }
            else
            {
                if (lemonadeRecipe[0] > inventory.myLemons.Count())
                {
                    Console.WriteLine("Sorry you don't have enough lemons.");
                }
                else if (lemonadeRecipe[1] > inventory.mySugar.Count())
                {
                    Console.WriteLine("Sorry you don't have enough sugar.");
                }
                else if (lemonadeRecipe[2] > inventory.myBagsOfIce.Count())
                {
                    Console.WriteLine("Sorry you don't have enough ice for that.");
                }
                else if (lemonadeRecipe[3] > inventory.myBottles.Count())
                {
                    Console.WriteLine("Oh shoot we don't have enough bottles to make this");
                }
            }
        }
        public void ExpendLemons()
        {
            for (int i = 0; i < lemonadeRecipe[0]; i++)
            {
                inventory.myLemons.RemoveAt(0);
            }
            ExpendSugar();
        }
        public void ExpendSugar()
        {
            for (int i = 0; i < lemonadeRecipe[1]; i++)
            {
                inventory.mySugar.RemoveAt(0);
            }
            ExpendIce();
        }
        public void ExpendIce()
        {
            for (int i = 0; i < lemonadeRecipe[2]; i++)
            {
                inventory.myBagsOfIce.RemoveAt(0);
            }
            ExpendBottles();
        }
        public void ExpendBottles()
        {
            for (int i = 0; i < lemonadeRecipe[3]; i++)
            {
                inventory.myBottles.RemoveAt(0);
            }
            store.StockLemonade();
        }
        public void OpenStore()
        {
            day.RunDay();
        }
    }
}
