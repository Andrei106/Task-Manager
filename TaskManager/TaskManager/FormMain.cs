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

namespace TaskManager
{
    public partial class FormMain : Form
    {
        private void SetControlLocationInMiddle(Control control)
        {
            int x = (this.Width - control.Width) / 2;
            int y = (this.Height - control.Height) / 2;
            control.Location = new Point(x, y);
        }

        public FormMain()
        {
            InitializeComponent();

            // Initializare casuta si logica pentru logare
            LoginWindowInitialization();

            // Leg metoda ConnectionValid de eventul pentru logare cu succes
            LoginService.OnLoginSuccessed += ConnectionValid;

            // Leg metoda ConnectionNotValid de eventul pentru logare esuata
            LoginService.OnLoginFailed += ConnectionNotValid;

            // Leg metoda ShowPopUp de eventul din logger, ca vreau sa afisez utilizatorului un mesaj
            Logger.OnPopUpMessageLogged += ShowPopUp;
        }

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

        private void ConnectionTry()
        {
            // folosesc proxy-ul incat sa nu interoghez baza de date daca nu e nevoie 
            ILogin loginService = new LoginProxy();

            var username = login1.GetUserText();
            var password = login1.GetPasswordText();

            // apelez metoda din proxy, incepe propriu zis verificarea pentru user si parola
            loginService.LoginMethod(username, password);
        }

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
        }

        private void ConnectionNotValid()
        {
            Logger.PopUpIt(Consts.message);
        }

        private void ShowPopUp(string message)
        {
            MessageBox.Show(this, message, Consts.caption, MessageBoxButtons.OK);
        }

        private void FormMain_Load(object sender,EventArgs e) {        
            homeCtrl.Show();
            projectCtrl.Hide();
            toDosCtrl.Hide();
            labelCurrent.Text = "Home";
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
               homeCtrl.Show();
            projectCtrl.Hide();
            toDosCtrl.Hide();
            labelCurrent.Text = "Home";
        }

        private void btnProject_Click(object sender, EventArgs e)
        {
            homeCtrl.Hide();
            projectCtrl.Show();
            toDosCtrl.Hide();
            labelCurrent.Text = "Project";
        }

        private void btnToDos_Click(object sender, EventArgs e)
        {
            homeCtrl.Hide();
            projectCtrl.Hide();
            toDosCtrl.Show();
            labelCurrent.Text = "To-Dos";
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Help", "Help");
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            LoginWindowInitialization();
        }
    }
}
