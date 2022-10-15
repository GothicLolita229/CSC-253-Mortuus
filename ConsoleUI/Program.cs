using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MortuusClassLibrary;

/**
* CSC 253
* Lourdes Linares and Ciara McLaughlin
* This program is a maze/rpg text adventure game. 
*/

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Room.RoomDisplay();
            
            Game();
        }

         static void Game()
        {
            //string charName = LoadPlayer.PlayerInfo();
            GameMenuSwitcher.MainMenu();
        }

    }
}
/**
* CSC 253
* Lourdes Linares and Ciara McLaughlin
* This program is a maze/rpg text adventure game. 
*/
