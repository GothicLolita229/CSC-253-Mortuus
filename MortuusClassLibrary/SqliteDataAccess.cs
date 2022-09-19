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

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
