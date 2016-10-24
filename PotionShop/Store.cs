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
        int daysOpen = 0;
        int budget = 100;
        public Store()
        {
            this.name = NameStore();
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
