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
            panelAuditFields.Visible = false;
            buttonCreateNewTask.Enabled = false;
        }

        public TaskDialogForm(Elements.TaskElement task, List<Member.Member> users)
        {
            InitializeComponent();
            this.ControlBox = false;
            panelPurpose.Visible = false;
            panelSeverity.Visible = false;

            labelTitle.Text = "Edit task";
            buttonCreateNewTask.Text = "Save";
            buttonCancel.Text = "Delete";
            List<ComboboxUserEntry> entries = new List<ComboboxUserEntry>();
            foreach (var user in users)
            {
                entries.Add(new ComboboxUserEntry(user.Nickname, user));
            }
            comboBoxUsers.DataSource = entries;
            if (task.CurrentAsignee != null)
            {
                comboBoxUsers.SelectedItem = task.CurrentAsignee;
            }
            else
            {
                comboBoxUsers.SelectedIndex = -1;
            }
            if (task is Elements.FeatureElement)
            {
                InitEditForm((Elements.FeatureElement)task);
            }
            else if (task is Elements.SpikeElement)
            {
                InitEditForm((Elements.SpikeElement)task);
            }
            else
            {
                InitEditForm((Elements.BugElement)task);
            }
        }

        private void InitEditForm(Elements.FeatureElement feature)
        {
            textBoxTitle.Text = feature.GetTitle();
            textBoxDescription.Text = feature.GetDescription();
            textBoxPriority.Text = feature.GetPriority() + "";
            labelReporterUsername.Text = feature.Reporter.Nickname;
        }

        private void InitEditForm(Elements.SpikeElement feature)
        {
            textBoxTitle.Text = feature.GetTitle();
            textBoxDescription.Text = feature.GetDescription();
            textBoxPriority.Text = feature.GetPurpose();
            labelReporterUsername.Text = feature.Reporter.Nickname;
        }

        private void InitEditForm(Elements.BugElement feature)
        {
            textBoxTitle.Text = feature.GetTitle();
            textBoxDescription.Text = feature.GetDescription();
            textBoxPriority.Text = feature.GetSeverity() + "";
            labelReporterUsername.Text = feature.Reporter.Nickname;
        }

        public void buttonCreateNewTask_Click(object sender, EventArgs e)
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

    class ComboboxUserEntry
    {
        public string Text { get; set; }
        public Member.Member Value { get; set; }

        public ComboboxUserEntry(string text, Member.Member value)
        {
            Text = text;
            Value = value;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
