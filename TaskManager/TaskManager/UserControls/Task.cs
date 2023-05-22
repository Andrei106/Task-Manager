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
        private Elements.TaskElement _task;

        public Task(Elements.TaskElement task, Control newPane, Control blockedPane, Control inProgressPane, Control waitingPane, Control donePane)
        {
            InitializeComponent();
            this._task = task;
            if (task is Elements.FeatureElement)
            {
                initFeature((Elements.FeatureElement)task);
            } 
            else if (task is Elements.SpikeElement)
            {
                initSpike((Elements.SpikeElement)task);
            } 
            else
            {
                initBug((Elements.BugElement)task);
            }
            this._newPane = newPane;
            this._blockedPane = blockedPane;
            this._inProgressPane = inProgressPane;
            this._waitingPane = waitingPane;
            this._donePane = donePane;
        }

        private void initFeature(Elements.FeatureElement feature)
        {
            this.labelTitle.Text = feature.GetTitle();
            this.labelTaskTitle.Text = "Feature";
            this.labelSpecificField.Text = "Priority";
            this.labelSpecificFieldValue.Text = feature.GetPriority() + "";
            this.textBoxDescription.Text = feature.GetDescription();
            this.labelTaskTitle.BackColor = Color.Lime;
        }

        private void initSpike(Elements.SpikeElement spike)
        {
            this.labelTitle.Text = spike.GetTitle();
            this.labelTaskTitle.Text = "Spike";
            this.labelSpecificField.Text = "Purpose";
            this.labelSpecificFieldValue.Text = spike.GetPurpose();
            this.textBoxDescription.Text = spike.GetDescription();
            this.labelTaskTitle.BackColor = Color.Aqua;
        }

        private void initBug(Elements.BugElement bug)
        {
            this.labelTitle.Text = bug.GetTitle();
            this.labelTaskTitle.Text = "Bug";
            this.labelSpecificField.Text = "Severity";
            this.labelSpecificFieldValue.Text = bug.GetSeverity() + "";
            this.textBoxDescription.Text = bug.GetDescription();
            this.labelTaskTitle.BackColor = Color.Red;
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
                this._task.SetStatus("TO_DO");
            } else if (Cursor.Position.X < 860)
            {
                this.Parent = this._blockedPane;
                this._task.SetStatus("BLOCKED");
            }
            else if (Cursor.Position.X < 1160)
            {
                this.Parent = this._inProgressPane;
                this._task.SetStatus("IN_PROGRESS");
            }
            else if (Cursor.Position.X < 1460)
            {
                this.Parent = this._waitingPane;
                this._task.SetStatus("WAITING_FOR_APPROVAL");
            }
            else
            {
                this.Parent = this._donePane;
                this._task.SetStatus("DONE");
            }
            DatabaseManager.DatabaseManager.Instance.UpdateTaskStatus(this._task);
        }
    }
}
