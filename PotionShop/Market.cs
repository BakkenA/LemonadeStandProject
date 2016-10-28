using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotionShop
{
    public class Market
    {
        public Ingredient ingredient;
        int inStock;
        int stocking;
        double priceModifier;
        Lemon lemon;
        HealthConcentrate healthCon;
        ManaConcentrate manaCon;
        Sugar sugar;
        Ice ice;
        Bottle bottle;
        public double lemonCost = 0.75;
        public double manaConcentrateCost = 1.25;
        public double healthConcentrateCost = 1.05;
        public double sugarCost = 0.25;
        public double iceCost = 0.05;
        public double bottleCost = 0.10;
        public List<Lemon> lemons;
        public List<ManaConcentrate> manas;
        public List<HealthConcentrate> healths;
        public List<Sugar> sugars;
        public List<Ice> bagsOfIce;
        public List<Bottle> bottles;
        public Market()
        {
            lemons = new List<Lemon>();
            manas = new List<ManaConcentrate>();
            healths = new List<HealthConcentrate>();
            sugars = new List<Sugar>();
            bagsOfIce = new List<Ice>();
            bottles = new List<Bottle>();
        }
        public int GetRestockChance()
        {
            Random random = new Random();
            int stocking = random.Next(1, 10);
            return stocking;
        }
        public void CreateStartingStock()
        {
            int amountOfStartingStock = 20;
            for (int i = 0; i < amountOfStartingStock; i++)
            {
                lemons.Add(new Lemon());
                manas.Add(new ManaConcentrate());
                healths.Add(new HealthConcentrate());
                sugars.Add(new Sugar());
                bagsOfIce.Add(new Ice());
                bottles.Add(new Bottle());
            }
        }
        public void Restock()
        {
            for (int i = 0; i < stocking; i++)
            {
                lemons.Add(lemon);
                manas.Add(manaCon);
                healths.Add(healthCon);
                sugars.Add(sugar);
                bagsOfIce.Add(ice);
                bottles.Add(bottle);
                CheckMinPrice();
            }
        }
        public void CheckMinPrice()
        {
            if (lemonCost >= 0.05 && healthConcentrateCost >= 0.10 && manaConcentrateCost >= 0.25 && sugarCost >= 0.01)
            {
                FluctuatePrices();
            }
            else
            {
                Console.WriteLine("Prices are stabilizing");
                Console.ReadLine();
            }
        }
        public void FluctuatePrices()
        {
            lemonCost -= 10 / lemons.Count() * lemonCost;
            manaConcentrateCost -= 3 / manas.Count() * manaConcentrateCost;
            healthConcentrateCost -= 10 / healths.Count() * healthConcentrateCost;
            sugarCost -= 10 / sugars.Count() * sugarCost;
        }
    }
}
