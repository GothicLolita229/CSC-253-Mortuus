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
                    Room.RoomDisplay(); 
                    //Console.WriteLine(Room.rooms);
                    break;
                case '2':
                    Console.WriteLine(Weapon.weapons);
                    break;
                case '3':
                    Console.WriteLine(Potion.potions);
                    break;
                case '4':
                    Console.WriteLine(Treasure.treasures);
                    break;
                case '5':
                    Item.ItemDisplay();
                    Console.WriteLine(Item.items);
                    break;
                case '6':
                    Console.WriteLine(Mob.mobs);
                    break;
                case '7':
                    GameMenuSwitcher.MainMenu();
                    break;
                default:
                    Exit();
                    break;
            }
        }

        public static void WriteExploreMenu()
        {
            Console.WriteLine("1. View Rooms");
            Console.WriteLine("2. View Weapons");
            Console.WriteLine("3. View Potions");
            Console.WriteLine("4. View Treasures");
            Console.WriteLine("5. View Items");
            Console.WriteLine("6. View Mobs");
            Console.WriteLine("7. Back to Main");
        }

        public static void Exit()
        {
            Environment.Exit(0);
        }

        public static void HelpMenu()
        {
            Console.WriteLine("1. Move North");
            Console.WriteLine("2. Move South");
            Console.WriteLine("3. Move West");
            Console.WriteLine("4. Move East");
            Console.WriteLine("5. Attack");
            Console.WriteLine("6. Exit");
            Console.WriteLine("7. Menu");
        }

    }
}
