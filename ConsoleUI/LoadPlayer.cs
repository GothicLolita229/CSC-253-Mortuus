using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using MortuusClassLibrary;

namespace ConsoleUI
{
    class LoadPlayer
    {
        public static Player PlayerInfo()
        {
            Player player = new Player();
            Action<string> WL = words => Console.WriteLine(words);
            WL("Enter your username: ");
            string username = Console.ReadLine();
            player = SqliteDataAccess.LoadPlayer(username);
            // does player with same username exist?
            string charName;
            try
            {
                if (player == null)
                {
                    charName = NewPlayer(username);
                }
                else
                {
                    WL("Enter your password: ");
                    string password = Console.ReadLine();
                    if (password == player.Password)
                    {
                        charName = ReturnPlayer(username);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            return player;
        }
        public static string NewPlayer(string username)
        {
            Action<string> WL = words => Console.WriteLine(words);
            Func<string> RL = Console.ReadLine;
            Player player = new Player();
            
            try
            {
                WL($"Welcome, {username}!");
                WL("Let's create a character for you...");
                WL("What would you like to name your character?");
                player.Name = RL();
                WL("Choose and enter your race: ");
                player.Race = RL();
                WL("Choose and enter your class: ");
                player.LcClass = RL();
                WL("Enter your character's description: ");
                player.Description = RL();
                WL("Choose and enter your weapon: ");
                player.Weapon = RL();
                player.HP = 100;
                player.AC = 15;
                player.Location = 301;
                string password;
                bool valid = false;

                while (!valid)
                {
                    WL("Enter your password (Must contain a capital, lowercase and special character): ");
                    password = RL();
                    valid = Player.CheckPassword(ref password);
                    if (valid == false)
                    {
                        Console.WriteLine("Enter your password (Must contain a capital, lowercase and special character): ");
                        password = RL();
                    }
                    else
                    {
                        valid = true;
                        WL("Enjoy the game!");
                        player.Password = password;
                    }
                }
                SqliteDataAccess.SavePlayer(player);
            }
            catch (Exception ex)
            {
                WL("Error making character...");
                WL(ex.Message);
                throw;
            }
            return player.Name;
        }
        public static string ReturnPlayer(string username)
        {
            Action<string> WL = words => Console.WriteLine(words);
            Player player = SqliteDataAccess.LoadPlayer(username);
            WL($"Welcome back, {username}!");
            return player.Name;
        }
    }
}
/**
* CSC 253
* Lourdes Linares and Ciara McLaughlin
* This program is a maze/rpg text adventure game. 
*/
