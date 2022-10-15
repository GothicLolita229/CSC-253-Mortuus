using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortuusClassLibrary
{
    public class Treasure : IngameItem
    {
        public static List<Treasure> treasures = SqliteDataAccess.LoadTreasuresList();
        public Treasure() :base() { }
        public Treasure(int idNumber, string name, string description, string questItem, string price)
            : base(idNumber, name, description, price)
        {
            QuestItem = questItem;
        }

        public string QuestItem { get; set; }
        public static List<Treasure> TreasureDisplay()
        {
            foreach (Treasure treasure in treasures)
            {
                Console.WriteLine(treasure.Name);
            }
            return treasures;
        }
    }
}
/**
* CSC 253
* Lourdes Linares and Ciara McLaughlin
* This program is a maze/rpg text adventure game. 
*/