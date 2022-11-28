using Microsoft.VisualStudio.TestTools.UnitTesting;
using MortuusClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortuusClassLibrary.Tests
{
    [TestClass()]
    public class SqliteDataAccessTests
    {
        [TestMethod()]

        // Tests if each item loads the object properly along with their ID's.
        // Probably doesn't work quite yet, still trying it out.
        public void LoadRoomTest()
        {
            Room room = SqliteDataAccess.LoadRoom(301);
            Assert.AreEqual(301, room.ID);
        }

        public void LoadTreasureTest()
        {
            Treasure treasure = SqliteDataAccess.LoadTreasure(601);
            Assert.AreEqual(601, treasure.IDNumber);
        }

        public void LoadWeaponTest()
        {
            Weapon weapon = SqliteDataAccess.LoadWeapon(701);
            Assert.AreEqual(701, weapon.IDNumber);
        }

        public void LoadPotionTest()
        {
            Potion potion = SqliteDataAccess.LoadPotion(401);
            Assert.AreEqual(401, potion.IDNumber);
        }

        public void LoadMobTest()
        {
            Mob mob = SqliteDataAccess.LoadMob(201);
            Assert.AreEqual(201, mob.ID);
        }
    }
}