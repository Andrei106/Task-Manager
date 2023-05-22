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
        private string _connectionString = @"Server=localhost;Port=5432;User Id=postgres;Password=postgres;";
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

        /// <summary>
        /// Metoda de conectare la baza de date si creare de tabele
        /// </summary>
        /// <returns></returns>
        public string createConnection()
        {
            try
            {
                // Verificare daca baza de date deja exista
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
                            // Creare baza de date
                            cmd.CommandText = "CREATE DATABASE taskmanager;";
                            cmd.ExecuteNonQuery();
                            Console.WriteLine("Database created.");
                            _connectionString += "Database = taskmanager;";
                        }
                    }
                }

                // Crearea noului tabel projects
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

                // Crearea noului tabel users
                using (var conn = new NpgsqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT 1 FROM information_schema.tables WHERE table_schema = 'public' AND table_name = 'users' LIMIT 1;";
                        var result = cmd.ExecuteScalar();
                        if (result == null)
                        {
                            cmd.CommandText = "CREATE TABLE users (id SERIAL PRIMARY KEY, username VARCHAR(100) UNIQUE ,password VARCHAR(100))";
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                // Conectare la noua baza de date si tabel
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


        /// <summary>
        /// Metoda ce salveaza in baza de date un utlizator nou
        /// </summary>
        /// <param name = "username" > Username - ul utilizatorului</param>
        /// <param name="password">Parola utilizatorului</param>
        /// <returns></returns>
        public bool SaveUser(string username,string password)
        {

            try
            {
                //Se verifica daca deja exista un utilizator cu aceleasi date
                if (!CheckUserExits(username, password))
                {
                    //Daca nu exista adaugam in baza de date noul utilizator
                    using (var conn = new NpgsqlConnection(_connectionString))
                    {
                        conn.Open();
                        using (var cmd = new NpgsqlCommand())
                        {
                            //Inserare in baza de date
                            cmd.Connection = conn;
                            cmd.CommandText = "INSERT INTO users (username,password) VALUES (@username,@password) "; // on conflict (username) do nothing";
                            cmd.Parameters.AddWithValue("username", username);
                            cmd.Parameters.AddWithValue("password", password);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    return true;
                }
                else { return false; }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving user: " + ex.Message);
                return false;
            }
        }
        /// <summary>
        /// Metoda de verificare daca un utilizator exista deja 
        /// </summary>
        /// <param name="username">Username-ul utilizatorului</param>
        /// <param name="password">Parola utilizatorului</param>
        /// <returns></returns>
        public bool CheckUserExits(string username, string password)
        {
            try
            {
                using (var conn = new NpgsqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand())
                    {
                        //Cautare daca exista un utilizator cu aceleasi date
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT id FROM users WHERE username = @username AND password = @password";
                        cmd.Parameters.AddWithValue("username", username);
                        cmd.Parameters.AddWithValue("password", password);
                        var result = cmd.ExecuteScalar();
                        
                        //Daca e diferit de null,inseamna ce exista
                        if (result != null)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting user: " + ex.Message);
                return false;
            }
        }

        public bool SaveProject(Project.Project project)
        {
            return true;
        }
        public bool SaveTask(Elements.FeatureElement task)
        {
            return true;
        }
        public bool SaveTask(Elements.SpikeElement task)
        {
            return true;
        }
        public bool SaveTask(Elements.BugElement task)
        {
            return true;
        }
    }
}
