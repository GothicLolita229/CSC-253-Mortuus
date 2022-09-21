using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortuusClassLibrary
{
    public class Mob : LivingCreature
    {
        public Mob(string idNumber, string name, string race, string mobClass, int hp, int ac, string weapon, string description, string inventory)
            : base(idNumber, name, race, mobClass, description, hp, ac)
        {
            MobClass = mobClass;               
            Weapon = weapon;
            Inventory = inventory;
        }


        public string MobClass {get; set;}
        public string Weapon {get; set;}
        public string Inventory {get; set;}
    }
}
