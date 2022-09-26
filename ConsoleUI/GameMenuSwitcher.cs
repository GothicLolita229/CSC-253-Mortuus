using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MortuusClassLibrary;

namespace ConsoleUI
{
    public class GameMenuSwitcher
    {
        //public static char userChoice; //where is this coming from? because I think that's why game doesn't continue
          // =Player.player.Location; ???

        
        public static void MainMenu()
        {
            string charName = "Ciara"; //LoadPlayer.PlayerInfo();
            int damage; // = CombatSystem.damage;
            int hp = Player.HP;
            char userChoice;
            int currentLocation = 301;
            Console.WriteLine("MAIN MENU: \n");
            OptionsMenu.HelpMenu();
            Console.Write($"{charName}, enter numeric value from menu to select an option: ");
            do
            {
                Room thisRoom = SqliteDataAccess.LoadRoom(currentLocation);
                Console.WriteLine("\n");
                Console.WriteLine($"You are in {thisRoom.Name} ( {thisRoom.ID} )");
                Console.WriteLine(thisRoom.Description);
                Console.Write("Your exit(s) are ");
                if (thisRoom.NorthExit != -1) { Console.Write(" N "); }
                if (thisRoom.SouthExit != -1) { Console.Write(" S "); }
                if (thisRoom.WestExit != -1) { Console.Write(" W "); }
                if (thisRoom.EastExit != -1) { Console.Write(" E "); }
                Console.WriteLine();
                userChoice = Console.ReadLine()[0];
                //userChoice = Console.ReadLine()[0];

                switch (userChoice)
                {
                    case '1':
                        if (thisRoom.NorthExit != -1)
                        { currentLocation = thisRoom.NorthExit; }
                        else { Console.WriteLine("There is nothing for you here."); }
                        break;
                    case '2':
                        if (thisRoom.SouthExit != -1)
                        { currentLocation = thisRoom.SouthExit; }
                        else { Console.WriteLine("Why would you walk into a wall?"); }
                        break;
                    case '3':
                        if (thisRoom.WestExit != -1)
                        { currentLocation = thisRoom.WestExit; }
                        else { Console.WriteLine("The definition of insanity is doing the same thing over and over... I'm sure you've heard this before"); }
                        break;
                    case '4':
                        if (thisRoom.EastExit != -1)
                        { currentLocation = thisRoom.EastExit; }
                        else { Console.WriteLine("Sorry, you can't walk through walls.... yet"); }
                        break;
                    case '5':
                        // TODO Move entire to combat Class method and then just call method here
                        if (hp >= 1)
                        {
                            Console.WriteLine("You are in a fight!");
                            //Console.WriteLine("Enter action: (a) for attack or any other key to exit.");
                            damage = CombatSystem.AttackPoints();
                            Console.WriteLine($"You've taken {damage} points of damage");
                            hp = CombatSystem.CalcHealth(ref hp, damage);
                            Console.WriteLine($"Your hp is at {hp}\n");
                        }
                        else
                        {
                            Console.WriteLine("You are dead.");
                        }
                        break;
                    case '6':
                        OptionsMenu.Exit();
                        break;
                    case '7':
                        OptionsMenu.WriteExploreMenu();
                        //Console.WriteLine("Menu");
                        char menuOption = Console.ReadLine()[0];
                        OptionsMenu.ExploreMenu(menuOption);
                        break;
                    default:
                        Console.WriteLine("Not a valid option. Maybe check your case and spelling?");
                        break;
                }
            }
            while (userChoice != '6');
            Console.Write("Press enter to exit...");
            // Program ends
            Console.ReadLine();
        }
    }
}
