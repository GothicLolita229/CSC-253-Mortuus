using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortuusClassLibrary
{
    public class Weapon : IngameItem
    {
        public Weapon(): base() { }
        public Weapon(int idNumber, string name, string description, string damageType, int damage, string price)
            : base(idNumber, name, description, price)
        {
            DamageType = damageType;
            Damage = damage;
        }
        public string DamageType { get; set; }
        public int Damage { get; set;}
    }
}
