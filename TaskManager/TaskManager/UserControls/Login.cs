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
        }

        public Action ConnectAction { get; set; }

        public void button1_Click(object sender, EventArgs e)
        {
            ConnectAction?.Invoke();
        }

        public string GetUserText()
        {
            return userBox.Text;
        }

        public string GetPasswordText()
        {
            return passwordBox.Text;
        }
    }
}
