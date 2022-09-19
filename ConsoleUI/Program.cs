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
            Game();
            //Console.WriteLine(MakeLists.ItemDisplay());
        }

         static void Game()
        {
            //string charName = LoadPlayer.PlayerInfo();
            GameMenuSwitcher.MainMenu();
        }

    }
}
