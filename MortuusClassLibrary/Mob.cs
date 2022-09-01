using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortuusClassLibrary
{
    public class Mob : LivingCreature
    {
        private string _idNumber;
        private string _name;
        private string _race; 
        private string _mobClass; 
        private int _hp;
        private int _ac;
        private string _weapon;
        private string _inventory;
        private string _description;


        public Mob(string idNumber, string name, string race, string mobClass, int hp, int ac, string weapon, string description, string inventory)
            : base(idNumber, name, race, mobClass, description, hp, ac)
        {
            _idNumber = idNumber;
            _name = name;
            _race = race;
            _mobClass = mobClass;
            _hp = hp;                   
            _ac = ac;                  
            _weapon = weapon;
            _inventory = inventory;
            _description = description;
        }


        public string MobClass { get; set; }
        public string Weapon { get; set; }
        public string Inventory { get; set; }
    }
}
