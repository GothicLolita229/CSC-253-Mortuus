using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortuusClassLibrary
{
    public class Potion : IngameItem
    {
        public static List<Potion> potions = SqliteDataAccess.LoadPotions();

        //private int _valueChange;
        //private int _healthPotion = 20;

        public Potion() : base() { }

        public Potion(int idNumber, string name, string description, string price, int valueChange, int healthPotion)
            : base(idNumber, name, description, price)
        {
            ValueChange = valueChange;
            HealthPotion = healthPotion;
        }
        public int ValueChange { get; set; }
        public int HealthPotion { get; set; }

        public static List<Potion> PotionDisplay()
        {
            foreach (Potion potion in potions)
            {
                Console.WriteLine(potion.Name);
            }
            return potions;
        }
    }
}
/**
* CSC 253
* Lourdes Linares and Ciara McLaughlin
* This program is a maze/rpg text adventure game. 
*/