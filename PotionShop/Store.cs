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
        public int healthPotionForSale;
        public int manaPotionForSale;
        public int lemonadeForSale;
        public double healthPotionPrice;
        public double manaPotionPrice;
        public double lemonadePrice;
        public Store(Player player)
        {
            NameStore();
            this.player = player;
            daysOpen = 0;
            healthPotionForSale = 0;
            manaPotionForSale = 0;
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
            lemonadeForSale = player.lemonadeMade;
            StockHealthPotion();
        }
        public void StockHealthPotion()
        {
            healthPotionForSale = player.healthPotionMade;
            StockManaPotion();
        }
        public void StockManaPotion()
        {
            manaPotionForSale = player.manaPotionMade;
            player.OpenStore();
        }
        public void SellLemonades(int amount)
        {
            lemonadeForSale -= amount;
            player.wallet.currentMoney += lemonadePrice * amount;
        }
        public void SellHealthPotions(int amount)
        {
            healthPotionForSale -= amount;
            player.wallet.currentMoney += healthPotionPrice * amount;
        }
        public void SellManaPotions(int amount)
        {
            manaPotionForSale -= amount;
            player.wallet.currentMoney += manaPotionPrice * amount;
        }
    }
}
