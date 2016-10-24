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
        public Player()
        {
            this.name = NamePlayer();
        }
        public string NamePlayer()
        {
            name = Console.ReadLine();
            return name;
        }
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
