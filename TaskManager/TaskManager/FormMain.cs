using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskManager
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
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
