﻿/**************************************************************************
 *                                                                        *
 *  File:        Task.cs                                                   *
 *  Copyright:   (c) 2023, Lungu Bogdan-Andrei                            *
 *  E-mail:      bogdan-andrei.lungu@tuiasi.ro                            *
 *  Description: Student la Facultatea de Automatica si Calculatoare Iasi *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify  *
 *  it under the terms of the GNU General Public License as published by  *
 *  the Free Software Foundation. This program is distributed in the      *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even   *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR   *
 *  PURPOSE. See the GNU General Public License for more details.         *
 *                                                                        *
 **************************************************************************/


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
                InitFeature((Elements.FeatureElement)task);
            } 
            else if (task is Elements.SpikeElement)
            {
                InitSpike((Elements.SpikeElement)task);
            } 
            else
            {
                InitBug((Elements.BugElement)task);
            }
            this.labelAsigneeUsername.Text = task.CurrentAsignee != null ? task.CurrentAsignee.Nickname : "Unassigned";
            this._newPane = newPane;
            this._blockedPane = blockedPane;
            this._inProgressPane = inProgressPane;
            this._waitingPane = waitingPane;
            this._donePane = donePane;
        }

        private void InitFeature(Elements.FeatureElement feature)
        {
            this.labelTitle.Text = feature.GetTitle();
            this.labelTaskTitle.Text = "Feature";
            this.labelTaskTitle.Font = new Font(this.labelTaskTitle.Font.FontFamily, 12.0F, FontStyle.Bold | FontStyle.Italic);
            this.labelSpecificField.Text = "Priority"; 
            this.labelSpecificField.Font = new Font(this.labelSpecificField.Font.FontFamily, 8.0F, FontStyle.Bold);
            this.labelSpecificFieldValue.Text = feature.GetPriority() + "";
            this.textBoxDescription.Text = feature.GetDescription();
            this.labelTaskTitle.BackColor = Color.Lime;
            this.labelAsigneeUsername.Text = feature.CurrentAsignee != null ? feature.CurrentAsignee.Nickname : "Unassigned";
            this.BackColor = Color.Lime;
        }

        private void InitSpike(Elements.SpikeElement spike)
        {
            this.labelTitle.Text = spike.GetTitle();
            this.labelTaskTitle.Text = "Spike";
            this.labelTaskTitle.Font = new Font(this.labelTaskTitle.Font.FontFamily,12.0F,FontStyle.Bold | FontStyle.Italic);
            this.labelSpecificField.Text = "Purpose";
            this.labelSpecificField.Font = new Font(this.labelSpecificField.Font.FontFamily, 8.0F, FontStyle.Bold);
            this.labelSpecificFieldValue.Text = spike.GetPurpose();
            this.textBoxDescription.Text = spike.GetDescription();
            this.labelTaskTitle.BackColor = Color.Aqua;
            this.labelAsigneeUsername.Text = spike.CurrentAsignee != null ? spike.CurrentAsignee.Nickname : "Unassigned";
            this.BackColor = Color.Aqua;
        }

        private void InitBug(Elements.BugElement bug)
        {
            this.labelTitle.Text = bug.GetTitle();
            this.labelTaskTitle.Text = "Bug";
            this.labelTaskTitle.Font = new Font(this.labelTaskTitle.Font.FontFamily, 12.0F, FontStyle.Bold | FontStyle.Italic);
            this.labelSpecificField.Text = "Severity";
            this.labelSpecificField.Font = new Font(this.labelSpecificField.Font.FontFamily, 8.0F, FontStyle.Bold);
            this.labelSpecificFieldValue.Text = bug.GetSeverity() + "";
            this.textBoxDescription.Text = bug.GetDescription();
            this.labelTaskTitle.BackColor = Color.Tomato;
            this.labelAsigneeUsername.Text = bug.CurrentAsignee != null ? bug.CurrentAsignee.Nickname : "Unassigned";
            this.BackColor = Color.Tomato;
        }

        private void buttonEditTask_Click(object sender, EventArgs e)
        {
            TaskDialogForm editform = new TaskDialogForm(_task, DatabaseManager.DatabaseManager.Instance.FetchUsers());
            if (editform.ShowDialog() == DialogResult.OK)
            {
                if (editform.comboBoxUsers.SelectedItem != null)
                {
                    _task.CurrentAsignee = (Member.Member)(editform.comboBoxUsers.SelectedItem as dynamic).Value;
                }
                else
                {
                    _task.CurrentAsignee = null;
                }
                _task.Title = editform.textBoxTitle.Text;
                _task.Description = editform.textBoxDescription.Text;
                if (_task is Elements.FeatureElement)
                {
                    Elements.FeatureElement feature = (Elements.FeatureElement)_task;
                    int priority;
                    Int32.TryParse(editform.textBoxPriority.Text, out priority);
                    feature.SetPriority(priority);
                    DatabaseManager.DatabaseManager.Instance.UpdateTask(feature);
                    InitFeature(feature);
                }
                else if (_task is Elements.SpikeElement)
                {
                    Elements.SpikeElement spike = (Elements.SpikeElement)_task;
                    spike.SetPurpose(editform.textBoxPurpose.Text);
                    DatabaseManager.DatabaseManager.Instance.UpdateTask(spike);
                    InitSpike(spike);
                }
                else
                {
                    Elements.BugElement bug = (Elements.BugElement)_task;
                    int severity;
                    Int32.TryParse(editform.textBoxSeverity.Text, out severity);
                    bug.SetSeverity(severity);
                    DatabaseManager.DatabaseManager.Instance.UpdateTask(bug);
                    InitBug(bug);
                }
                return;
            }
            else
            {
                if (DatabaseManager.DatabaseManager.Instance.DeleteTask(_task.GetId()))
                {
                    this.Dispose();
                }
            }

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
            if (Cursor.Position.X < 630)
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


        public int TaskProjectId
        {
            get { return _task.ProjectId; }
        }

        public int TaskType
        {
            get { return _task.Type; }
        }
    }
}
