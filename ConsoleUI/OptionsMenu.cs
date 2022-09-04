using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleUI
{
    class OptionsMenu
    {
        public static void ExploreMenu(char userChoice)
        {
            switch (userChoice)
            {
                case '1':
                    RoomFileReader();
                    break;
                case '2':
                    WeaponsFileReader();
                    break;
                case '3':
                    PotionsFileReader();
                    break;
                case '4':
                    TreasureFileReader();
                    break;
                case '5':
                    ItemsFileReader();
                    break;
                case '6':
                    MobsFileReader();
                    break;
                case '7':
                    MainMenuFileReader();
                default:
                    Exit();
                    break;
            }
        }
    }
}
