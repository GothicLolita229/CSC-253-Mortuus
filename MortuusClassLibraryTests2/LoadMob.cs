using Microsoft.VisualStudio.TestTools.UnitTesting;
using MortuusClassLibrary;
using System;

namespace MortuusClassLibraryTests2
{
    [TestClass]
    public class LoadMob
    {
        [TestMethod]
        public void LoadMobTest()
        {
            Mob mob = SqliteDataAccess.LoadMob(201);
            Assert.AreEqual(201, mob.ID);
        }
    }
}
