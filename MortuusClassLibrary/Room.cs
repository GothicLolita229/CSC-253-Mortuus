using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MortuusClassLibrary
{
    public class Room
    {
        //public static List<Room> rooms = new List<Room>();
        public static List<Room> roomDisplay = SqliteDataAccess.LoadRoomsDisplay();
        public static List<Room> rooms = SqliteDataAccess.LoadRoom();
        public List<Item> inventory;
        public Room(){}
        public Room(int id, string name, string description)
        {
            ID = id;
            Name = name;
            Description = description;
        }
        public Room(int id, string name, string description, int northExit, int southExit, int westExit, int eastExit)
        {
            ID = id;
            Name = name;
            Description = description;
            NorthExit = northExit;
            SouthExit = southExit;
            WestExit = westExit;
            EastExit = eastExit;
        }

        public Room(int id, string name, string description, int northExit, int southExit, int westExit, int eastExit, int roomMob)
        {
            ID = id;
            Name = name;
            Description = description;
            NorthExit = northExit;
            SouthExit = southExit;
            WestExit = westExit;
            EastExit = eastExit;
            RoomMob = roomMob;
        }

        public Room(int id, string name, string description, int northExit, int southExit, int westExit, int eastExit, 
            List<int> roomInv)
        {
            ID = id;
            Name = name;
            Description = description;
            NorthExit = northExit;
            SouthExit = southExit;
            WestExit = westExit;
            EastExit = eastExit;
            RoomInv = roomInv;
        }
        public string Name { get; set; }
        public int ID { get; set; }
        public string Description { get; set; }
        public int NorthExit { get; set; }
        public int SouthExit { get; set; }
        public int WestExit { get; set; }
        public int EastExit { get; set; }
        public int RoomMob { get; set; }
        public List<int> RoomInv { get; set; }
        public static void AddItem(Item newItem, List<Item> playerInventory)
        {
            playerInventory.Add(newItem);
        }
        public static void AddWeapon(Weapon newWeapon, List<Weapon> playerInventory)
        {
            playerInventory.Add(newWeapon);
        }
        /*public static void Load()
        {
            rooms = SqliteDataAccess.LoadRoomsList();
        }*/
        public static List<Room> RoomDisplay()
        {
            foreach (Room room in roomDisplay)
            {
                Console.WriteLine(room.Name);
            }
            return roomDisplay;
        }
        
    }
}
/**
* CSC 253
* Lourdes Linares and Ciara McLaughlin
* This program is a maze/rpg text adventure game. 
*/
