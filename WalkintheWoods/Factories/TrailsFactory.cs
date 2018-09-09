using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using WalkintheWoods.Models;
using Dapper;
using System.Linq;

namespace WalkintheWoods.Factories	//you can leave as is, or change to your own namespace
{
    public class Trailsfactory
    {
        static string server = "localhost";
        static string db = "hikingtrails"; //Change to your schema name
        static string port = "3306"; //Potentially 8889
        static string user = "root";
        static string pass = "root";
        internal static IDbConnection Connection {
            get {
                return new MySqlConnection($"Server={server};Port={port};Database={db};UserID={user};Password={pass};SslMode=None");
            }
        }
        // add new trail
        public void Addnewtrail(Trails trail){
            using (IDbConnection dbConnection = Connection){
                string query = "INSERT INTO trails (name, description, miles, elevation, longitude, latitude, created_at, update_at) VALUES (@Name, @Discription, @Miles, @Elevation, @Longitude, @Latitude, NOW(), NOW())";
                dbConnection.Open();
                dbConnection.Execute(query, trail);
                

            }
        }
        public List<Trails> GetTrails(){
            using (IDbConnection dbConnection = Connection){
                using(IDbCommand command = dbConnection.CreateCommand()){
                    string query = "SELECT * FROM trails";
                    dbConnection.Open();
                    return dbConnection.Query<Trails>(query).ToList();

                }
            }
        }
    }
}