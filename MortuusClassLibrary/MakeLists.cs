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
        public static List<string> mobs = ReadFile.FileReader("Mobs.csv"); 
        public static List<Mob> gameMobs = new List<Mob>(); 
       
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
