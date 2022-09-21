using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MortuusClassLibrary;

namespace ConsoleUI
{
    class Program
    {
        List<Item> gameItems = new List<Item>();

        static void Main(string[] args)
        {
            //Game();
            //Console.WriteLine(MakeLists.ItemDisplay());
            List<Room> roomTest = SqliteDataAccess.LoadRooms();


            foreach (Room room in roomTest)
            {
                Console.WriteLine(room.Name);
            }

            List<Weapon> weaponTest = SqliteDataAccess.LoadWeapons();

            foreach (Weapon weapon in weaponTest)
            {
                Console.WriteLine(weapon.DamageType);
            }

            Console.WriteLine();
            Console.ReadKey();
        }

         static void Game()
        {


            //string charName = LoadPlayer.PlayerInfo();
            //GameMenuSwitcher.MainMenu();
        }

    }
}
