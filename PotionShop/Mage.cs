using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotionShop
{
    public class Mage : Customer
    {
        string name = "Mage";
        public double money = 20.00;
        public Mage(Store store)
        {
            this.store = store;
        }
    }
}
