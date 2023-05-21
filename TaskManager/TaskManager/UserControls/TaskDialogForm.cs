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
    public partial class TaskDialogForm : Form
    {
        private int _type;
        public TaskDialogForm(int type)
        {
            InitializeComponent();
            _type = type;
            this.ControlBox = false;
            switch(type)
            {
                case 0:
                    labelTitle.Text = "Create new Story";
                    panelPurpose.Visible = false;
                    panelSeverity.Visible = false;
                    break;
                case 1:
                    labelTitle.Text = "Create new Task";
                    panelPriority.Visible = false;
                    panelSeverity.Visible = false;
                    break;
                case 2:
                    labelTitle.Text = "Create new Bug";
                    panelPriority.Visible = false;
                    panelPurpose.Visible = false;
                    break;
            }
            buttonCreateNewTask.Enabled = false;
        }

        private void buttonCreateNewTask_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void textBoxInput_TextChanged(object sender, EventArgs e)
        {
            buttonCreateNewTask.Enabled = textBoxTitle.Text.Length > 0 && textBoxDescription.Text.Length > 0
                && ((_type == 0 && textBoxPriority.Text.Length > 0) || (_type == 1 && textBoxPurpose.Text.Length > 0) || (_type == 2 && textBoxSeverity.Text.Length > 0));
        }
    }
}
