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
        public Store()
        {
            this.name = NameStore();
            this.daysOpen = 0;
            this.budget = 100;
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
