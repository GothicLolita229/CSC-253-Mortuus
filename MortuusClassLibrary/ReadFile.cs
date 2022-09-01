using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MortuusClassLibrary
{
    public class ReadFile
    {
        public static List<string> FileReader(string filename)
        {
            List<string> returnList = new List<string>();
            StreamReader inputfile;
            try
            {
                inputfile = File.OpenText(filename);

                while (inputfile.EndOfStream == false)
                {
                    returnList.Add(inputfile.ReadLine());
                }
                inputfile.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
            return returnList;
        }
    }
}
