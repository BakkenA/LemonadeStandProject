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
        public int budget;
        public int healthPotions;
        public int manaPotions;
        public int lemonades;
        public Store()
        {
            this.name = NameStore();
            this.daysOpen = 0;
            this.healthPotions = 0;
            this.manaPotions = 0;
            this.lemonades = 0;
            this.budget = 0;
        }
        public string NameStore()
        {
            name = Console.ReadLine();
            return name;
        }
        public void BeginDay()
        {
            daysOpen++;
        }
        public void AddHealthPotions()
        {

        }
        public void AlterBudget()
        {
            
        }
        public void CheckDay()
        {
            if (daysOpen == 7)
            {
                EndWeek();
            }
        }
        public void EndWeek()
        {
            Environment.Exit(0);
        }
    }
}
