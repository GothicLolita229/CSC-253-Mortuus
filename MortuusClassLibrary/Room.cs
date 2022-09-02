using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortuusClassLibrary
{
    public class Room
    {
        private int _idNumber;
        private string _name;
        private string _description;
        private string _exit;
        public List<Item> inventory;

        public Room()
        {
        }

        public Room(int idNumber, string name, string description, string exit)
        {
            _idNumber = idNumber;
            _name = name;
            _description = description;
            _exit = exit;
            inventory = new List<Item>();
        }
        public string Name { get; set; }
        public int IdNumber { get; set; }
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
    }
}
