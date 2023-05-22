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
            this.createConnection();
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
                        }
                        _connectionString += "Database = taskmanager;";
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

                using (var conn = new NpgsqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT 1 FROM information_schema.tables WHERE table_schema = 'public' AND table_name = 'task' LIMIT 1;";
                        var result = cmd.ExecuteScalar();
                        if (result == null)
                        {
                            cmd.CommandText = "CREATE TABLE task (id SERIAL PRIMARY KEY, type VARCHAR(16), title VARCHAR(128), description VARCHAR(128),status VARCHAR(32), priority INTEGER, SEVERITY INTEGER, purpose VARCHAR(64))";
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
        public bool SaveUser(string username, string password)
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

                        //Daca e diferit de null,inseamna ca exista
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
            try
            {
                using (var conn = new NpgsqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand())
                    {
                        //Inserare in baza de date
                        cmd.Connection = conn;
                        cmd.CommandText = "INSERT INTO task (type,title,description,status,priority) VALUES ('FEATURE', @title, @description, 'TO_DO', @priority) RETURNING id";
                        cmd.Parameters.AddWithValue("title", task.GetTitle());
                        cmd.Parameters.AddWithValue("description", task.GetDescription());
                        cmd.Parameters.AddWithValue("priority", task.GetPriority());
                        object id = cmd.ExecuteScalar();
                        if (id == null)
                        {
                            return false;
                        }
                        task.SetId((int)id);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving feature task: " + ex.Message);
                return false;
            }
            return true;
        }
        public bool SaveTask(Elements.SpikeElement task)
        {
            try
            {
                using (var conn = new NpgsqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand())
                    {
                        //Inserare in baza de date
                        cmd.Connection = conn;
                        cmd.CommandText = "INSERT INTO task (type,title,description,status,purpose) VALUES ('SPIKE', @title, @description, 'TO_DO', @purpose) RETURNING id";
                        cmd.Parameters.AddWithValue("title", task.GetTitle());
                        cmd.Parameters.AddWithValue("description", task.GetDescription());
                        cmd.Parameters.AddWithValue("purpose", task.GetPurpose());
                        object id = cmd.ExecuteScalar();
                        if (id == null)
                        {
                            return false;
                        }
                        task.SetId((int)id);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving spike task: " + ex.Message);
                return false;
            }
            return true;
        }
        public bool SaveTask(Elements.BugElement task)
        {
            try
            {
                using (var conn = new NpgsqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand())
                    {
                        //Inserare in baza de date
                        cmd.Connection = conn;
                        cmd.CommandText = "INSERT INTO task (type,title,description,status,severity) VALUES ('BUG', @title, @description, 'TO_DO', @severity) RETURNING id";
                        cmd.Parameters.AddWithValue("title", task.GetTitle());
                        cmd.Parameters.AddWithValue("description", task.GetDescription());
                        cmd.Parameters.AddWithValue("severity", task.GetSeverity());
                        object id = cmd.ExecuteScalar();
                        if (id == null)
                        {
                            return false;
                        }
                        task.SetId((int)id);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving bug task: " + ex.Message);
                return false;
            }
            return true;
        }
        public List<Dictionary<string, object>> FetchTasks()
        {
            List<Dictionary<string, object>> result = new List<Dictionary<string, object>>();
            try
            {
                using (var conn = new NpgsqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand())
                    {
                        //Inserare in baza de date
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT * FROM task;";
                        NpgsqlDataReader reader = cmd.ExecuteReader();
                        while(reader.Read())
                        {
                            Dictionary<string, object> row = new Dictionary<string, object>();
                            row.Add("id", reader["id"]);
                            row.Add("type", reader["type"]);
                            row.Add("title", reader["title"]);
                            row.Add("description", reader["description"]);
                            row.Add("status", reader["status"]);
                            row.Add("priority", reader["priority"]);
                            row.Add("severity", reader["severity"]);
                            row.Add("purpose", reader["purpose"]);
                            result.Add(row);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching tasks: " + ex.Message);
            }
            return result;
        }

        public bool UpdateTaskStatus(Elements.TaskElement task)
        {
            try
            {
                using (var conn = new NpgsqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand())
                    {
                        //Inserare in baza de date
                        cmd.Connection = conn;
                        cmd.CommandText = "UPDATE task set status=@status where id=@id;";
                        cmd.Parameters.AddWithValue("status", task.GetStatus());
                        cmd.Parameters.AddWithValue("id", task.GetId());
                        object id = cmd.ExecuteScalar();
                        if (id == null)
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating task status: " + ex.Message);
                return false;
            }
            return true;
        }
    }
}
