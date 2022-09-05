using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MortuusClassLibrary;

namespace ConsoleUI
{
    class OptionsMenu
    {
        
        public static void ExploreMenu(char userChoice)
        {

            switch (userChoice)
            {
                case '1':
                    
                    Console.WriteLine(MakeLists.playerRooms);
                    break;
                case '2':
                    Console.WriteLine(MakeLists.gameWeapons);
                    break;
                case '3':
                    Console.WriteLine(MakeLists.gamePotions);
                    break;
                case '4':
                    Console.WriteLine(MakeLists.gameTreasures);
                    break;
                case '5':
                    MakeLists.ItemsFileReader();
                    Console.WriteLine(MakeLists.gameItems);
                    break;
                case '6':
                    Console.WriteLine(MakeLists.gameMobs);
                    break;
                case '7':
                    GameMenuSwitcher.MainMenu();
                    break;
                default:
                    Exit();
                    break;
            }
        }

        public static void Exit()
        {
            Environment.Exit(0);
        }

    }
}
