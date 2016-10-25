using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotionShop
{
    public class Player
    {
        
        public string name;
        public int manaJuice;
        public int healthJuice;
        public int lemons;
        public int sugar;
        public int bottles;
        public int money;
        public Player()
        {
            this.money = 200;
            this.manaJuice = 6;
            this.healthJuice = 6;
            this.lemons = 6;
            this.sugar = 6;
            this.bottles = 12;
            this.name = NamePlayer();
        }
        public string NamePlayer()
        {
            name = Console.ReadLine();
            return name;
        }

        //public void Purchasing()
        //{
        //
        //}
        public int ChooseQuantity()
        {
            int quantity;
            bool exit = false;
            while (!exit)
            {
                if (Int32.TryParse(Console.ReadLine(), out quantity))
                {
                    return quantity;
                }
                else
                {
                    Console.WriteLine("INVALID QUANTITY\nPlease try again.");
                }
            }
            return -1;
        }
    }
}
