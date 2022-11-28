using Microsoft.VisualStudio.TestTools.UnitTesting;
using MortuusClassLibrary;
using System;

namespace MortuusClassLibraryTests2
{
    [TestClass]
    public class LoadRoom
    {
        [TestMethod]
        public void LoadRoomTest()
        {
            Room room = SqliteDataAccess.LoadRoom(301);
            Assert.AreEqual(301, room.ID);
        }
    }
}
