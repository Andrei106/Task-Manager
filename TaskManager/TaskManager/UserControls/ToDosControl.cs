using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskManager.UserControls;

namespace TaskManager
{
    public partial class toDosControll : UserControl
    {
        public toDosControll()
        {
            InitializeComponent();
        }

        private void storyNewItem_Click(object sender, EventArgs e)
        {
            TaskDialogForm form = new TaskDialogForm(0);
            DialogResult res = form.ShowDialog();
            Console.WriteLine(res);
            int priority;
            Int32.TryParse(form.textBoxPriority.Text, out priority); 
            //TODO: use factory
            flowLayoutNewTasks.Controls.Add(new UserControls.Task(new Elements.FeatureElement(0, form.textBoxTitle.Text, form.textBoxDescription.Text, priority), 
                this.flowLayoutNewTasks, this.flowLayoutBlockedTasks, this.flowLayoutInProgressTasks, this.flowLayoutWaitingTasks, this.flowLayoutDoneTasks));
        }

        private void taskNewItem_Click(object sender, EventArgs e)
        {
            TaskDialogForm form = new TaskDialogForm(1);
            DialogResult res = form.ShowDialog();
            Console.WriteLine(res);

            flowLayoutNewTasks.Controls.Add(new UserControls.Task(new Elements.SpikeElement(0, form.textBoxTitle.Text, form.textBoxDescription.Text, form.textBoxPurpose.Text),
                this.flowLayoutNewTasks, this.flowLayoutBlockedTasks, this.flowLayoutInProgressTasks, this.flowLayoutWaitingTasks, this.flowLayoutDoneTasks));
        }

        private void bugNewtem_Click(object sender, EventArgs e)
        {
            TaskDialogForm form = new TaskDialogForm(2);
            DialogResult res = form.ShowDialog();
            Console.WriteLine(res);
            int severity;

            Int32.TryParse(form.textBoxSeverity.Text, out severity);
            //TODO: use factory
            flowLayoutNewTasks.Controls.Add(new UserControls.Task(new Elements.BugElement(0, form.textBoxTitle.Text, form.textBoxDescription.Text, severity),
                this.flowLayoutNewTasks, this.flowLayoutBlockedTasks, this.flowLayoutInProgressTasks, this.flowLayoutWaitingTasks, this.flowLayoutDoneTasks));
        }
    }
}
