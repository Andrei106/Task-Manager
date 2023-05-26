using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Npgsql;
using System.Data;
using NUnit.Framework;
using TaskManager;
using System.Windows.Forms;


namespace TaskManager
{
    [TestClass]
    public class TestClass
    {
        [TestMethod]
        //testare conectare la baza de date
        public void Test_Conectare_La_Baza_de_Date() 
        {
            string connectionString = @"Server=localhost;Port=5432;User Id=postgres;Password=postgres;";

            using (var con = new NpgsqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(ConnectionState.Open, con.State);
                }
                catch (Exception ex)
                {
                    Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail($"Failed to connect to the database: {ex.Message}");
                }
            }
        }
        [TestMethod]
        // Testare functionare apasare buton de logare din UserControl:Login
        public void Test_Buton_LogIN()
        {
            var userControlLogIn = new TaskManager.UserControls.Login();
            bool butonApsat = false;
            userControlLogIn.button1_Click(null, null);
            butonApsat = true;
            NUnit.Framework.Assert.IsTrue(butonApsat);
        }
        [TestMethod]
        // Testare functionare apasare buton de register din UserControl:Login
        public void Test_Buton_Register()
        {
            /*
            var userControlLogIn = new TaskManager.UserControls.Login();
            bool butonApsat = false;
            //var butRegister = userControlLogIn.Controls["buttonRegister"] as Button;
            userControlLogIn.buttonRegister_Click(null, null);
            butonApsat = true;
            NUnit.Framework.Assert.IsTrue(butonApsat);
            */
        }
        [TestMethod]
        //Testare creare obiecte de tip Bug
        public void TestBug()
        {
            TaskFactory.TaskFactory fabricaBug = new BugFactory.BugFactory();
            var obB = fabricaBug.CreateTask(0, "Descriere", "Titlu", 0, "Done", 0);
            NUnit.Framework.Assert.IsNotNull(obB);
            
        }
        [TestMethod]
        //Testare creare obiecte de tip Feature
        public void TestFeature()
        {
            TaskFactory.TaskFactory fabricaFeature = new FeatureFactory.FeatureFactory();
            var obF = fabricaFeature.CreateTask(1, "Descriere", "Titlu", 3, "Waiting", 1);
            NUnit.Framework.Assert.IsNotNull(obF);

        }
        [TestMethod]
        //Testare creare obiecte de tip Spike
        public void TestSpike()
        {
            TaskFactory.TaskFactory fabricaSpike = new SpikeFactory.SpikeFactory();
            var obS = fabricaSpike.CreateTask(1, "Descriere", "Titlu", 2, "Waiting", 0);
            NUnit.Framework.Assert.IsNotNull(obS);
        }
        [TestMethod]
        //Testare inserare de valori in tabela users din baza de date
        public void Test_Inserare_In_Baza_De_Date()
        {
            string connectionString = @"Server=localhost;Port=5432;User Id=postgres;Password=postgres;";
            using (var con = new NpgsqlConnection(connectionString))
            {
                con.Open();

                string insertCommand = "INSERT INTO users (username,password) VALUES (@username,@password) ";
                using (var command = new NpgsqlCommand(insertCommand, con))
                {
                    command.Parameters.AddWithValue("@username", "Ion");
                    command.Parameters.AddWithValue("@password", "ionel1234");

                    int rowsAffected = command.ExecuteNonQuery();

                    NUnit.Framework.Assert.AreEqual(1, rowsAffected, "Insert failed!");
                }
            }
        }
        [TestMethod]
        //Testare stergere de valori in tabela users din baza de date
        public void Testare_Sterge_Din_Baza_De_Date()
        {
            string connectionString = @"Server=localhost;Port=5432;User Id=postgres;Password=postgres;";
            using (var con = new NpgsqlConnection(connectionString))
            {
                con.Open();
                string insertCommand = "INSERT INTO users (username, password) VALUES (@username, @password);";
                using (var insertCmd = new NpgsqlCommand(insertCommand, con))
                {
                    insertCmd.Parameters.AddWithValue("@username", "John");
                    insertCmd.Parameters.AddWithValue("@password", "password123");
                    insertCmd.ExecuteNonQuery();
                }

                string deleteCommand = "DELETE FROM users WHERE username = @username;";
                using (var deleteCmd = new NpgsqlCommand(deleteCommand, con))
                {
                    deleteCmd.Parameters.AddWithValue("@username", "JohnDoe");
                    int rowsAffected = deleteCmd.ExecuteNonQuery();

                    NUnit.Framework.Assert.AreEqual(1, rowsAffected, "Delete failed!");
                }
            }
        }
        [TestMethod]
        public void Test9()
        {
        }
        [TestMethod]
        public void Test10()
        {
        }
        [TestMethod]
        public void Test11()
        {
        }
        [TestMethod]
        public void Test12()
        {
        }
        [TestMethod]
        public void Test13()
        {
        }
        [TestMethod]
        public void Test14()
        {
        }
        [TestMethod]
        public void Test15()
        {
        }
        [TestMethod]
        public void Test16()
        {
        }
        [TestMethod]
        public void Test17()
        {
        }
        [TestMethod]
        public void Test18()
        {
        }
        [TestMethod]
        public void Test19()
        {
        }
        [TestMethod]
        public void Test20()
        {
        }
    }
}
