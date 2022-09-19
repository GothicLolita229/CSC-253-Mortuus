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
        private string _idNumber;
        private string _name;
        private string _description;
        private string _exit;
        public List<Item> inventory;

        public Room()
        {
        }

        public Room(string idNumber, string name, string description, string exit)
        {
            _idNumber = idNumber;
            _name = name;
            _description = description;
            _exit = exit;
            inventory = new List<Item>();
        }
        public string Name
        {
            get { return _name; }
            set { }
        }
        public string IdNumber
        { 
          get { return _idNumber; }
          set { }
        }
        public string Description
        {
            get { return _description; }
            set { }
        }
        public string Exit
        {
            get { return _exit; }
            set { }
        }


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
