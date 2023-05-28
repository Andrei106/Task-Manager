/********************************************************************************************
 *                                                                                          *
 *  File:        DatabaseManager.cs                                                                     *
 *  Copyright:   (c) 2023,Poclid Ionut-Andrei, Lungu Bogdan-Andrei                            *
 *  E-mail:      ionut-andrei.poclid@student.tuiasi.ro,bogdan-andrei.lungu@tuiasi.ro          *                   *
 *  Description: Student la Facultatea de Automatica si Calculatoare Iasi                   *
 *                                                                                          *
 *  This program is free software; you can redistribute it and/or modify                    *
 *  it under the terms of the GNU General Public License as published by                    *
 *  the Free Software Foundation. This program is distributed in the                        *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even                     *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR                     *
 *  PURPOSE. See the GNU General Public License for more details.                           *
 *                                                                                          *
 *******************************************************************************************/



using Microsoft.VisualStudio.TestTools.UnitTesting;
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
using System.Collections.Generic;
using Member;

namespace TaskManager
{
    /// <summary>
    /// Clasa cu unit tests
    /// </summary>
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
            // setup
            string connectionString = @"Server=localhost;Port=5432;User Id=postgres;Password=postgres;";

            using (var con = new NpgsqlConnection(connectionString))
            {
                try
                {
                    // execute and verify
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
            // setup
            CleanTable("users");
            string username = "TEST";
            string password = "12345678";

            // execute
            bool success = DatabaseManager.DatabaseManager.Instance.SaveUser(username, password);

            // verify
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(success);
            bool userExists = DatabaseManager.DatabaseManager.Instance.CheckUserExits(username, password);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(userExists);
        }
        [TestMethod]
        //Testare metoda de salvare feature
        public void Test_Salvare_Feature()
        {
            // setup
            CleanTable("task");
            With_Registered_User("TEST_USER", "1");
            string descriere = "Descriere";
            string titlu = "Titlu";
            string status = "DONE";
            int priority = 5;
            TaskFactory.TaskFactory fabricaFeature = new FeatureFactory.FeatureFactory();
            Elements.FeatureElement obF = (Elements.FeatureElement)fabricaFeature.CreateTask(1, descriere, titlu, priority, status, 1);

            // execute
            bool success = DatabaseManager.DatabaseManager.Instance.SaveTask(obF);

            // verify
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(success);
            List<Dictionary<string, object>> tasks = DatabaseManager.DatabaseManager.Instance.FetchTasks();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1, tasks.Count);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(descriere, tasks[0]["description"]);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(titlu, tasks[0]["title"]);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("FEATURE", tasks[0]["type"]);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("TO_DO", tasks[0]["status"]);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(priority, tasks[0]["priority"]);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("TEST_USER", ((Member.Member)tasks[0]["reporter"]).Nickname);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(tasks[0]["asignee"]);
        }
        [TestMethod]
        //Testare metoda de salvare task
        public void Test_Salvare_Task()
        {
            // setup
            CleanTable("task");
            With_Registered_User("TEST_USER", "1");
            string descriere = "Descriere";
            string titlu = "Titlu";
            string status = "DONE";
            string purpose = "needed for next release";
            TaskFactory.TaskFactory fabricaSpike = new SpikeFactory.SpikeFactory();
            Elements.SpikeElement obS = (Elements.SpikeElement)fabricaSpike.CreateTask(1, descriere, titlu, 2, status, 0, purpose);

            // execute
            bool success = DatabaseManager.DatabaseManager.Instance.SaveTask(obS);

            // verify
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(success);
            List<Dictionary<string, object>> tasks = DatabaseManager.DatabaseManager.Instance.FetchTasks();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1, tasks.Count);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(descriere, tasks[0]["description"]);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(titlu, tasks[0]["title"]);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("SPIKE", tasks[0]["type"]);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("TO_DO", tasks[0]["status"]);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(purpose, tasks[0]["purpose"]);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("TEST_USER", ((Member.Member)tasks[0]["reporter"]).Nickname);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(tasks[0]["asignee"]);
        }
        [TestMethod]
        //Testare metoda de salvare bug
        public void Test_Salvare_Bug()
        {
            // setup
            CleanTable("task");
            With_Registered_User("TEST_USER", "1");
            string descriere = "Descriere";
            string titlu = "Titlu";
            string status = "TO_DO";
            int severity = 1;
            TaskFactory.TaskFactory fabricaBug = new BugFactory.BugFactory();
            Elements.BugElement obB = (Elements.BugElement)fabricaBug.CreateTask(0, descriere, titlu, severity, status, 0);

            // execute
            bool success = DatabaseManager.DatabaseManager.Instance.SaveTask(obB);

            // verify
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(success);
            List<Dictionary<string, object>> tasks = DatabaseManager.DatabaseManager.Instance.FetchTasks();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1, tasks.Count);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(descriere, tasks[0]["description"]);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(titlu, tasks[0]["title"]);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("BUG", tasks[0]["type"]);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("TO_DO", tasks[0]["status"]);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(severity, tasks[0]["severity"]);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("TEST_USER", ((Member.Member)tasks[0]["reporter"]).Nickname);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(tasks[0]["asignee"]);
        }
        [TestMethod]
        //Testare metoda de editare feature
        public void Test_Editare_Feature()
        {
            // setup
            CleanTable("task");
            With_Registered_User("TEST_USER", "1");
            string descriere = "Descriere";
            string titlu = "Titlu";
            string status = "DONE";
            string edit = "NEW ";
            int priority = 5;
            TaskFactory.TaskFactory fabricaFeature = new FeatureFactory.FeatureFactory();
            Elements.FeatureElement obF = (Elements.FeatureElement)fabricaFeature.CreateTask(1, descriere, titlu, priority, status, 1);
            bool success = DatabaseManager.DatabaseManager.Instance.SaveTask(obF);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(success);
            obF.Description = edit + descriere;
            obF.Title = edit + titlu;
            obF.SetPriority(priority + 1);
            obF.CurrentAsignee = new Member.Member("TEST_USER", 1);

            // execute
            bool successUpdate = DatabaseManager.DatabaseManager.Instance.UpdateTask(obF);

            // verify
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(successUpdate);
            List<Dictionary<string, object>> tasks = DatabaseManager.DatabaseManager.Instance.FetchTasks();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1, tasks.Count);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(edit + descriere, tasks[0]["description"]);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(edit + titlu, tasks[0]["title"]);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("FEATURE", tasks[0]["type"]);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("TO_DO", tasks[0]["status"]);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(priority + 1, tasks[0]["priority"]);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("TEST_USER", ((Member.Member)tasks[0]["reporter"]).Nickname);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(tasks[0]["asignee"]);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("TEST_USER", ((Member.Member)tasks[0]["asignee"]).Nickname);
        }
        [TestMethod]
        //Testare metoda de editare task
        public void Test_Editare_Task()
        {
            // setup
            CleanTable("task");
            With_Registered_User("TEST_USER", "1");
            string descriere = "Descriere";
            string titlu = "Titlu";
            string status = "DONE";
            string edit = "NEW ";
            string purpose = "needed for next release";
            TaskFactory.TaskFactory fabricaSpike = new SpikeFactory.SpikeFactory();
            Elements.SpikeElement obS = (Elements.SpikeElement)fabricaSpike.CreateTask(1, descriere, titlu, 2, status, 0, purpose);
            bool success = DatabaseManager.DatabaseManager.Instance.SaveTask(obS);    
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(success);
            obS.Description = edit + descriere;
            obS.Title = edit + titlu;
            obS.SetPurpose(edit + purpose);
            obS.CurrentAsignee = new Member.Member("TEST_USER", 1);

            // execute
            bool successUpdate = DatabaseManager.DatabaseManager.Instance.UpdateTask(obS);

            // verify
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(successUpdate);
            List<Dictionary<string, object>> tasks = DatabaseManager.DatabaseManager.Instance.FetchTasks();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1, tasks.Count);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(edit + descriere, tasks[0]["description"]);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(edit + titlu, tasks[0]["title"]);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("SPIKE", tasks[0]["type"]);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("TO_DO", tasks[0]["status"]);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(edit + purpose, tasks[0]["purpose"]);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("TEST_USER", ((Member.Member)tasks[0]["reporter"]).Nickname);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(tasks[0]["asignee"]);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("TEST_USER", ((Member.Member)tasks[0]["asignee"]).Nickname);
        }
        [TestMethod]
        //Testare metoda de editare bug
        public void Test_Editare_Bug()
        {
            // setup
            CleanTable("task");
            With_Registered_User("TEST_USER", "1");
            string descriere = "Descriere";
            string titlu = "Titlu";
            string status = "TO_DO";
            string edit = "NEW ";
            int severity = 1;
            TaskFactory.TaskFactory fabricaBug = new BugFactory.BugFactory();
            Elements.BugElement obB = (Elements.BugElement)fabricaBug.CreateTask(0, descriere, titlu, severity, status, 0);
            bool success = DatabaseManager.DatabaseManager.Instance.SaveTask(obB);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(success);
            obB.Description = edit + descriere;
            obB.Title = edit + titlu;
            obB.SetSeverity(severity + 1);
            obB.CurrentAsignee = new Member.Member("TEST_USER", 1);

            // execute
            bool successUpdate = DatabaseManager.DatabaseManager.Instance.UpdateTask(obB);

            // verify
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(successUpdate);
            List<Dictionary<string, object>> tasks = DatabaseManager.DatabaseManager.Instance.FetchTasks();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1, tasks.Count);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(edit + descriere, tasks[0]["description"]);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(edit + titlu, tasks[0]["title"]);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("BUG", tasks[0]["type"]);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("TO_DO", tasks[0]["status"]);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(severity + 1, tasks[0]["severity"]);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("TEST_USER", ((Member.Member)tasks[0]["reporter"]).Nickname);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(tasks[0]["asignee"]);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("TEST_USER", ((Member.Member)tasks[0]["asignee"]).Nickname);
        }
        [TestMethod]
        //Testare metoda de editare feature unassign user
        public void Test_Editare_Feature_Unassign_User()
        {
            // setup
            CleanTable("task");
            With_Registered_User("TEST_USER", "1");
            string descriere = "Descriere";
            string titlu = "Titlu";
            string status = "DONE";
            int priority = 5;
            TaskFactory.TaskFactory fabricaFeature = new FeatureFactory.FeatureFactory();
            Elements.FeatureElement obF = (Elements.FeatureElement)fabricaFeature.CreateTask(1, descriere, titlu, priority, status, 1);
            obF.CurrentAsignee = new Member.Member("TEST_USER", 1);
            bool success = DatabaseManager.DatabaseManager.Instance.SaveTask(obF);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(success);
            obF.CurrentAsignee = null;

            // execute
            bool successUpdate = DatabaseManager.DatabaseManager.Instance.UpdateTask(obF);

            // verify
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(successUpdate);
            List<Dictionary<string, object>> tasks = DatabaseManager.DatabaseManager.Instance.FetchTasks();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1, tasks.Count);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("TEST_USER", ((Member.Member)tasks[0]["reporter"]).Nickname);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(tasks[0]["asignee"]);
        }
        [TestMethod]
        //Testare metoda de editare task unassign user
        public void Test_Editare_Task_Unassign_User()
        {
            // setup
            CleanTable("task");
            With_Registered_User("TEST_USER", "1");
            string descriere = "Descriere";
            string titlu = "Titlu";
            string status = "DONE";
            string purpose = "needed for next release";
            TaskFactory.TaskFactory fabricaSpike = new SpikeFactory.SpikeFactory();
            Elements.SpikeElement obS = (Elements.SpikeElement)fabricaSpike.CreateTask(1, descriere, titlu, 2, status, 0, purpose);
            obS.CurrentAsignee = new Member.Member("TEST_USER", 1);
            bool success = DatabaseManager.DatabaseManager.Instance.SaveTask(obS);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(success);
            obS.CurrentAsignee = null;

            // execute
            bool successUpdate = DatabaseManager.DatabaseManager.Instance.UpdateTask(obS);

            // verify
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(successUpdate);
            List<Dictionary<string, object>> tasks = DatabaseManager.DatabaseManager.Instance.FetchTasks();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1, tasks.Count);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("TEST_USER", ((Member.Member)tasks[0]["reporter"]).Nickname);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(tasks[0]["asignee"]);
        }
        [TestMethod]
        //Testare metoda de editare bug unassign user
        public void Test_Editare_Bug_Unassign_User()
        {
            // setup
            CleanTable("task");
            With_Registered_User("TEST_USER", "1");
            string descriere = "Descriere";
            string titlu = "Titlu";
            string status = "TO_DO";
            int severity = 1;
            TaskFactory.TaskFactory fabricaBug = new BugFactory.BugFactory();
            Elements.BugElement obB = (Elements.BugElement)fabricaBug.CreateTask(0, descriere, titlu, severity, status, 0);
            obB.CurrentAsignee = new Member.Member("TEST_USER", 1);
            bool success = DatabaseManager.DatabaseManager.Instance.SaveTask(obB);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(success);
            obB.CurrentAsignee = null;

            // execute
            bool successUpdate = DatabaseManager.DatabaseManager.Instance.UpdateTask(obB);

            // verify
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(successUpdate);
            List<Dictionary<string, object>> tasks = DatabaseManager.DatabaseManager.Instance.FetchTasks();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1, tasks.Count);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("TEST_USER", ((Member.Member)tasks[0]["reporter"]).Nickname);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(tasks[0]["asignee"]);
        }
        [TestMethod]
        //Testare metoda de editare status feature
        public void Test_Editare_Status_Feature()
        {
            // setup
            CleanTable("task");
            With_Registered_User("TEST_USER", "1");
            string descriere = "Descriere";
            string titlu = "Titlu";
            string status = "DONE";
            int priority = 5;
            TaskFactory.TaskFactory fabricaFeature = new FeatureFactory.FeatureFactory();
            Elements.FeatureElement obF = (Elements.FeatureElement)fabricaFeature.CreateTask(1, descriere, titlu, priority, status, 1);
            bool success = DatabaseManager.DatabaseManager.Instance.SaveTask(obF);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(success);
            obF.SetStatus(status);

            // execute
            bool successUpdate = DatabaseManager.DatabaseManager.Instance.UpdateTaskStatus(obF);

            // verify
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(successUpdate);
            List<Dictionary<string, object>> tasks = DatabaseManager.DatabaseManager.Instance.FetchTasks();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1, tasks.Count);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(status, tasks[0]["status"]);

        }
        [TestMethod]
        //Testare metoda de editare status task
        public void Test_Editare_Status_Task()
        {
            // setup
            CleanTable("task");
            With_Registered_User("TEST_USER", "1");
            string descriere = "Descriere";
            string titlu = "Titlu";
            string status = "DONE";
            string purpose = "needed for next release";
            TaskFactory.TaskFactory fabricaSpike = new SpikeFactory.SpikeFactory();
            Elements.SpikeElement obS = (Elements.SpikeElement)fabricaSpike.CreateTask(1, descriere, titlu, 2, status, 0, purpose);
            bool success = DatabaseManager.DatabaseManager.Instance.SaveTask(obS);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(success);
            obS.CurrentAsignee = new Member.Member("TEST_USER", 1);

            // execute
            bool successUpdate = DatabaseManager.DatabaseManager.Instance.UpdateTaskStatus(obS);

            // verify
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(successUpdate);
            List<Dictionary<string, object>> tasks = DatabaseManager.DatabaseManager.Instance.FetchTasks();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1, tasks.Count);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(status, tasks[0]["status"]);
        }
        [TestMethod]
        //Testare metoda de editare status bug
        public void Test_Editare_Status_Bug()
        {
            // setup
            CleanTable("task");
            With_Registered_User("TEST_USER", "1");
            string descriere = "Descriere";
            string titlu = "Titlu";
            string status = "TO_DO";
            int severity = 1;
            TaskFactory.TaskFactory fabricaBug = new BugFactory.BugFactory();
            Elements.BugElement obB = (Elements.BugElement)fabricaBug.CreateTask(0, descriere, titlu, severity, status, 0);
            bool success = DatabaseManager.DatabaseManager.Instance.SaveTask(obB);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(success);
            obB.CurrentAsignee = new Member.Member("TEST_USER", 1);

            // execute
            bool successUpdate = DatabaseManager.DatabaseManager.Instance.UpdateTaskStatus(obB);

            // verify
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(successUpdate);
            List<Dictionary<string, object>> tasks = DatabaseManager.DatabaseManager.Instance.FetchTasks();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1, tasks.Count);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(status, tasks[0]["status"]);
        }
        [TestMethod]
        // Testare functionare apasare buton de logare din UserControl:Login
        public void Test_Buton_LogIn_Login()
        {
            // setup
            With_Registered_User("TEST", Cryptography.HashString("12345678"));
            var app = new TaskManager.FormMain();
            app.login1.userBox.Text = "TEST";
            app.login1.passwordBox.Text = "12345678";

            // execute
            app.ConnectionTry();

            // verify
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("To-Dos", app.labelCurrent.Text);
        }
        [TestMethod]
        // Testare functionalitatem buton Register din UserControl:Login
        public void Test_Buton_Register_Login()
        {
            // setup
            CleanTable("users");
            var app = new TaskManager.FormMain();
            app.register1.textBoxRegisterUsername.Text = "TEST";
            app.register1.textBoxRegisterPassword.Text = "12345678";
            app.register1.textBoxRegisterConfirmPassword.Text = "12345678";

            // execute
            app.register1.buttonRegisterAddUser_Click(null, null);

            // verify
            bool userExists = DatabaseManager.DatabaseManager.Instance.CheckUserExits("TEST", Cryptography.HashString("12345678"));
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(userExists);
        }
        [TestMethod]
        //Testare creare obiecte de tip Bug
        public void TestBug()
        {
            // setup
            string descriere = "Descriere";
            string titlu = "Titlu";
            string status = "TO_DO";
            int severity = 1;
            TaskFactory.TaskFactory fabricaBug = new BugFactory.BugFactory();

            // execute
            Elements.BugElement obB = (Elements.BugElement)fabricaBug.CreateTask(0, descriere, titlu, severity, status, 0);

            // verify
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(descriere, obB.Description);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(titlu, obB.Title);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(status, obB.GetStatus());
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(severity, obB.GetSeverity());
        }
        [TestMethod]
        //Testare creare obiecte de tip Feature
        public void TestFeature()
        {
            // setup
            string descriere = "Descriere";
            string titlu = "Titlu";
            string status = "DONE";
            int priority = 5;
            TaskFactory.TaskFactory fabricaFeature = new FeatureFactory.FeatureFactory();

            // execute
            Elements.FeatureElement obF = (Elements.FeatureElement)fabricaFeature.CreateTask(1, descriere, titlu, priority, status, 1);

            // verify
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(descriere, obF.Description);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(titlu, obF.Title);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(status, obF.GetStatus());
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(priority, obF.GetPriority());
        }
        [TestMethod]
        //Testare creare obiecte de tip Spike
        public void TestSpike()
        {
            // setup
            string descriere = "Descriere";
            string titlu = "Titlu";
            string status = "DONE";
            string purpose = "needed for next release";
            TaskFactory.TaskFactory fabricaSpike = new SpikeFactory.SpikeFactory();

            // execute
            Elements.SpikeElement obS = (Elements.SpikeElement)fabricaSpike.CreateTask(1, descriere, titlu, 2, status, 0, purpose);

            // verify
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(descriere, obS.Description);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(titlu, obS.Title);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(status, obS.GetStatus());
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(purpose, obS.GetPurpose());
        }
        [TestMethod]
        // Testare salvare proiect
        public void Test_Salvare_Proiect()
        {
            // setup
            CleanTable("projects");
            string name = "TEST_PROJECT";
            string description = "TEST_DESCRIPTION";

            // execute
            bool success = DatabaseManager.DatabaseManager.Instance.SaveProject(name, description);

            // verify
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(success);
            IDictionary<string, string> project = DatabaseManager.DatabaseManager.Instance.GetProjects();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1, project.Count);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("TEST_DESCRIPTION", project["TEST_PROJECT"]);
        }

        [TestMethod]
        // Testare stergere proiect
        public void Test_Stergere_Proiect()
        {
            // setup
            CleanTable("projects");
            string name = "TEST_PROJECT";
            string description = "TEST_DESCRIPTION";
            bool success = DatabaseManager.DatabaseManager.Instance.SaveProject(name, description);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(success);
            int id = DatabaseManager.DatabaseManager.Instance.GetProjectId(name);

            // execute
            DatabaseManager.DatabaseManager.Instance.DeleteProject(id);

            // verify
            IDictionary<string, string> project = DatabaseManager.DatabaseManager.Instance.GetProjects();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(0, project.Count);
        }
        [TestMethod]
        // Testare existenta proiect
        public void Test_Existenta_Proiect()
        {
            // setup
            CleanTable("projects");
            string name = "TEST_PROJECT";
            string description = "TEST_DESCRIPTION";
            bool success = DatabaseManager.DatabaseManager.Instance.SaveProject(name, description);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(success);

            // execute
            bool existent = DatabaseManager.DatabaseManager.Instance.CheckProjectExits(name);

            // verify
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(existent);
            bool notExistent = DatabaseManager.DatabaseManager.Instance.CheckProjectExits(name + "OTHER");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(notExistent);
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
