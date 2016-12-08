using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotionShop
{
    public class Customer
    {
        public Random random;
        public Store store;
        public int thirst;
        public int purchaseChance;
        public int GetThirst(Weather weather)
        {
            if (weather.currentTemp >= 85)
            {
                int thirst = 100;
                return thirst;
            }
            else if (weather.currentTemp <= 35)
            {
                int thirst = 0;
                return thirst;
            }
            else
            {
                int thirst = 50;
                return thirst;
            }
        }
        public int GetPurchaseChance()
        {
            random = new Random();
            int purchaseChance = random.Next(0, 3);
            return purchaseChance;
        }
        public virtual void PurchaseLemonade()
        {
            if (thirst == 100 && store.lemonadeForSale >= 2 && purchaseChance == 2)
            {
                store.SellLemonades(2);
            }
            else if (thirst == 50 && purchaseChance == 2 && store.lemonadeForSale >= 1)
            {
                store.lemonadeForSale -= 1;
            }
        }
    }
}
