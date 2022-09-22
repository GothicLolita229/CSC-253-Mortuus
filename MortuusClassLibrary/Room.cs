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
        public static List<Room> rooms = SqliteDataAccess.LoadRooms();

        public List<Item> inventory;

        public Room()
        {
        }

        public Room(string idNumber, string name, string description, string exit)
        {
            IdNumber = idNumber;
            Name = name;
            Description = description;
            Exit = exit;
            inventory = new List<Item>();
        }
        public string Name { get; set; }
        
        public string IdNumber { get; set; }
        
        public string Description { get; set; }
       
        public string Exit { get; set; }


        public static void addItem(Item newItem, List<Item> playerInventory)
        {
            playerInventory.Add(newItem);
        }

        public static void addWeapon(Weapon newWeapon, List<Weapon> playerInventory)
        {
            playerInventory.Add(newWeapon);
        }

        public static List<Room> RoomDisplay()
        {
            foreach (Room room in rooms)
            {
                Console.WriteLine(room.Name);
            }
            return rooms;
        }

       



    }
}
