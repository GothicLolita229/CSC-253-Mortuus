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
            Room.RoomDisplay();
            //Room.RoomExitDisplay(); //Change Exits to ints that display roomID numbers and then use those
                                    // with a switch statement to move to different rooms. For example 
                                    // The Foyer has exits (0, 1, 3, 5) where 0 is north and there is no room
                                    // 1 is back to the entrance, 3 is the Great Hall and, 5 is store room.
                                    // Or make a map with only two exits per room like Mr. Norris suggested
            Game();
        }

         static void Game()
        {
            //string charName = LoadPlayer.PlayerInfo();
            GameMenuSwitcher.MainMenu();
        }

    }
}
