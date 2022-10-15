using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortuusClassLibrary
{
    public class Weapon : IngameItem
    {
        public static List<Weapon> weapons = SqliteDataAccess.LoadWeaponsList();
        public Weapon(): base() { }
        public Weapon(int idNumber, string name, string description, string damageType, int damage, string price)
            : base(idNumber, name, description, price)
        {
            DamageType = damageType;
            Damage = damage;
        }
        public string DamageType { get; set; }
        public int Damage { get; set;}

        public static List<Weapon> WeaponDisplay()
        {
            foreach (Weapon weapon in weapons)
            {
                Console.WriteLine(weapon.Name);
            }
            return weapons;
        }
    }
}
/**
* CSC 253
* Lourdes Linares and Ciara McLaughlin
* This program is a maze/rpg text adventure game. 
*/