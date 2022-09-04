using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortuusClassLibrary
{
    public class MovePlayer
    {
        const int MAP_WIDTH = 3;
        const int MAP_LENGTH = 3;
        // AN - map is stacked so:
        // north + 1
        // south - 2
        // east  + MAP_WIDTH
        // west  - MAP_WIDTH
        //public static List<string> roomList = new List<string>(OptionsMenuClass.ListOption("rooms")); //TODO Write code to back this up
        public static int MoveNorth(ref int currentLocation)
        {
            if (currentLocation != (MAP_WIDTH - 1) && currentLocation != (MAP_WIDTH * 2) - 1 && currentLocation != (MAP_WIDTH * 3) - 1)
            {
                currentLocation++;
            }
            return currentLocation;
        }
        public static int MoveSouth(ref int currentLocation)
        {

            if (currentLocation != 0 && currentLocation != MAP_WIDTH && currentLocation != MAP_WIDTH * 2)
            {
                currentLocation--;
            }
            return currentLocation;
        }
        public static int MoveEast(ref int currentLocation)
        {
            if (currentLocation + MAP_WIDTH <= MakeLists.playerRooms.Count - 1) //TODO fix the above public static List
            {
                currentLocation += MAP_WIDTH;
            }
            return currentLocation;
        }
        public static int MoveWest(ref int currentLocation)
        {
            if (currentLocation - MAP_WIDTH >= 0)
            {
                currentLocation -= MAP_WIDTH;
            }
            return currentLocation;
        }
    }
}
