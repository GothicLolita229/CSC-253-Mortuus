using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortuusClassLibrary
{
    public class Potion : IngameItem
    {
        private string _idNumber;
        private string _name;
        private string _description;
        private string _price;
        private int _valueChange;
        private int _healthPotion = 20;

        public Potion(string idNumber, string name, string description, string price, int valueChange, int healthPotion)
            : base(idNumber, name, description, price)
        {
            _idNumber = idNumber;
            _name = name;
            _description = description;
            _valueChange = valueChange;
            _healthPotion = healthPotion;
        }

        public int ValueChange
        {
            get { return _valueChange; }
            set { }
        }
        public int HealthPotion
        {
            get { return _healthPotion; }
            set { }
        }
    }
}
