using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortuusClassLibrary
{
    public class SqliteDataAccess
    {
        public static List<Room> LoadRooms()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Room>("SELECT * FROM RoomsTable", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<Weapon> LoadWeapons()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Weapon>("SELECT Name FROM WeaponsTable", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<Item> LoadItems()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Item>("SELECT Name FROM ItemsTable", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<Potion> LoadPotions()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Potion>("SELECT Name FROM PotionsTable", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<Treasure> LoadTreasure()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Treasure>("SELECT Name FROM TreasuresTable", new DynamicParameters());
                return output.ToList();
            }
        }


        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
