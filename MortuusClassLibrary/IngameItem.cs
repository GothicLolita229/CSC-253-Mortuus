using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortuusClassLibrary
{
    public abstract class IngameItem
    {
        private int _idNumber;
        private string _name;
        private string _description;
        private string _price;

        public IngameItem() { }
        public IngameItem(int idNumber, string name, string description, string price)
        {
            _idNumber = idNumber;
            _name = name;
            _description = description;
            _price = price;

        }

        /*protected IngameItem()
        {
        }*/

        public int IDNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
    }
}
