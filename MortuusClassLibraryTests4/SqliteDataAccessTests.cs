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
        public void LoadTreasureTest()
        {
            Room room = SqliteDataAccess.LoadRoom(301);
            Assert.AreEqual(301, room.ID);
        }

    }
}