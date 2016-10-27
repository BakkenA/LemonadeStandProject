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
        public double lemonCost;
        public double manaConcentrateCost;
        public double healthConcentrateCost;
        public double sugarCost;
        List<Lemon> lemons;
        List<ManaConcentrate> manas;
        List<HealthConcentrate> healths;
        List<Sugar> sugars;
        List<Ice> bagsOfIce;
        List<Bottle> bottles;
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
                lemons.Add(lemon);
                manas.Add(manaCon);
                healths.Add(healthCon);
                sugars.Add(sugar);
                bagsOfIce.Add(ice);
                bottles.Add(bottle);
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
            if (Lemon.cost >= 0.05 && HealthConcentrate.cost >= 0.10 && ManaConcentrate.cost >= 0.25 && Sugar.cost >= 0.01)
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
            lemonCost -= 10 / lemons.Count() * 2;
            manaConcentrateCost -= 3 / manas.Count();
            healthConcentrateCost -= 10 / healths.Count();
            sugarCost -= 10 / sugars.Count() * 2;
        }
    }
}
