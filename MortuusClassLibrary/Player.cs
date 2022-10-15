using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MortuusClassLibrary
{
    public class Player: LivingCreature
    {
        public Player()
        {
        }

        /*private string _password;
        private int _location = 0;
        private List<Item> _inventory; //TODO Write the code to back these two up
        private List<Item> _quests;*/

        public Player(int id, string name, string race, string lcclass, string description, string weapon, int hp, int ac, string password, int location)
            : base(id, name, race, lcclass, description, hp, ac)
        {
            ID = id;
            Name = name;
            Race = race;
            LcClass = lcclass;
            Description = description;
            Weapon = weapon;
            HP = hp;
            AC = ac;
            Password = password;
            Location = location;
            
        }

        public Player(int id, string name, string race, string lcclass, string description, string weapon, int hp, int ac, string password, int location, List<Item> inventory, List<Item> quests)
            : base(id, name, race, lcclass, description, hp, ac)
        {
            ID = id;
            Name = name;
            Race = race;
            LcClass = lcclass;
            Description = description;
            Weapon = weapon;
            HP = hp;
            AC = ac;
            Password = password;
            Location = location;
            Inventory = inventory;
            Quests = quests;
        }
        public string Weapon { get; set; }
        public string Password { get; set; }
        public int Location { get; set; }
        public List<Item> Inventory {get; set;}
        public List<Item> Quests { get; set; }
        public static bool CheckPassword(ref string password)
        {
            var regexItem = new Regex("[a-zA-Z0-9 ]");


            if (regexItem.IsMatch(password) && Regex.IsMatch(password, "[A-Z]") && Regex.IsMatch(password, "[a-z]"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public override string ToString()
        {
            return Name;
        }
    }
}
/**
* CSC 253
* Lourdes Linares and Ciara McLaughlin
* This program is a maze/rpg text adventure game. 
*/