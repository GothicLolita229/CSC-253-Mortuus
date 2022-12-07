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
            Game();
        } 
        public static void Game()
        {
            AttackPoints Attack = CombatSystem.AttackPoints;
            AttackPoints Attack2 = CombatSystem.AttackPoints;
            HealthPoints HP = CombatSystem.CalcHealth;
            EnemyDialog DisplayDialog = delegate ()
            {
                Console.WriteLine("That serves you right! It'll teach you not to challenge us again. You hear the enemies shout as your vision fades.");
            };
            Player player = LoadPlayer.PlayerInfo();

            Action<string> WL = words => Console.WriteLine(words);

            string charName = "Mujika";
            int damage;
            int mobHp;
            bool hasEscaped = false;
            int hp = player.HP;
            char userChoice;
            int currentLocation = 301;
            Console.WriteLine(SqliteDataAccess.LoadWeapon(701).Name);
            WL("MAIN MENU: \n");
            OptionsMenu.HelpMenu();
            WL($"{charName}, enter numeric value from menu to select an option: ");
            do
            {
                Room thisRoom = SqliteDataAccess.LoadRoom(currentLocation);
                Mob thisMob = Mob.MobSpawner();
                mobHp = thisMob.HP;
                WL("\n");
                WL($"You are in {thisRoom.Name} ( {thisRoom.ID} )");
                WL("There is a " + thisMob.Name + " in the room with you!");
                WL(thisRoom.Description);
                WL("Your exit(s) are ");
                if (thisRoom.NorthExit != -1) { WL(" N "); }
                if (thisRoom.SouthExit != -1) { WL(" S "); }
                if (thisRoom.WestExit != -1) { WL(" W "); }
                if (thisRoom.EastExit != -1) { WL(" E "); }
                WL("");
                userChoice = Console.ReadLine()[0];

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
                        while (mobHp >= 1 && hasEscaped != true && hp >= 1)
                        {
                            if (hp >= 1)
                            {
                                WL("You are in a fight with " + thisMob.Name + " who currently has " + mobHp + "!");
                                WL("1. Attack");
                                WL("2. Run away");
                                char combatChoice = Console.ReadLine()[0];
                                if (combatChoice == '1')
                                {
                                    int damage2 = Attack2(thisMob.HP);
                                    WL("You've hit the " + thisMob.Name + " for " + damage2 + "!");
                                    mobHp = HP(mobHp, damage2);
                                    damage = Attack(player.HP);
                                    WL($"You've taken {damage} points of damage");
                                    hp = HP(hp, damage);
                                    WL($"Your hp is at {hp}\n");
                                }
                                else if (combatChoice == '2')
                                {
                                    hasEscaped = CombatSystem.Escape(hasEscaped);
                                    if (hasEscaped == true)
                                    {
                                        WL("You've escaped successfully!");

                                    }
                                    else
                                    {
                                        WL("You've failed to escape!");
                                        damage = Attack(player.HP);
                                        WL($"You've taken {damage} points of damage");
                                        hp = HP(hp, damage);
                                        WL($"Your hp is at {hp}\n");
                                    }
                                }
                                else
                                {
                                    WL("Not a valid choice!");
                                }
                            }
                        }
                        if (mobHp < 1)
                        {
                            WL("You've killed the enemy!");
                        }
                        else if (hp < 1)
                        {
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

        public static List<object> ShowStuffs(int thisRoom)
        {
            List<object> roomInv = SqliteDataAccess.LoadRoomInv(thisRoom);
            /*for(int i=0; i <= roomInv.Count; i++)
            {
               
            }*/
            if (!roomInv[2].Equals(-1))
            {
                Item item = SqliteDataAccess.LoadItem(roomInv[2]);
                roomInv[2] = item; //QuestItem
            }
            if (!roomInv[3].Equals(-1))
            {
                Weapon weapon = SqliteDataAccess.LoadWeapon(roomInv[3]);
                roomInv[3] = weapon; //Weapon
            }
            if (!roomInv[4].Equals(-1))
            {
                Potion potion = SqliteDataAccess.LoadPotion(roomInv[4]);
                roomInv[4] = potion; //Potion
            }
            if (!roomInv[5].Equals(-1))
            {
                Treasure treasure = SqliteDataAccess.LoadTreasure(roomInv[5]);
                roomInv[5] = treasure; //Treasure
            }
            if (!roomInv[6].Equals(-1))
            {
                Mob mob = SqliteDataAccess.LoadMob(roomInv[6]);
                roomInv[6] = mob; //Mob
            }

            return roomInv;
        }
    }
}
/**
* CSC 253
* Lourdes Linares and Ciara McLaughlin
* This program is a maze/rpg text adventure game. 
*/
