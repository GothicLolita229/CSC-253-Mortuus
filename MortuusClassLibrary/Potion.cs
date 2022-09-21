using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortuusClassLibrary
{
    public class Potion : IngameItem
    {
        private int _valueChange;
        private int _healthPotion = 20;

        public Potion(int idNumber, string name, string description, string price, int valueChange, int healthPotion)
            : base(idNumber, name, description, price)
        {
            _valueChange = valueChange;
            _healthPotion = healthPotion;
        }
        public int ValueChange { get; set; }
        public int HealthPotion { get; set; }
    }
}
