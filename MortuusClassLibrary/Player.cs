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
        private string _idNumber;
        private string _name;
        private string _race;
        private string _lcclass;
        private string _description;
        private int _hp;
        private int _ac;
        private string _password;
        private int _location = 0;
        private List<Item> _inventory; //TODO Write the code to back these two up
        private List<Item> _quests;

        public Player(string idNumber, string name, string race, string lcclass, string description, int hp, int ac, string password, int location, string inventory, string quests)
            : base(idNumber, name, race, lcclass, description, hp, ac)
        {
            _idNumber = idNumber;
            _name = name;
            _password = password;
            _race = race;
            _lcclass = lcclass;
            _hp = hp;
            _ac = ac;
            _location = location;

        }

        public string Password { get; set; }
        public string Location { get; set; }
        public List<Item> Inventory { get; set; }
        public List<Item> Quests { get; set; }
        public string name
        {
            get { return _name; }
            set { }
        }
        public static bool checkPassword(ref string password)
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
            return name;
        }
    }
}
