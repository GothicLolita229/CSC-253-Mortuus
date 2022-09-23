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
