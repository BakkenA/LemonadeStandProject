using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotionShop
{
    public class Weather
    {
        public Random random;
        public Danger danger = new Danger();
        public string climate;
        public int currentTemp;        

        public int SetTemp()
        {
            random = new Random();
            int temp = random.Next(0, 101);
            return temp;
        }
        public string SetClimate(int currentTemp)
        {
            string todaysClimate;
            random = new Random();
            int currentClimate = random.Next(0, 3);
            if (currentClimate == 0)
            {
                todaysClimate = "Clear Skies";
                return todaysClimate;
            }
            else if (currentClimate == 1)
            {
                todaysClimate = "Partially Cloudy";
                return todaysClimate;
            }
            else if (currentClimate == 2)
            {
                todaysClimate = "Cloudy";
                return todaysClimate;
            }
            else
            {
                if (currentTemp <= 30)
                {
                    todaysClimate = "Snowy";
                }
                else
                {
                    todaysClimate = "Rainy";
                }
                return todaysClimate;
            }
        }
    }
}
