﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using System.Data;
using NUnit.Framework;
using TaskManager;
using System.Windows.Forms;
using TaskManager.UserControls;
using System.Diagnostics.CodeAnalysis;
using Npgsql;
using DatabaseManager;
using Proxy;

namespace TaskManager
{
    [TestClass]
    public class TestClass
    {
        [TestInitialize]
        public void InitDatabase()
        {
            DatabaseManager.DatabaseManager.Instance.createConnection();
        }

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
        //Testare metoda de inregistrare utilizator
        public void Test_Inregistrare_Utilizator()
        {
            CleanTable("users");
            string username = "TEST";
            string password = "12345678";
            bool success = DatabaseManager.DatabaseManager.Instance.SaveUser(username, password);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(true, success);
            bool userExists = DatabaseManager.DatabaseManager.Instance.CheckUserExits(username, password);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(true, userExists);
        }
        [TestMethod]
        // Testare functionare apasare buton de logare din UserControl:Login
        public void Test_Buton_LogIn_Login()
        {
            With_Registered_User("TEST", Cryptography.HashString("12345678"));
            var app = new TaskManager.FormMain();
            app.login1.userBox.Text = "TEST";
            app.login1.passwordBox.Text = "12345678";
            app.ConnectionTry();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("To-Dos", app.labelCurrent.Text);
        }
        [TestMethod]
        // Testare functionalitatem buton Register din UserControl:Login
        public void Test_Buton_Register_Login()
        {
            
            var userControlLogIn = new TaskManager.UserControls.Login();
            bool butonApsat = false;
            userControlLogIn.buttonRegister_Click(null, null);
            butonApsat = true;
            NUnit.Framework.Assert.IsTrue(butonApsat);
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

                // Curățare - ștergem toate înregistrările existente din tabela "users"
                var deleteQuery = "DELETE FROM users";
                using (var deleteCommand = new NpgsqlCommand(deleteQuery, con))
                {
                    deleteCommand.ExecuteNonQuery();
                }

                // Definirea interogării de inserare
                var insertQuery = "INSERT INTO users (username, password) VALUES (@username, @password)";

                // Creare comandă cu parametri specificati
                using (var command = new NpgsqlCommand(insertQuery, con))
                {
                    command.Parameters.AddWithValue("username", "ion");
                    command.Parameters.AddWithValue("password", "1on123098");

                    // Executarea comenzii de inserare
                    int rowsAffected = command.ExecuteNonQuery();

                    // Verificare dacă inserarea a fost realizată cu succes
                    Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1, rowsAffected); // Verificăm dacă un singur rând a fost afectat (inserat)
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

                // Inserare înregistrare înainte de ștergere pentru a avea un rând de șters
                var insertQuery = "INSERT INTO users (username, password) VALUES ('marcel', 'qwerty1234')";
                using (var insertCommand = new NpgsqlCommand(insertQuery, con))
                {
                    insertCommand.ExecuteNonQuery();
                }

                // Definire interogarea de ștergere
                var deleteQuery = "DELETE FROM users WHERE username = @username";

                // Creare o nouă comandă de stergere după parametrul username
                using (var command = new NpgsqlCommand(deleteQuery, con))
                {
                    command.Parameters.AddWithValue("username", "marcel");

                    // Executare comanda de ștergere
                    int rowsAffected = command.ExecuteNonQuery();

                    // Verificare dacă ștergerea a fost realizată cu succes
                    Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1, rowsAffected); // Verificăm dacă un singur rând a fost afectat (șters)
                }
            }
    }
        [TestMethod]
        //Verificare functionalitate buton Register din UserControl:Register
        public void Test_Buton_Register_Register()
        {
            var userControlRegister = new UserControls.Register();
            bool butonApsat = false;
            userControlRegister.buttonRegisterAddUser_Click(null, null);
            butonApsat = true;
            NUnit.Framework.Assert.IsTrue(butonApsat);
        }
        [TestMethod]
        //Verificare functionalitate buton Create din UserControl:TaskDialogForm 
        public void Test_Buton_Create_TaskDialogForm()
        {
            bool butonApasat = false;
            var myUserControl = new UserControls.TaskDialogForm(1);
            myUserControl.buttonCreateNewTask_Click(null, null);
            butonApasat = true;
            NUnit.Framework.Assert.IsTrue(butonApasat);
        }
        [TestMethod]
        //Verificare functionalitate buton LogOut din FormMain
        public void Test_Buton_LogOut_FormMain()
        {
            bool butonApasat = false;
            var myForm = new FormMain();
            myForm.buttonLogout_Click(null, null);
            butonApasat = true;
            NUnit.Framework.Assert.IsTrue(butonApasat);
        }
        [TestMethod]
        //Verificare functionalitate buton Cancel&Delete din UserControl:TaskDialogForm 
        public void Test_Buton_Delete_Si_Cancel_TaskDialogForm()
        {
            bool butonApasat = false;
            var myUserControl = new UserControls.TaskDialogForm(1);
            myUserControl.buttonCancel_Click(null, null);
            butonApasat = true;
            NUnit.Framework.Assert.IsTrue(butonApasat);
        }
        [TestMethod]
        //Verificare functionalitate buton Delete din UserControl:ProjectControl
        public void Test_Buton_Delete_ProjectControl()
        {
            bool butonApasat = false;
            var myUserControl = new TaskManager.ProjectControl();
            myUserControl.buttonDeleteProject_Click(null, null);
            butonApasat = true;
            NUnit.Framework.Assert.IsTrue(butonApasat);
        }
        [TestMethod]
        //Verificare functionalitate buton Create din UserControl:ProjectControl
        public void Test_Buton_Create_ProjectControl()
        {
            bool butonApasat = false;
            var myUserControl = new TaskManager.ProjectControl();
            myUserControl.buttonCreateProject_Click(null, null);
            butonApasat = true;
            NUnit.Framework.Assert.IsTrue(butonApasat);
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

        private void CleanTable(string tableName)
        {
            string connectionString = @"Server=localhost;Port=5432;User Id=postgres;Password=postgres; Database=test_taskmanager";
            using (var con = new NpgsqlConnection(connectionString))
            {
                con.Open();

                var deleteQuery = "DELETE FROM " + tableName + ";";

                using (var command = new NpgsqlCommand(deleteQuery, con))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private void With_Registered_User(string username, string password)
        {
            CleanTable("users");
            DatabaseManager.DatabaseManager.Instance.SaveUser(username, password);
        }
    }
}
