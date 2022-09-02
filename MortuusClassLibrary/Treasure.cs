using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortuusClassLibrary
{
    class Treasure : IngameItem
    {
        private string _idNumber;
        private string _name;
        private string _description;
        private string _questItem;
        private string _price;

        public Treasure(string idNumber, string name, string description, string questItem, string price)
            : base(idNumber, name, description, price)
        {
            _idNumber = idNumber;
            _name = name;
            _description = description;
            _questItem = questItem;
            _price = price;
        }

        public string QuestItem { get; set; }
    }
}
