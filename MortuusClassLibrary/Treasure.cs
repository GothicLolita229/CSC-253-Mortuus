using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortuusClassLibrary
{
    public class Treasure : IngameItem
    {
        public Treasure(int idNumber, string name, string description, string questItem, string price)
            : base(idNumber, name, description, price)
        {
            QuestItem = questItem;
        }

        public string QuestItem { get; set; }
    }
}
