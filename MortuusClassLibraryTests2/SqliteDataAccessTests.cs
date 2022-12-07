using Microsoft.VisualStudio.TestTools.UnitTesting;
using MortuusClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SQLite;

namespace MortuusClassLibrary.Tests
{
    [TestClass()]
    public class SqliteDataAccessTests
    {
        [TestMethod()]
        public void LoadRoomTest()
        {
            Room room = SqliteDataAccess.LoadRoom(301);
            Assert.AreEqual(301, room.ID);
        }

    }
}