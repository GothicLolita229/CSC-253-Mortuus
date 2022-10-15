using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortuusClassLibrary
{
    public class Item : IngameItem
    {
        public static List<Item> items = SqliteDataAccess.LoadItemsList();
        public Item() : base() { }
        public Item(int idNumber, string name, string description, string questItem, string price)
            : base(idNumber, name, description, price)
        {
            QuestItem = questItem;
        }
        public string QuestItem { get; set; }

        public static List<Item> ItemDisplay()
        {
            foreach (Item item in items)
            {
                Console.WriteLine(item.Name);
            }
            return items;
        }
    }
}
/**
* CSC 253
* Lourdes Linares and Ciara McLaughlin
* This program is a maze/rpg text adventure game. 
*/
