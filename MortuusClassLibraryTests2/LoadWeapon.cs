using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MortuusClassLibrary;

namespace MortuusClassLibraryTests2
{
    [TestClass]
    public class LoadWeapon
    {
        [TestMethod]
        public void LoadWeaponTest()
        {
            Weapon weapon = SqliteDataAccess.LoadWeapon(701);
            Assert.AreEqual(701, weapon.IDNumber);
        }
    }
}
