using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Project;
namespace DatabaseManager
{
    public class DatabaseManager
    {
        private string _connectionString = @"Server=localhost;Port=5432;Database=taskmanager;User Id=postgres;Password=postgres;";
        private static readonly DatabaseManager _dbInstance = new DatabaseManager();
        static DatabaseManager()
        {

        }
        private DatabaseManager()
        {
        }
        public static DatabaseManager Instance
        {
            get
            {
                return _dbInstance;
            }
        }


        public string createConnection()
        {
            try
            {
                // Check if the database already exists
                using (var conn = new NpgsqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT 1 FROM pg_database WHERE datname = 'taskmanager';";

                        var result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            // Database already exists
                            Console.WriteLine("Database already exists.");
                        }
                        else
                        {
                            // Create the database
                            cmd.CommandText = "CREATE DATABASE taskmanager;";
                            cmd.ExecuteNonQuery();
                            Console.WriteLine("Database created.");
                        }
                    }
                }

                // Create a new table
                using (var conn = new NpgsqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT 1 FROM information_schema.tables WHERE table_schema = 'public' AND table_name = 'projects' LIMIT 1;";
                        var result = cmd.ExecuteScalar();
                        if (result == null)
                        {
                            cmd.CommandText = "CREATE TABLE projects (id SERIAL PRIMARY KEY, data VARCHAR(255))";
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                // Connect to the new database and table
                using (var conn = new NpgsqlConnection(_connectionString))
                {
                    conn.Open();
                    return "Connection successful";
                }
            }
            catch (Exception ex)
            {
                return ex.Message + " Connection failed";
            }
        }


        public bool SaveString(string project)
        {

            try
            {
                using (var conn = new NpgsqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "INSERT INTO projects (data) VALUES (@data)";
                        cmd.Parameters.AddWithValue("data", project);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving project: " + ex.Message);
                return false;
            }
        }

        public string GetString(int id)
        {
            try
            {
                using (var conn = new NpgsqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT data FROM projects WHERE id = @id";
                        cmd.Parameters.AddWithValue("id", id);
                        var result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            return result.ToString();
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting string: " + ex.Message);
                return null;
            }
        }


        public bool SaveProject(Project.Project project)
        {
            return true;
        }
        public bool SaveTask(Feature.Feature task)
        {
            return true;
        }
        public bool SaveTask(Spike.Spike task)
        {
            return true;
        }
        public bool SaveTask(Bug.Bug task)
        {
            return true;
        }
    }
}
