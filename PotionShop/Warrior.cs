using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotionShop
{
    public class Warrior : Customer
    {
        public string name = "Warrior";
        public double money = 15.00;
        public Warrior(Store store)
        {
            this.store = store;
        }
    }
}
