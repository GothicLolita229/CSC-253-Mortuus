using Microsoft.VisualStudio.TestTools.UnitTesting;
using MortuusClassLibrary;
using System;

namespace MortuusClassLibraryTests2
{
    [TestClass]
    public class LoadPotion
    {
        [TestMethod]
        public void LoadPotionTest()
        {
            Potion potion = SqliteDataAccess.LoadPotion(401);
            Assert.AreEqual(401, potion.IDNumber);
        }
    }
}
