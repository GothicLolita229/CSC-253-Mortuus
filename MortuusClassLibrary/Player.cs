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
        /*private string _password;
        private int _location = 0;
        private List<Item> _inventory; //TODO Write the code to back these two up
        private List<Item> _quests;*/

        public Player(int id, string name, string race, string lcclass, string description, int hp, int ac, string password, int location, List<Item> inventory, List<Item> quests)
            : base(id, name, race, lcclass, description, hp, ac)
        {
            
            Password = password;
            Location = location;
        }

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
