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
        delegate int AttackPoints(int hp);
        delegate int HealthPoints(int hp, int damage);
        delegate void EnemyDialog();
      
        static void Main(string[] args)
        {
            Room.RoomDisplay();
            
            Game();
        }

         public static void Game()
        {
            AttackPoints Attack = CombatSystem.AttackPoints;
            HealthPoints HP = CombatSystem.CalcHealth;
            EnemyDialog DisplayDialog = delegate ()
            {
                Console.WriteLine("That serves you right! It'll teach you not to challenge us again. You hear the enemies shout as your vision fades.");
            };
            Player player = LoadPlayer.PlayerInfo();

            Action<string> WL = words => Console.WriteLine(words);

            string charName = player.Name;
            int damage; // = CombatSystem.damage;
            int hp = player.HP;
            char userChoice;
            int currentLocation = 301;
            WL("MAIN MENU: \n");
            OptionsMenu.HelpMenu();
            WL($"{charName}, enter numeric value from menu to select an option: ");
            do
            {
                Room thisRoom = SqliteDataAccess.LoadRoom(currentLocation);
                WL("\n");
                WL($"You are in {thisRoom.Name} ( {thisRoom.ID} )");
                WL(thisRoom.Description);
                WL("Your exit(s) are ");
                if (thisRoom.NorthExit != -1) { WL(" N "); }
                if (thisRoom.SouthExit != -1) { WL(" S "); }
                if (thisRoom.WestExit != -1) { WL(" W "); }
                if (thisRoom.EastExit != -1) { WL(" E "); }
                WL("");
                userChoice = Console.ReadLine()[0];
                //userChoice = Console.ReadLine()[0];

                switch (userChoice)
                {
                    case '1':
                        if (thisRoom.NorthExit != -1)
                        { currentLocation = thisRoom.NorthExit; }
                        else { WL("There is nothing for you here."); }
                        break;
                    case '2':
                        if (thisRoom.SouthExit != -1)
                        { currentLocation = thisRoom.SouthExit; }
                        else { WL("Why would you walk into a wall?"); }
                        break;
                    case '3':
                        if (thisRoom.WestExit != -1)
                        { currentLocation = thisRoom.WestExit; }
                        else { WL("The definition of insanity is doing the same thing over and over... I'm sure you've heard this before"); }
                        break;
                    case '4':
                        if (thisRoom.EastExit != -1)
                        { currentLocation = thisRoom.EastExit; }
                        else { WL("Sorry, you can't walk through walls.... yet"); }
                        break;
                    case '5':
                        // TODO Move entire to combat Class method and then just call method here
                        if (hp >= 1)
                        {
                            WL("You are in a fight!");
                            //WL("Enter action: (a) for attack or any other key to exit.");
                            damage = Attack(player.HP);
                            //damage = CombatSystem.AttackPoints(player.HP);
                            WL($"You've taken {damage} points of damage");
                            hp = HP(hp, damage);
                            //hp = CombatSystem.CalcHealth(ref hp, damage);
                            WL($"Your hp is at {hp}\n");
                        }
                        else
                        {
                            DisplayDialog();
                            WL("You are dead.");
                        }
                        break;
                    case '6':
                        OptionsMenu.Exit();
                        break;
                    case '7':
                        OptionsMenu.WriteExploreMenu();
                        //WL("Menu");
                        char menuOption = Console.ReadLine()[0];
                        OptionsMenu.ExploreMenu(menuOption);
                        break;
                    default:
                        WL("Not a valid option. Maybe check your case and spelling?");
                        break;
                }
            }
            while (userChoice != '6');
            WL("Press enter to exit...");
            // Program ends
            Console.ReadLine();
        
        }
    }
}
/**
* CSC 253
* Lourdes Linares and Ciara McLaughlin
* This program is a maze/rpg text adventure game. 
*/
