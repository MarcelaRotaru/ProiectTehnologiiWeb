using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectTW.Models
{
    public class UsersStoreContext
    {
        public string ConnectionString { get; set; }

        public UsersStoreContext(string connectionString)
        {
            this.ConnectionString = connectionString;
            
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<User> GetAllUsers()
        {
            List<User> list = new List<User>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from users where id < 10", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new User()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Username = reader["username"].ToString(),
                            Email = reader["email"].ToString(),
                            Password = reader["password"].ToString(),
                            TurnDate = (DateTime)reader["trn_date"]
                        });
                    }
                }
            }
            return list;
        }
        public List<Locations> GetAllLocations()
        {
            List<Locations> list = new List<Locations>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("spGetMap", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Locations()
                        {
                            
                            CityName = reader["CityName"].ToString(),
                            Latitude = Convert.ToDouble(reader["Latitude"]),
                            Longitude = Convert.ToDouble(reader["Longitude"]),
                            Description = reader["Description"].ToString(),
                           
                        });
                    }
                }
            }
            return list;
        }

        public List<Locations> GetAllUsersLocations(int userId)
        {
            List<Locations> listAllLocations = new List<Locations>();
            List<Locations> listUsersLocations = new List<Locations>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT googlemap.ID, googlemap.cityname, googlemap.latitude,googlemap.longitude, googlemap.description, usersmaps.userID FROM googlemap INNER JOIN usersmaps ON googlemap.ID = usersmaps.mapId;", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listAllLocations.Add(new Locations()
                        {

                            CityName = reader["CityName"].ToString(),
                            Latitude = Convert.ToDouble(reader["Latitude"]),
                            Longitude = Convert.ToDouble(reader["Longitude"]),
                            Description = reader["Description"].ToString(),
                            UserId= Convert.ToInt32(reader["UserId"]),
                        });
                    }
                }
            }
            foreach (Locations location in listAllLocations)
                if (location.UserId == userId)
                    listUsersLocations.Add(location);
            return listUsersLocations;
        }
    }
}

