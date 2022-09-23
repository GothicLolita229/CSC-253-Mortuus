using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class LoadPlayer
    {
        public static string PlayerInfo()
        {
            string username;
            Console.Write("Enter your username: ");
            username = Console.ReadLine();

            // does file with username.txt exist?
            string charName = "";
            try
            {
                if (File.Exists(username + ".txt"))
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
                Console.WriteLine("Error checking file...", ex.Message);
            }
            return charName;
        }
        public static string NewPlayer(string username)
        {
            // make file with username as name
            StreamWriter outputfile;
            string charName;
            string playerRace;
            string playerClass;
            string playerWeapon;
            try
            {
                outputfile = File.CreateText(username + ".txt");
                Console.WriteLine($"Welcome, {username}!");
                Console.WriteLine("Let's create a character for you...");
                //for some reason have to close file and then open again to append text
                outputfile.Close();
                try
                {
                    outputfile = File.AppendText(username + ".txt");
                    Console.WriteLine("What would you like to name your character?");
                    charName = Console.ReadLine();
                    Console.WriteLine("Choose and enter your race: ");
                    playerRace = Console.ReadLine();
                    Console.WriteLine("Choose and enter your class: ");
                    playerClass = Console.ReadLine();
                    Console.WriteLine("Choose and enter your weapon: ");
                    playerWeapon = Console.ReadLine();
                    outputfile.WriteLine(charName, playerRace, playerClass, playerWeapon);
                    outputfile.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error making character...");
                throw;
            }
            return charName;
        }

        public static string ReturnPlayer(string username)
        {
            // get input from file with playername.txt
            StreamReader inputfile;
            string charName;

            inputfile = File.OpenText(username + ".txt");
            charName = inputfile.ReadLine();
            List<string> playerFile = MortuusClassLibrary.ReadFile.FileReader($"{username}.txt");

            foreach (var item in playerFile)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"Welcome back, {username}!");

            inputfile.Close();
            return charName;
        }
    }
}
