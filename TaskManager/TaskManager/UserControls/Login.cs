using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskManager.UserControls
{
    public partial class Login : UserControl
    {
        public Login()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(200, Color.Transparent);
            passwordBox.UseSystemPasswordChar = true;
        }

        public Action ConnectAction { get; set; }
        public Action ConnectActionRegister { get; set; }
        public void button1_Click(object sender, EventArgs e)
        {
            ConnectAction?.Invoke();
        }
        private void buttonRegister_Click(object sender, EventArgs e)
        {
            ConnectActionRegister?.Invoke();
        }
        public string GetUserText()
        {
            return userBox.Text;
        }
        public void SetUserText(string text)
        {
             userBox.Text=text;
        }

        public string GetPasswordText()
        {
            return passwordBox.Text;
        }
        public void SetPasswordText(string text)
        {
            passwordBox.Text=text;
        }
    }
}
