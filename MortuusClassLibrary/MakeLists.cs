using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MortuusClassLibrary
{
    public class MakeLists
    {
        public static List<Item> itemInventoryList = new List<Item>();
        public static List<Weapon> weaponInventoryList = new List<Weapon>();


        public static List<string> items = ReadFile.FileReader("Item.csv");
        public static List<string> mobs = ReadFile.FileReader("Mobs.csv");
        public static List<string> rooms = ReadFile.FileReader("Rooms.csv");
        public static List<string> weapons = ReadFile.FileReader("Weapons.csv");
        public static List<string> potions = ReadFile.FileReader("Potions.csv");
        public static List<string> treasures = ReadFile.FileReader("Treasure.csv");

        public static List<Room> playerRooms = new List<Room>();
        public static List<Item> gameItems = new List<Item>();
        public static List<Mob> gameMobs = new List<Mob>();
        public static List<Weapon> gameWeapons = new List<Weapon>();
        public static List<Treasure> gameTreasures = new List<Treasure>();
        public static List<Potion> gamePotions = new List<Potion>();

        public static List<Item> ItemsFileReader()
        {
            foreach (string item in items)
            {
                //bool isQuestItem;
                string[] tokens = item.Split(',');
                //Console.WriteLine(tokens[0] + " " + " " + tokens[1] + " " + tokens[2]+ " " + tokens[3]+ " " + tokens[4] + " ");
                //isQuestItem = bool.Parse(tokens[3]);
                Item gameItem = new Item(tokens[0], tokens[1], tokens[2], tokens[3], tokens[4]);
                gameItems.Add(gameItem);
                //Console.WriteLine(gameItem.ToString());
            }
            foreach (var item in gameItems)
            {
                Console.WriteLine(item.Name);
            }
            return gameItems;
        }

        /*public static List<Item> ItemDisplay(List<Item>gameItems)
        {
            foreach (var item in gameItems)
            {
                Console.WriteLine(items);
            }
            return gameItems;
        }*/

        public static List<Mob> MobsFileReader()
        {
            foreach (string mob in mobs)
            {
                string[] tokens = mob.Split(',');
                int mobHp;
                int mobAc;
                mobHp = int.Parse(tokens[4]);
                mobAc = int.Parse(tokens[5]);
                Mob gameMob = new Mob(tokens[0], tokens[1], tokens[2], tokens[3], mobHp, mobAc, tokens[6], tokens[7], tokens[8]);
                gameMobs.Add(gameMob);
            }
            foreach (var mob in gameMobs)
            {
                Console.WriteLine(mob.Name);
            }
            return gameMobs;

        }
        public static void RoomFileReader()
        {
            foreach (var room in rooms)
            {
                string[] tokens = room.Split(',');
                //int idNumber;
                //idNumber = int.Parse(tokens[0]);
                Room playerRoom = new Room(tokens[0], tokens[1], tokens[2], tokens[3]);
                playerRooms.Add(playerRoom);
            }
            
        }

        public static List<Room> RoomFileDisplay()
        {
            foreach (var room in rooms)
            {
                string[] tokens = room.Split(',');
                Room playerRoom = new Room(tokens[0], tokens[1], tokens[2], tokens[3]);
                playerRooms.Add(playerRoom);
                
            }
            foreach (var room in playerRooms)
            {
             Console.WriteLine(room.Name);
            }
            return playerRooms;
        }

        public static List<Weapon> WeaponsFileReader()
        {
            foreach (string weapon in weapons)
            {
                string[] tokens = weapon.Split(',');
                int damage;
                damage = int.Parse(tokens[4]);
                Weapon gameWeapon = new Weapon(tokens[0], tokens[1], tokens[2], tokens[3], damage, tokens[5]);
                gameWeapons.Add(gameWeapon);
            }
            foreach (var weapon in gameWeapons)
            {
                Console.WriteLine(weapon.Name);
            }
            return gameWeapons;
        }

        public static List<Potion> PotionsFileReader()
        {
            foreach (string potion in potions)
            {
                string[] tokens = potion.Split(',');
                int valueChange;
                int healthPotion;
                valueChange = int.Parse(tokens[4]);
                healthPotion = int.Parse(tokens[5]);
                Potion gamePotion = new Potion(tokens[0], tokens[1], tokens[2], tokens[3], valueChange, healthPotion);
                gamePotions.Add(gamePotion);
            }
            foreach (var potion in gamePotions)
            {
                Console.WriteLine(potion.Name);
            }
            return gamePotions;
        }

        public static List<Treasure> TreasureFileReader()
        {
            foreach (string treasure in treasures)
            {
                string[] tokens = treasure.Split(',');
                Treasure gameTreasure = new Treasure(tokens[0], tokens[1], tokens[2], tokens[3], tokens[4]);
                gameTreasures.Add(gameTreasure);
            }
            foreach (var treasure in gameTreasures)
            {
                Console.WriteLine(treasure.Name);
            }
            return gameTreasures;
        }

        public static List<string> MainMenu()
        {
            List<string> menuList = ReadFile.FileReader("mainMenu.txt");
            //optionList.Sort();
            foreach (var option in menuList)
            {
                Console.WriteLine(option);
            }
            return menuList;
        }
    }

}
