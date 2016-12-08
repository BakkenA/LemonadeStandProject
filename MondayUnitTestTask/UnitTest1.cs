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
            int testStock = 20;
            day.market.CreateStartingStock();
            //Assert.ReferenceEquals(day.market.healths.Count, testStock);
            Assert.ReferenceEquals(day.market.manas.Count, testStock);    
        }
        [TestMethod]
        public void CheckDaysOpen()
        {
            Player player = new Player("Name");
            Store store = new Store(player);
            player.store.BeginDay();
            Assert.IsNotNull(player.store.daysOpen);
        }
        [TestMethod]
        public void VaryThreat()
        {
            Day day = new Day();
            Weather weather = new Weather();
            day.weather.danger.SetThreat();
            Assert.IsNotNull(day.weather.danger.currentThreat);        
        }
        [TestMethod]
        public void CheckPlayerGoods()
        {
            Player player = new Player("Name");
            ManaConcentrate mana = new ManaConcentrate();
            double ghostLemonade = 1;
            Assert.AreNotEqual(ghostLemonade, player.lemonadePrice);   
        }
        [TestMethod]
        public void CheckAgainstWallet()
        { 
            Wallet wallet = new Wallet();
            double testCost = 20.00;
            Assert.AreEqual(testCost, wallet.startingMoney);
        } 
    }
}
