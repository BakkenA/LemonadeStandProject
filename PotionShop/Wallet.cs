using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotionShop
{
    public class Wallet
    {
        public double currentMoney;
        public Wallet()
        {
            if (Console.BackgroundColor == ConsoleColor.Black)
            {
                currentMoney = 20.00;
            }
            else if (Console.BackgroundColor == ConsoleColor.Red)
            {
                currentMoney = 10.00;

            }
        }
        public void CheckWallet()
        {
                
        }
    }
}
