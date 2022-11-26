using MortuusClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WpfMUI
{
    public class LoadPlayer
    {
        
        public static Player PlayerInfo(MainWindow window)
        {
            
            Player player = new Player();
            //Action<string> ChangeLabel = words => Console.WriteLine(words);
            //ChangeLabel("Enter your username: ");
            string username = "Vecna"; //Console.ReadLine();
            player = SqliteDataAccess.LoadPlayer(username);
            // does player with same username exist?
            string charName;
            try
            {
                if (player == null)
                {
                    charName = NewPlayer(username, window);
                }
                else
                {
                    //ChangeLabel("Enter your password: ");
                    string password = "NoShoes!";//Console.ReadLine();
                    if (password == player.Password)
                    {
                        charName = ReturnPlayer(username, window);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return player;
        }
        public static string NewPlayer(string username, MainWindow window)
        {
            //Action<string> ChangeLabel = words => Console.WriteLine(words);
            Func<string> RL = Console.ReadLine;
            Player player = new Player();

            try
            {
                window.ChangeLabel($"Welcome, {username}!");
                window.ChangeLabel("Let's create a character for you...");
                window.ChangeLabel("What would you like to name your character?");
                player.Name = RL();
                window.ChangeLabel("Choose and enter your race: ");
                player.Race = RL();
                window.ChangeLabel("Choose and enter your class: ");
                player.LcClass = RL();
                window.ChangeLabel("Enter your character's description: ");
                player.Description = RL();
                window.ChangeLabel("Choose and enter your weapon: ");
                player.Weapon = RL();
                player.HP = 100;
                player.AC = 15;
                player.Location = 301;
                string password;
                bool valid = false;

                while (!valid)
                {
                    window.ChangeLabel("Enter your password (Must contain a capital, lowercase and special character): ");
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
                        window.ChangeLabel("Enjoy the game!");
                        player.Password = password;
                    }
                }
                SqliteDataAccess.SavePlayer(player);
            }
            catch (Exception ex)
            {
                window.ChangeLabel("Error making character...");
                window.ChangeLabel(ex.Message);
                throw;
            }
            return player.Name;
        }
        public static string ReturnPlayer(string username, MainWindow window)
        {
            //Action<string> ChangeLabel = words => Console.WriteLine(words);
            Player player = SqliteDataAccess.LoadPlayer(username);
            window.ChangeLabel($"Welcome back, {username}!");
            return player.Name;
        }
    }
}
