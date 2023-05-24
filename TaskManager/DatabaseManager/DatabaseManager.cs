﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Member;
using Npgsql;
using Project;
namespace DatabaseManager
{
    public class DatabaseManager
    {
        private string _connectionString = @"Server=localhost;Port=5432;User Id=postgres;Password=postgres;";
        private static readonly DatabaseManager _dbInstance = new DatabaseManager();
        public static Member.Member loggedUser = null;
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
                            cmd.CommandText = "CREATE TABLE task (id SERIAL PRIMARY KEY, type VARCHAR(16), title VARCHAR(128), description VARCHAR(128),status VARCHAR(32), priority INTEGER, SEVERITY INTEGER, purpose VARCHAR(64), currentAsigneeId INTEGER, reporterId INTEGER NOT NULL)";
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
                            loggedUser = new Member.Member(username, (int)result); //FIXME: this should be moved somewhere else
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
                        cmd.CommandText = "INSERT INTO task (type,title,description,status,priority,reporterId) VALUES ('FEATURE', @title, @description, 'TO_DO', @priority, @reporterId) RETURNING id";
                        cmd.Parameters.AddWithValue("title", task.GetTitle());
                        cmd.Parameters.AddWithValue("description", task.GetDescription());
                        cmd.Parameters.AddWithValue("priority", task.GetPriority());
                        cmd.Parameters.AddWithValue("reporterId", loggedUser.Id);
                        object id = cmd.ExecuteScalar();
                        if (id == null)
                        {
                            return false;
                        }
                        task.SetId((int)id);
                        task.Reporter = loggedUser;
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
                        cmd.CommandText = "INSERT INTO task (type,title,description,status,purpose,reporterId) VALUES ('SPIKE', @title, @description, 'TO_DO', @purpose,@reporterId) RETURNING id";
                        cmd.Parameters.AddWithValue("title", task.GetTitle());
                        cmd.Parameters.AddWithValue("description", task.GetDescription());
                        cmd.Parameters.AddWithValue("purpose", task.GetPurpose());
                        cmd.Parameters.AddWithValue("reporterId", loggedUser.Id);
                        object id = cmd.ExecuteScalar();
                        if (id == null)
                        {
                            return false;
                        }
                        task.SetId((int)id);
                        task.Reporter = loggedUser;
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
                        cmd.CommandText = "INSERT INTO task (type,title,description,status,severity,reporterId) VALUES ('BUG', @title, @description, 'TO_DO', @severity,@reporterId) RETURNING id";
                        cmd.Parameters.AddWithValue("title", task.GetTitle());
                        cmd.Parameters.AddWithValue("description", task.GetDescription());
                        cmd.Parameters.AddWithValue("severity", task.GetSeverity());
                        cmd.Parameters.AddWithValue("reporterId", loggedUser.Id);
                        object id = cmd.ExecuteScalar();
                        if (id == null)
                        {
                            return false;
                        }
                        task.SetId((int)id);
                        task.Reporter = loggedUser;
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
        private Member.Member fetchUserById(int id)
        {
            try
            {
                using (var conn = new NpgsqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT * FROM users where id = @id;";
                        NpgsqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            return new Member.Member((string)reader["username"], (int)reader["id"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching user by id " + id + ": " + ex.Message);
            }
            return null;
        }
        public List<Member.Member> fetchUsers()
        {
            List<Member.Member> users = new List<Member.Member>();
            try
            {
                using (var conn = new NpgsqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT id, username FROM users;";
                        NpgsqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            users.Add(new Member.Member((string)reader["username"], (int)reader["id"])); 
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching users: " + ex.Message);
            }
            return users;
        }
        public List<Dictionary<string, object>> FetchTasks()
        {
            List<Dictionary<string, object>> result = new List<Dictionary<string, object>>();
            Dictionary<int, Member.Member> userCache = new Dictionary<int, Member.Member>();
            try
            {
                using (var conn = new NpgsqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand())
                    {
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
                            if (userCache.ContainsKey((int)reader["reporterId"]))
                            {
                                row.Add("reporter", userCache[(int)reader["reporterId"]]);
                            } else
                            {
                                Member.Member reporter = fetchUserById((int)reader["reporterId"]);
                                row.Add("reporter", reporter);
                                userCache.Add((int)reader["reporterId"], reporter);
                            }
                            if (reader["currentAsigneeId"] != DBNull.Value)
                            {
                                if (userCache.ContainsKey((int)reader["currentAsigneeId"]))
                                {
                                    row.Add("asignee", userCache[(int)reader["currentAsigneeId"]]);
                                }
                                else
                                {
                                    Member.Member asignee = fetchUserById((int)reader["currentAsigneeId"]);
                                    row.Add("asignee", asignee);
                                    userCache.Add((int)reader["currentAsigneeId"], asignee);
                                }
                            } else
                            {
                                row.Add("asignee", null);
                            }
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

        public bool UpdateTask(Elements.FeatureElement feature)
        {
            try
            {
                using (var conn = new NpgsqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "UPDATE task set title=@title, description=@description, priority=@priority, currentAsigneeId=@currentAsigneeId where id=@id;";
                        cmd.Parameters.AddWithValue("title", feature.GetTitle());
                        cmd.Parameters.AddWithValue("description", feature.GetDescription());
                        cmd.Parameters.AddWithValue("priority", feature.GetPriority());
                        if (feature.CurrentAsignee != null)
                        {
                            cmd.Parameters.AddWithValue("currentAsigneeId", feature.CurrentAsignee.Id);
                        } else
                        {
                            cmd.Parameters.AddWithValue("currentAsigneeId", DBNull.Value);
                        }
                        //cmd.Parameters.AddWithValue("currentAsigneeId", feature.CurrentAsignee != null ? feature.CurrentAsignee.Id : null); TODO: see if we can upgrade language level to 9.0
                        cmd.Parameters.AddWithValue("id", feature.GetId());
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
                Console.WriteLine("Error updating feature task: " + ex.Message);
                return false;
            }
            return true;
        }

        public bool UpdateTask(Elements.SpikeElement feature)
        {
            try
            {
                using (var conn = new NpgsqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "UPDATE task set title=@title, description=@description, purpose=@purpose, currentAsigneeId=@currentAsigneeId where id=@id;";
                        cmd.Parameters.AddWithValue("title", feature.GetTitle());
                        cmd.Parameters.AddWithValue("description", feature.GetDescription());
                        cmd.Parameters.AddWithValue("priority", feature.GetPurpose());
                        if (feature.CurrentAsignee != null)
                        {
                            cmd.Parameters.AddWithValue("currentAsigneeId", feature.CurrentAsignee.Id);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("currentAsigneeId", DBNull.Value);
                        }
                        //cmd.Parameters.AddWithValue("currentAsigneeId", feature.CurrentAsignee != null ? feature.CurrentAsignee.Id : null); TODO: see if we can upgrade language level to 9.0
                        cmd.Parameters.AddWithValue("id", feature.GetId());
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
                Console.WriteLine("Error updating spike task: " + ex.Message);
                return false;
            }
            return true;
        }

        public bool UpdateTask(Elements.BugElement feature)
        {
            try
            {
                using (var conn = new NpgsqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "UPDATE task set title=@title, description=@description, severity=@severity, currentAsigneeId=@currentAsigneeId where id=@id;";
                        cmd.Parameters.AddWithValue("title", feature.GetTitle());
                        cmd.Parameters.AddWithValue("description", feature.GetDescription());
                        cmd.Parameters.AddWithValue("priority", feature.GetSeverity());
                        if (feature.CurrentAsignee != null)
                        {
                            cmd.Parameters.AddWithValue("currentAsigneeId", feature.CurrentAsignee.Id);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("currentAsigneeId", DBNull.Value);
                        }
                        //cmd.Parameters.AddWithValue("currentAsigneeId", feature.CurrentAsignee != null ? feature.CurrentAsignee.Id : null); TODO: see if we can upgrade language level to 9.0
                        cmd.Parameters.AddWithValue("id", feature.GetId());
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
                Console.WriteLine("Error updating bug task: " + ex.Message);
                return false;
            }
            return true;
        }

        public bool DeleteTask(int taskId)
        {
            try
            {
                using (var conn = new NpgsqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "DELETE FROM task WHERE id = @id";
                        cmd.Parameters.AddWithValue("id", taskId);
                        cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting task: " + ex.Message);
                return false;
            }
            return true;
        }
    }
}

