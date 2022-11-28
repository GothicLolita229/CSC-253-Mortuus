using Microsoft.VisualStudio.TestTools.UnitTesting;
using MortuusClassLibrary;
using System;

namespace MortuusClassLibraryTests2
{
    [TestClass]
    public class LoadTreasure
    {
        [TestMethod]
        public void LoadTreasureTest()
        {
            Treasure treasure = SqliteDataAccess.LoadTreasure(601);
            Assert.AreEqual(601, treasure.IDNumber);
        }
    }
}
