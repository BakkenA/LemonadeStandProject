using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotionShop
{
    public class Store
    {
        public Player player;
        public string name;
        public int daysOpen;
        public int healthPotions;
        public int manaPotions;
        public int lemonadeForSale;
        public double healthPotionPrice;
        public double manaPotionPrice;
        public double lemonadePrice;
        public Store(Player player)
        {
            NameStore();
            this.player = player;
            daysOpen = 0;
            healthPotions = 0;
            manaPotions = 0;
            lemonadeForSale = 0;
            healthPotionPrice = 0;
            manaPotionPrice = 0;
            lemonadePrice = 0;
        }
        public void NameStore()
        {
            Console.Write("Store's Name:");
            name = Console.ReadLine();
        }
        public void BeginDay()
        {
            daysOpen++;
        }
        public void StockLemonade()
        {
            player.lemonadeMade = lemonadeForSale;
        }
        public void SellLemonades(int amount)
        {
            lemonadeForSale -= amount;
            player.wallet.currentMoney += lemonadePrice * amount;
        }
    }
}
