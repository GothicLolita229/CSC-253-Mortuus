using Microsoft.VisualStudio.TestTools.UnitTesting;
using MortuusClassLibrary;
using System;

namespace MortuusClassLibraryTests2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod()]
        public void LoadWeaponTest()
        {
            //Weapon weapon = SqliteDataAccess.LoadWeapon(701);
            Assert.AreEqual("Battle Hammer", SqliteDataAccess.LoadWeapon(701).Name);
        }
    }
}
