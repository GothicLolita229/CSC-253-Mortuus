using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortuusClassLibrary
{
    public abstract class IngameItem
    {
        public IngameItem() { }
        public IngameItem(int idNumber, string name, string description, string price)
        {
            IDNumber = idNumber;
            Name = name;
            Description = description;
            Price = price;

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
/**
* CSC 253
* Lourdes Linares and Ciara McLaughlin
* This program is a maze/rpg text adventure game. 
*/
