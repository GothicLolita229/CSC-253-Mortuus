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
        //delegate List<Room> Lists(); TEST
        public static void ExploreMenu(char userChoice)
        {
            ///Lists Display = Room.RoomDisplay; TEST
            switch (userChoice)
            {
                case '1':
                    Room.RoomDisplay();
                    //Display; TEST
                    break;
                case '2':
                    Weapon.WeaponDisplay();
                    break;
                case '3':
                    Potion.PotionDisplay();
                    break;
                case '4':
                    Treasure.TreasureDisplay();
                    break;
                case '5':
                    Item.ItemDisplay();
                    break;
                case '6':
                    Mob.MobDisplay();
                    break;
                case '7':
                    Program.Game();
                    break;
                default:
                    Exit();
                    break;
            }
        }
        public static void WriteExploreMenu()
        {
            Action<string> WL = words => Console.WriteLine(words);
            WL("1. View Rooms");
            WL("2. View Weapons");
            WL("3. View Potions");
            WL("4. View Treasures");
            WL("5. View Items");
            WL("6. View Mobs");
            WL("7. Back to Main");
        }
        public static void Exit()
        {
            Environment.Exit(0);
        }
        public static void HelpMenu()
        {
            Action<string> WL = words => Console.WriteLine(words);
            WL("1. Move North");
            WL("2. Move South");
            WL("3. Move West");
            WL("4. Move East");
            WL("5. Attack");
            WL("6. Exit");
            WL("7. Menu");
        }
    }
}
/**
* CSC 253
* Lourdes Linares and Ciara McLaughlin
* This program is a maze/rpg text adventure game. 
*/
