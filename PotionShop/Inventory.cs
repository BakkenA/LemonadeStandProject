using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotionShop
{
    public class Inventory
    {
        public Ingredient ingredient;
        Lemon lemon;
        HealthConcentrate healthCon;
        ManaConcentrate manaCon;
        Sugar sugar;
        Ice ice;
        Bottle bottle;
        public List<Lemon> myLemons;
        public List<ManaConcentrate> myManas;
        public List<HealthConcentrate> myHealths;
        public List<Sugar> mySugar;
        public List<Ice> myBagsOfIce;
        public List<Bottle> myBottles;
        public Inventory()
        {
            myLemons = new List<Lemon>();
            myManas = new List<ManaConcentrate>();
            myHealths = new List<HealthConcentrate>();
            mySugar = new List<Sugar>();
            myBagsOfIce = new List<Ice>();
        }
    }
}
