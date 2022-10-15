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
            string username;
            WL("Enter your username: ");
            username = Console.ReadLine();

            // does file with username.txt exist?
            string charName = "";
            try
            {
                player = SqliteDataAccess.LoadPlayer(username);
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
            catch
            {
                try
                {
                    if (File.Exists(username + ".txt")) //if (username == Player.Name)
                    {
                        charName = ReturnPlayer(username);
                    }
                    else
                    {
                        charName = NewPlayer(username);
                    }
                }
                catch (Exception ex)
                {
                    WL("Error checking file..." + ex.Message);
                }
                
            }
            
            return player;
        }
        /*public static string NewPlayer(string username)
        {
            // make file with username as name
            Action<string> WL = words => Console.WriteLine(words);
            StreamWriter outputfile;
            string charName;
            string playerRace;
            string playerClass;
            string playerWeapon;
            try
            {
                outputfile = File.CreateText(username + ".txt");
                WL($"Welcome, {username}!");
                WL("Let's create a character for you...");
                //for some reason have to close file and then open again to append text
                outputfile.Close();
                try
                {
                    outputfile = File.AppendText(username + ".txt");
                    WL("What would you like to name your character?");
                    charName = Console.ReadLine();
                    WL("Choose and enter your race: ");
                    playerRace = Console.ReadLine();
                    WL("Choose and enter your class: ");
                    playerClass = Console.ReadLine();
                    WL("Choose and enter your weapon: ");
                    playerWeapon = Console.ReadLine();
                    outputfile.WriteLine(charName, playerRace, playerClass, playerWeapon);
                    outputfile.Close();
                }
                catch (Exception ex)
                {
                    WL(ex.Message);
                    throw;
                }
            }
            catch (Exception)
            {
                WL("Error making character...");
                throw;
            }
            return charName;
        }*/

        public static string NewPlayer(string username)
        {
            // make file with username as name
            Action<string> WL = words => Console.WriteLine(words);
            Func<string> RL = Console.ReadLine;
            Player player = new Player();
            
            try
            {
                WL($"Welcome, {username}!");
                WL("Let's create a character for you...");
                try
                {
                    //int id, string name, string race, string lcclass, string description,
                    //string weapon, int hp, int ac, string password, int location
                    //outputfile = File.AppendText(username + ".txt");
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
                    


                }
                catch (Exception ex)
                {
                    WL(ex.Message);
                    throw;
                }
            }
            catch (Exception)
            {
                WL("Error making character...");
                throw;
            }
            return player.Name;
        }

        public static string ReturnPlayer(string username)
        {
            // get input from file with playername.txt
            Action<string> WL = words => Console.WriteLine(words);
            StreamReader inputfile;
            string charName;

            inputfile = File.OpenText(username + ".txt");
            charName = inputfile.ReadLine();
            List<string> playerFile = ReadFile.FileReader($"{username}.txt");

            foreach (var item in playerFile)
            {
                WL(item);
            }
            WL($"Welcome back, {username}!");

            inputfile.Close();
            return charName;
        }
    }
}
/**
* CSC 253
* Lourdes Linares and Ciara McLaughlin
* This program is a maze/rpg text adventure game. 
*/
