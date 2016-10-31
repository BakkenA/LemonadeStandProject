using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotionShop
{
    public class Wallet
    {
        public double startingMoney;
        public double currentMoney;
        public Wallet()
        {
            if (Console.BackgroundColor == ConsoleColor.Black)
            {
                startingMoney = 20.00;
            }
            else if (Console.BackgroundColor == ConsoleColor.Red)
            {
                startingMoney = 10.00;

            }
            currentMoney = startingMoney;
        }
        public void CheckWallet()
        {
                
        }
    }
}
