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
    public partial class Task : UserControl
    {
        private bool _isDragging = false;
        private int _oldX, _oldY;
        private Control _newPane, _blockedPane, _inProgressPane, _waitingPane, _donePane;
        public Task(Feature.Feature feature, Control newPane, Control blockedPane, Control inProgressPane, Control waitingPane, Control donePane)
        {
            InitializeComponent();
            this.labelTitle.Text = feature.GetTitle();
            this.labelTaskTitle.Text = "Feature";
            this.labelSpecificField.Text = "Priority";
            this.labelSpecificFieldValue.Text = feature.Priority + "";
            this.textBoxDescription.Text = feature.GetDescription();
            this.labelTaskTitle.BackColor = Color.Lime;
            this._newPane = newPane;
            this._blockedPane = blockedPane;
            this._inProgressPane = inProgressPane;
            this._waitingPane = waitingPane;
            this._donePane = donePane;
        }

        public Task(Spike.Spike spike, Control newPane, Control blockedPane, Control inProgressPane, Control waitingPane, Control donePane)
        {
            InitializeComponent();
            this.labelTitle.Text = spike.GetTitle();
            this.labelTaskTitle.Text = "Spike";
            this.labelSpecificField.Text = "Purpose";
            this.labelSpecificFieldValue.Text = spike.Purpose;
            this.textBoxDescription.Text = spike.GetDescription();
            this.labelTaskTitle.BackColor = Color.Aqua;
            this._newPane = newPane;
            this._blockedPane = blockedPane;
            this._inProgressPane = inProgressPane;
            this._waitingPane = waitingPane;
            this._donePane = donePane;
        }

        public Task(Bug.Bug bug, Control newPane, Control blockedPane, Control inProgressPane, Control waitingPane, Control donePane)
        {
            InitializeComponent();
            this.labelTitle.Text = bug.GetTitle();
            this.labelTaskTitle.Text = "Bug";
            this.labelSpecificField.Text = "Severity";
            this.labelSpecificFieldValue.Text = bug.Severity + "";
            this.textBoxDescription.Text = bug.GetDescription();
            this.labelTaskTitle.BackColor = Color.Red;
            this._newPane = newPane;
            this._blockedPane = blockedPane;
            this._inProgressPane = inProgressPane;
            this._waitingPane = waitingPane;
            this._donePane = donePane;
        }

        private void Task_Load(object sender, EventArgs e)
        {

        }

        private void Task_MouseDown(object sender, MouseEventArgs e)
        {
            this.Parent = this.TopLevelControl;
            this.BringToFront();
            _isDragging = true;
            _oldX = e.X;
            _oldY = e.Y;
        }

        private void Task_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging)
            {
                this.Top = this.Top + (e.Y - _oldY);
                this.Left = this.Left + (e.X - _oldX);
            }
        }

        private void Task_MouseUp(object sender, MouseEventArgs e)
        {
            _isDragging = false;
            if (Cursor.Position.X < 560)
            {
                this.Parent = this._newPane;
            } else if (Cursor.Position.X < 860)
            {
                this.Parent = this._blockedPane;
            } 
            else if (Cursor.Position.X < 1160)
            {
                this.Parent = this._inProgressPane;
            } 
            else if (Cursor.Position.X < 1460)
            {
                this.Parent = this._waitingPane;
            }
            else
            {
                this.Parent = this._donePane;
            }
        }
    }
}
