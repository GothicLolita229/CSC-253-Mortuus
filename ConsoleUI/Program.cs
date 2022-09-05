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
        
        static void Main(string[] args)
        {
            Game();
        }

         static void Game()
        {
            //string charName = LoadPlayer.PlayerInfo();
            GameMenuSwitcher.MainMenu();
        }

    }
}
