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
        public static List<Player> LoadPlayers()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Player>("SELECT * FROM PlayerTable", new DynamicParameters());
                return output.ToList();
            }
        }
        public static void SavePlayer(Player player)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into PlayerTable (ID, Name, Race, LcClass, Description, HP, AC, Password, Location) values (@ID, @Name, @Race, @LcClass, @Description, @HP, @AC, @Password, @Location)", player);
            }
        }

        public static List<Mob> LoadMobs()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Mob>("SELECT * FROM MobsTable", new DynamicParameters());
                return output.ToList();
            }
        }
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

        public static List<Treasure> LoadTreasures()
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
