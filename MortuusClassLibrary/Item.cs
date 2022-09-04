using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortuusClassLibrary
{
    public class Item : IngameItem
    {
        private string _idNumber;
        private string _name;
        private string _description;
        private bool _questItem;
        private string _price;

        public Item(string idNumber, string name, string description, bool questItem, string price)
            : base(idNumber, name, description, price)
        {
            _idNumber = idNumber;
            _name = name;
            _description = description;
            _questItem = questItem;
            _price = price;
        }
        public bool QuestItem { get; set; }
    }
}
