/********************************************************************************************
 *                                                                                          *
 *  File:        FormMain.cs                                                                     *
 *  Copyright:   (c) 2023,Epure Andrei-Ioan, Prigoreanu Andrei                           *
 *  E-mail:      andrei-ioan.epure@student.tuiasi.ro,andrei.prigoreanu@tuiasi.ro          *                   *
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



using LoggingModule;
using Proxy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskManager.UserControls;
using DatabaseManager;
using TaskManager.Properties;
using System.Resources;

namespace TaskManager
{
    /// <summary>
    /// Clasa FormMain
    /// </summary>
    public partial class FormMain : Form
    {
        private DatabaseManager.DatabaseManager _databaseManager = DatabaseManager.DatabaseManager.Instance;
        private void SetControlLocationInMiddle(Control control)
        {
            int x = (this.Width - control.Width) / 2;
            int y = (this.Height - control.Height) / 2 - 50;
            control.Location = new Point(x, y);
        }

        /// <summary>
        /// Constructorul clasei FormMain
        /// </summary>
        public FormMain()
        {
            this.BackgroundImage = TaskManager.Properties.Resources.logIn_img;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            InitializeComponent();
            //this.BackgroundImage = Image.FromFile()
            //Initializare conectiune la baza de date(creare database si tabele)
            //_databaseManager.createConnection();

            // Initializare casuta si logica pentru logare
            LoginWindowInitialization();

            // Leg metoda ConnectionValid de eventul pentru logare cu succes
            LoginService.OnLoginSuccessed += ConnectionValid;

            // Leg metoda ConnectionNotValid de eventul pentru logare esuata
            LoginService.OnLoginFailed += ConnectionNotValid;

            // Leg metoda ShowPopUp de eventul din logger, ca vreau sa afisez utilizatorului un mesaj
            Logger.OnPopUpMessageLogged += ShowPopUp;
        }

        /// <summary>
        /// Metoda de initializare a login ului
        /// </summary>
        private void LoginWindowInitialization()
        {
            login1.SetUserText("");
            login1.SetPasswordText("");
            // Ascund toate controalele incat sa ramana doar casuta de login
            HideAllExceptThis(login1);

            SetControlLocationInMiddle(login1);

            // Cand butonul "Login" este apasat va face call la metoda ConnectionTry
            login1.ConnectAction = ConnectionTry;
            login1.ConnectActionRegister = RegisterWindowInitialization;
           
        }
        /// <summary>
        /// Metoda de initializare a register ului
        /// </summary>
        private void RegisterWindowInitialization()
        {
            // Ascund toate controalele incat sa ramana doar casuta de login
            register1.SetUserText("");
            register1.SetPasswordText("");
            register1.SetConfirmPasswordText("");
            HideAllExceptThis(register1);
         
            SetControlLocationInMiddle(register1);
            register1.ConnectActionBack = LoginWindowInitialization;

            // Cand butonul "Login" este apasat va face call la metoda ConnectionTry
            //  register1.ConnectAction = ConnectionTry;
        }

        /// <summary>
        /// Metoda de ascundere a task-urilor 
        /// </summary>
        /// <param name="userControl"></param>
        private void HideAllExceptThis(Control userControl)
        {
            // trec prin toate controalele 
            userControl.Show();
            foreach (Control childControl in Controls)
            {
                // daca controlul nu este de tipul primit, il ascund
                if (childControl.GetType() !=userControl.GetType())
                {
                    childControl.Hide();
                }
            }

        }
        /// <summary>
        /// Metoda de conectare a user-ului
        /// </summary>
        public void ConnectionTry()
        {
            // folosesc proxy-ul incat sa nu interoghez baza de date daca nu e nevoie 
            ILogin loginService = new LoginProxy();

            var username = login1.GetUserText();
            var password = login1.GetPasswordText();

            // apelez metoda din proxy, incepe propriu zis verificarea pentru user si parola
            loginService.LoginMethod(username, password);
        }
        /// <summary>
        /// Metoda ce este apelate cand conexiunea e valida
        /// </summary>
        private void ConnectionValid()
        {
            // ascund casuta de login si afisez restul interfetei
            login1.Hide();
            foreach (Control childControl in Controls)
            {
                if (childControl.GetType() != typeof(UserControls.Login) && childControl.GetType() != typeof(UserControls.Register))
                {
                    childControl.Show();
                }
            }
            labelCurrent.Text = "To-Dos";
        }
        /// <summary>
        /// Metoda ce este apelate cand conexiunea e invalida
        /// </summary>
        private void ConnectionNotValid()
        {
            Logger.PopUpIt(Consts.message);
        }

        /// <summary>
        /// Metoda de afisare mesaj
        /// </summary>
        /// <param name="message"></param>
        private void ShowPopUp(string message)
        {
            MessageBox.Show(this, message, Consts.caption, MessageBoxButtons.OK);
        }
        /// <summary>
        /// Incarcare pagina default
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender,EventArgs e) {        
            homeCtrl.Show();
            projectCtrl.Hide();
            toDosCtrl.Hide();
            labelCurrent.Text = "Home";
        }
        /// <summary>
        /// Incarcare pagina Home
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHome_Click(object sender, EventArgs e)
        {
            homeCtrl.Show();
            projectCtrl.Hide();
            toDosCtrl.Hide();
            labelCurrent.Text = "Home";
        }
        /// <summary>
        /// Incarcare pagina Project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProject_Click(object sender, EventArgs e)
        {
            homeCtrl.Hide();
            projectCtrl.Show();
            toDosCtrl.Hide();
            labelCurrent.Text = "Project";
        }
        /// <summary>
        /// Incarcare pagina ToDos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnToDos_Click(object sender, EventArgs e)
        {
            homeCtrl.Hide();
            projectCtrl.Hide();
            toDosCtrl.Show();
            labelCurrent.Text = "To-Dos";
            int projectId = projectCtrl.GetComboBoxSelectedProject();
            if (projectId > 0)
            {
                toDosCtrl.activateButtons();
                toDosCtrl.CurrentProjectId = projectId;
                toDosCtrl.hideAndshowTask();
            }
            else
            {
                if (toDosCtrl.CurrentProjectId != 0)
                {
                    toDosCtrl.removeTasks();
                }
            
            }
           
        }
        /// <summary>
        /// Afisare Helper
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHelp_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("A4Task.chm");
        }
        /// <summary>
        /// Metoda de LogOut
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void buttonLogout_Click(object sender, EventArgs e)
        {
            LoginWindowInitialization();
        }
    }
}
