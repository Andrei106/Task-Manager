using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugFactory;
using FeatureFactory;
using SpikeFactory;
using TaskFactory;
using TaskManager.UserControls;

namespace TaskManager
{
    public partial class toDosControll : UserControl
    {

        private TaskFactory.TaskFactory _featureFactory, _spikeFactory, _bugFactory;
        public toDosControll()
        {
            InitializeComponent();
            _featureFactory = new FeatureFactory.FeatureFactory();
            _spikeFactory = new SpikeFactory.SpikeFactory();
            _bugFactory = new BugFactory.BugFactory();
            this.InitTasks(DatabaseManager.DatabaseManager.Instance.FetchTasks());
        }

        private void InitTasks(List<Dictionary<string, object>> entries)
        {
            foreach (var entry in entries)
            {

                switch (entry["type"])
                {
                    case "FEATURE":
                        Elements.FeatureElement feature = (Elements.FeatureElement)_featureFactory.CreateTask((int)entry["id"], (string)entry["description"], (string)entry["title"], (int)entry["priority"], (string)entry["status"]);
                        feature.CurrentAsignee = entry["asignee"] != null ? (Member.Member)entry["asignee"] : null;
                        feature.Reporter = entry["reporter"] != null ? (Member.Member)entry["reporter"] : null;
                        AddTaskToColumn(feature);
                        break;
                    case "SPIKE":
                        Elements.SpikeElement spike = (Elements.SpikeElement)_spikeFactory.CreateTask((int)entry["id"], (string)entry["description"], (string)entry["title"], 0, (string)entry["status"], (string)entry["purpose"]);
                        spike.CurrentAsignee = entry["asignee"] != null ? (Member.Member)entry["asignee"] : null;
                        spike.Reporter = entry["reporter"] != null ? (Member.Member)entry["reporter"] : null;
                        AddTaskToColumn(spike);
                        break;
                    case "BUG":
                        Elements.BugElement bug = (Elements.BugElement)_bugFactory.CreateTask((int)entry["id"], (string)entry["description"], (string)entry["title"], (int)entry["severity"], (string)entry["status"]);
                        bug.CurrentAsignee = entry["asignee"] != null ? (Member.Member)entry["asignee"] : null;
                        bug.Reporter = entry["reporter"] != null ? (Member.Member)entry["reporter"] : null;
                        AddTaskToColumn(bug);
                        break;
                }
            }
        }
        
        private void AddTaskToColumn(Elements.TaskElement task)
        {
            switch(task.GetStatus())
            {
                case "TO_DO":
                    flowLayoutNewTasks.Controls.Add(new UserControls.Task(task,
                            this.flowLayoutNewTasks, this.flowLayoutBlockedTasks, this.flowLayoutInProgressTasks, this.flowLayoutWaitingTasks, this.flowLayoutDoneTasks));
                    break;
                case "BLOCKED":
                    flowLayoutBlockedTasks.Controls.Add(new UserControls.Task(task,
                            this.flowLayoutNewTasks, this.flowLayoutBlockedTasks, this.flowLayoutInProgressTasks, this.flowLayoutWaitingTasks, this.flowLayoutDoneTasks));
                    break;
                case "IN_PROGRESS":
                    flowLayoutInProgressTasks.Controls.Add(new UserControls.Task(task,
                            this.flowLayoutNewTasks, this.flowLayoutBlockedTasks, this.flowLayoutInProgressTasks, this.flowLayoutWaitingTasks, this.flowLayoutDoneTasks));
                    break;
                case "WAITING_FOR_APPROVAL":
                    flowLayoutWaitingTasks.Controls.Add(new UserControls.Task(task,
                            this.flowLayoutNewTasks, this.flowLayoutBlockedTasks, this.flowLayoutInProgressTasks, this.flowLayoutWaitingTasks, this.flowLayoutDoneTasks));
                    break;
                case "DONE":
                    flowLayoutDoneTasks.Controls.Add(new UserControls.Task(task,
                            this.flowLayoutNewTasks, this.flowLayoutBlockedTasks, this.flowLayoutInProgressTasks, this.flowLayoutWaitingTasks, this.flowLayoutDoneTasks));
                    break;
            }
        } 

        private void storyNewItem_Click(object sender, EventArgs e)
        {
            TaskDialogForm form = new TaskDialogForm(0);
            DialogResult res = form.ShowDialog();
            if (res == DialogResult.OK)
            {
                int priority;
                Int32.TryParse(form.textBoxPriority.Text, out priority);
                Elements.FeatureElement feature = (Elements.FeatureElement)_featureFactory.CreateTask(0, form.textBoxDescription.Text, form.textBoxTitle.Text, priority, "TO_DO");
                bool saved = DatabaseManager.DatabaseManager.Instance.SaveTask(feature);
                if (saved)
                {
                    flowLayoutNewTasks.Controls.Add(new UserControls.Task(feature,
                        this.flowLayoutNewTasks, this.flowLayoutBlockedTasks, this.flowLayoutInProgressTasks, this.flowLayoutWaitingTasks, this.flowLayoutDoneTasks));
                }
            }

        }

        private void taskNewItem_Click(object sender, EventArgs e)
        {
            TaskDialogForm form = new TaskDialogForm(1);
            DialogResult res = form.ShowDialog();
            if (res == DialogResult.OK)
            {
                Elements.SpikeElement spike = (Elements.SpikeElement)_spikeFactory.CreateTask(0, form.textBoxTitle.Text, form.textBoxDescription.Text, 0, "TO_DO", form.textBoxPurpose.Text);
                bool saved = DatabaseManager.DatabaseManager.Instance.SaveTask(spike);
                if (saved)
                {
                    flowLayoutNewTasks.Controls.Add(new UserControls.Task(spike,
                        this.flowLayoutNewTasks, this.flowLayoutBlockedTasks, this.flowLayoutInProgressTasks, this.flowLayoutWaitingTasks, this.flowLayoutDoneTasks));
                }

            }
        }

        private void bugNewtem_Click(object sender, EventArgs e)
        {
            TaskDialogForm form = new TaskDialogForm(2);
            DialogResult res = form.ShowDialog();
            if (res == DialogResult.OK)
            {
                int severity;

                Int32.TryParse(form.textBoxSeverity.Text, out severity);
                Elements.BugElement bug = (Elements.BugElement)_bugFactory.CreateTask(0, form.textBoxTitle.Text, form.textBoxDescription.Text, severity, "TO_DO");
                bool saved = DatabaseManager.DatabaseManager.Instance.SaveTask(bug);
                if (saved)
                {
                    flowLayoutNewTasks.Controls.Add(new UserControls.Task(bug,
                    this.flowLayoutNewTasks, this.flowLayoutBlockedTasks, this.flowLayoutInProgressTasks, this.flowLayoutWaitingTasks, this.flowLayoutDoneTasks));
                }
            }
        }
    }
}
