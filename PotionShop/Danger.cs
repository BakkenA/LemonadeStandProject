using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotionShop
{
    public class Danger
    {
        Random random;
        public int currentThreat; 
        //int[] threat = new int[20];

        public int SetThreat()
        {
            random = new Random();
            int currentThreat = random.Next(0, 19);
            if (currentThreat >= 10)
            {
                Console.WriteLine("There have been reports of monsters near the city limits");
                return currentThreat;
            }
            else
            {
                Console.WriteLine("Things seem pretty peaceful close to the city");
                return currentThreat;
            }

        }
    }
}
