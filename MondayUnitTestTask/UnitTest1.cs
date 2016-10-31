using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotionShop;

namespace PotionShop
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SeeListInterpretation()
        {
            Day day = new Day();
            Market market = new Market();
            Ingredient ingredient = new Ingredient();
            HealthConcentrate health = new HealthConcentrate();
            int totalStock = 20;
            day.market.CreateStartingStock();
            Assert.ReferenceEquals(day.market.healths.Count, totalStock);
            
            
        }
        [TestMethod]
        public void TestPriceChange()
        {
            Day day = new Day();
            Market market = new Market();
            Ingredient ingredient = new Ingredient();
            Sugar sugar = new Sugar();
            int[] lemonadeRecipe = new int[2];
            day.player.ExpendSugar();
            Assert.I
        }
    }
}
