using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MortuusClassLibrary;

namespace WinUI
{
     class LoadPlayerWN
    {
        public static Player PlayerInfo(string username, string password)
        {
            Player player = new Player();
            //Action<string> WL = words => Console.WriteLine(words);
            //WL("Enter your username: ");
            player = SqliteDataAccess.LoadPlayer(username);
            // does player with same username exist?
            string charName;
            try
            {
                if (player == null)
                {
                    MessageBox.Show("Wrong username or password! If you don't have an account, create one!");
                    //charName = NewPlayer(username);
                }
                else
                {
                    //WL("Enter your password: ");
                    //string password = Console.ReadLine();
                    if (password == player.Password)
                    {
                        charName = ReturnPlayer(username);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return player;
        }
        public static string NewPlayer(string username, string password, string race, string userClass, string description, string weapon)
        {
            //Action<string> WL = words => Console.WriteLine(words);
           // Func<string> RL = Console.ReadLine;
            Player player = new Player();

            try
            {
                //WL($"Welcome, {username}!");
                //WL("Let's create a character for you...");
                //WL("What would you like to name your character?");
                player.Name = username;
                //WL("Choose and enter your race: ");
                player.Race = race;
                //WL("Choose and enter your class: ");
                player.LcClass = userClass;
                //WL("Enter your character's description: ");
                player.Description = description;
                //WL("Choose and enter your weapon: ");
                player.Weapon = weapon;
                player.HP = 100;
                player.AC = 15;
                player.Location = 301;
                //string password;
                bool valid = false;

                while (!valid)
                {
                    //WL("Enter your password (Must contain a capital, lowercase and special character): ");
                    //password = RL();
                    valid = Player.CheckPassword(ref password);
                    if (valid == false)
                    {
                        MessageBox.Show("Enter your password (Must contain a capital, lowercase and special character): ");
                        //password = RL();
                    }
                    else
                    {
                        valid = true;
                        MessageBox.Show("Character created successfully!");
                        //WL("Enjoy the game!");
                        player.Password = password;
                    }
                }
                SqliteDataAccess.SavePlayer(player);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error making character...");
                MessageBox.Show(ex.Message);
                throw;
            }
            return player.Name;
        }
        public static string ReturnPlayer(string username)
        {
            Action<string> WL = words => Console.WriteLine(words);
            Player player = SqliteDataAccess.LoadPlayer(username);
            //WL($"Welcome back, {username}!");
            return player.Name;
        }
    }
}
