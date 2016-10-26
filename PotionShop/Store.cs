using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotionShop
{
    public class Store
    {
        public string name;
        public int daysOpen;
        public int healthPotions;
        public int manaPotions;
        public int lemonades;
        public int healthPotionPrice;
        public int manaPotionPrice;
        public int lemonadePrice;
        public Store()
        {
            NameStore();
            this.daysOpen = 0;
            this.healthPotions = 0;
            this.manaPotions = 0;
            this.lemonades = 0;
            this.healthPotionPrice = 0;
            this.manaPotionPrice = 0;
            this.lemonadePrice = 0;
        }
        public void NameStore()
        {
            name = Console.ReadLine();
        }
        public void BeginDay()
        {
            daysOpen++;
        }
        //public void SellLemonade()
        //{
        //    for (int i = 0; i < length; i++)
        //    {

        //    }
        //}
    }
}
