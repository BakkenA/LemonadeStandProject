using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotionShop
{
    class Peasant : Customer
    {
        public string name = "Peasant";
        public double money = 5.00;
        public Peasant(Store store)
        {
            this.store = store;
        }
    }
}
