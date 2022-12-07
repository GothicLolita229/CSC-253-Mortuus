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
        /*public static List<Player> LoadPlayers()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Player>("SELECT * FROM PlayerTable", new DynamicParameters());


                return output.ToList();
            }
        }*/
        
        public static Player LoadPlayer(string Name)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                try
                {
                    var parameters = new { Name = Name };
                    var output = cnn.QuerySingle<Player>("SELECT * FROM PlayerTable WHERE Name = @Name", parameters);
                    return output;
                }
                catch 
                {
                    return null;
                }
            }
        }

        public static void SavePlayer(Player player)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into PlayerTable (Name, Race, LcClass, Description, Weapon, HP, AC, Password, Location) values (@Name, @Race, @LcClass, @Description, @Weapon, @HP, @AC, @Password, @Location)", player);
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
        public static Mob LoadMob(object ID) //Changed to object to make a list of generic objects
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var parameters = new { ID = ID };

                var output = cnn.QuerySingle<Mob>("SELECT * FROM MobsTable WHERE ID = @ID", parameters);

                return output;
            }
        }
        /*public static Room LoadRoom(int ID)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var parameters = new { ID = ID };

                var output = cnn.QuerySingle<Room>("SELECT * FROM RoomsTable WHERE ID = @ID" , parameters);

                return output;
            }
        }*/

        public static List<Room> LoadRoom() // Version 2 pulls all from database and makes a list of objects
        {
            using (var con = new SQLiteConnection(LoadConnectionString()))
            {
                con.Open();
                var cmd = new SQLiteCommand("SELECT * FROM Rooms", con);
                SQLiteDataReader rdr = cmd.ExecuteReader();

                List<Room> rooms = new List<Room>();

                while (rdr.Read())
                {
                    Room room = new Room(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetInt32(3), rdr.GetInt32(4), rdr.GetInt32(5), rdr.GetInt32(6));
                    rooms.Add(room);
                }
                return rooms;
            }
        }

        public static List<Room> LoadRoomsDisplay()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Room>("SELECT Name FROM RoomsTable", new DynamicParameters());
                return output.ToList();
            }
        }
        /* public static Room LoadRoomInv(int RoomID) //VERSION 1
         {
             using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
             {
                 var parameters = new { RoomID = RoomID };

                 var output = cnn.QuerySingle<Room>("SELECT * FROM RoomInventory WHERE RoomID = @RoomID", parameters);

                 return output;
             }
         }*/
        public static List<object> LoadRoomInv(int RoomID) // VERSION 2 //Changed to object to make a list of generic objects
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var parameters = new { RoomID = RoomID };

                var output = cnn.QuerySingle<List<object>>("SELECT * FROM RoomInventory WHERE RoomID = @RoomID", parameters);

                return output;
            }
        }
        public static List<Weapon> LoadWeaponsList()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Weapon>("SELECT Name FROM WeaponsTable", new DynamicParameters());
                return output.ToList();
            }
        }
        public static Weapon LoadWeapon(object ID) //Changed to object to make a list of generic objects
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var parameters = new { ID = ID };

                var output = cnn.QuerySingle<Weapon>("SELECT * FROM WeaponsTable WHERE ID = @ID", parameters);

                return output;
            }
        }
        public static List<Item> LoadItemsList()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Item>("SELECT Name FROM QuestItemsTable", new DynamicParameters());
                return output.ToList();
            }
        }
        public static Item LoadItem(object ID) //Changed to object to make a list of generic objects 
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var parameters = new { ID = ID };

                var output = cnn.QuerySingle<Item>("SELECT * FROM QuestItemsTable WHERE ID = @ID", parameters);

                return output;
            }
        }
        public static List<Potion> LoadPotionsList()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Potion>("SELECT Name FROM PotionsTable", new DynamicParameters());
                return output.ToList();
            }
        }
        public static Potion LoadPotion(object ID) //Changed to object to make a list of generic objects
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var parameters = new { ID = ID };

                var output = cnn.QuerySingle<Potion>("SELECT * FROM PotionsTable WHERE ID = @ID", parameters);

                return output;
            }
        }
        public static List<Treasure> LoadTreasuresList()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Treasure>("SELECT Name FROM TreasuresTable", new DynamicParameters());
                return output.ToList();
            }
        }
        public static Treasure LoadTreasure(object ID) //Changed to object to make a list of generic objects
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var parameters = new { ID = ID };

                var output = cnn.QuerySingle<Treasure>("SELECT * FROM TreasuresTable WHERE ID = @ID", parameters);

                return output;
            }
        }
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
/**
* CSC 253
* Lourdes Linares and Ciara McLaughlin
* This program is a maze/rpg text adventure game. 
*/
