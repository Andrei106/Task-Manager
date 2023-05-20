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
            LoginWindowInitialization();

            LoginService.OnLoginSuccessed += ConnectionValid;
            LoginService.OnLoginFailed += ConnectionNotValid;
            Logger.OnPopUpMessageLogged += ShowPopUp;
        }

        private void LoginWindowInitialization()
        {
            HideAllExceptLogin();
            SetControlLocationInMiddle(login1);
            login1.ConnectAction = ConnectionTry;
        }

        private void HideAllExceptLogin()
        {
            foreach (Control childControl in Controls)
            {
                if (childControl.GetType() != typeof(UserControls.Login))
                {
                    childControl.Hide();
                }
            }
        }

        private void ConnectionTry()
        {
            ILogin loginService = new LoginProxy();

            var username = login1.GetUserText();
            var password = login1.GetPasswordText();

            loginService.LoginMethod(username, password);
        }

        private void ConnectionValid()
        {
            login1.Hide();
            foreach (Control childControl in Controls)
            {
                if (childControl.GetType() != typeof(UserControls.Login))
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
            Task t = new Task();
            t.Show();
         
            homeCtrl.Controls.Add(t);
   
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
    }
}
