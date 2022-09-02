using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortuusClassLibrary
{
    public class Weapon : IngameItem
    {
        private string _idNumber;
        private string _name;
        private string _description;
        private string _damageType;
        private int _damage;
        private string _price;

        public Weapon(string idNumber, string name, string description, string damageType, int damage, string price)
            : base(idNumber, name, description, price)
        {
            _idNumber = idNumber;
            _name = name;
            _description = description;
            _damageType = damageType;
            _damage = damage;
            _price = price;
        }


        public string DamageType { get; set; }
        public string Damage { get; set; }
    }
}
