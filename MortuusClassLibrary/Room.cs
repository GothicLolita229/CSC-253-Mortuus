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
        public static List<Room> rooms = new List<Room>();

        //public Room room = SqliteDataAccess.LoadRoom();

        public List<Item> inventory;

        public Room(){}

        public Room(int id, string name, string description)
        {
            ID = id;
            Name = name;
            Description = description;
            //Exits = exits;
            //inventory = new List<Item>();
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


        public string Name { get; set; }
        
        public int ID { get; set; }
        
        public string Description { get; set; }
       
        public int NorthExit { get; set; }
        public int SouthExit { get; set; }
        public int WestExit { get; set; }
        public int EastExit { get; set; }


        public static void AddItem(Item newItem, List<Item> playerInventory)
        {
            playerInventory.Add(newItem);
        }

        public static void AddWeapon(Weapon newWeapon, List<Weapon> playerInventory)
        {
            playerInventory.Add(newWeapon);
        }

        public static void Load()
        {
            rooms = SqliteDataAccess.LoadRoomsList();
        }

        public static List<Room> RoomDisplay()
        {
            foreach (Room room in rooms)
            {
                Console.WriteLine(room.Name);
            }
            return rooms;
        }

        
        public static List<Room> RoomExitDisplay() // TEST
        {
            foreach (Room room in rooms)
            {
                Console.WriteLine(room.ID);
            }
            return rooms;
        }





    }
}
/**
* CSC 253
* Lourdes Linares and Ciara McLaughlin
* This program is a maze/rpg text adventure game. 
*/
