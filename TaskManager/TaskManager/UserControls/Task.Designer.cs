
namespace TaskManager.UserControls
{
    partial class Task
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelPriority = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelSpecificFieldValue = new System.Windows.Forms.Label();
            this.labelSpecificField = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelTaskTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelAsigneeUsername = new System.Windows.Forms.Label();
            this.buttonEditTask = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.panelPriority.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.panelPriority);
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 30);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(174, 177);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // panelPriority
            // 
            this.panelPriority.Controls.Add(this.labelTitle);
            this.panelPriority.Controls.Add(this.label1);
            this.panelPriority.Location = new System.Drawing.Point(3, 3);
            this.panelPriority.Name = "panelPriority";
            this.panelPriority.Size = new System.Drawing.Size(161, 46);
            this.panelPriority.TabIndex = 0;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(7, 21);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(35, 13);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Title";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelSpecificFieldValue);
            this.panel1.Controls.Add(this.labelSpecificField);
            this.panel1.Location = new System.Drawing.Point(3, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(161, 46);
            this.panel1.TabIndex = 2;
            // 
            // labelSpecificFieldValue
            // 
            this.labelSpecificFieldValue.AutoSize = true;
            this.labelSpecificFieldValue.Location = new System.Drawing.Point(7, 21);
            this.labelSpecificFieldValue.Name = "labelSpecificFieldValue";
            this.labelSpecificFieldValue.Size = new System.Drawing.Size(35, 13);
            this.labelSpecificFieldValue.TabIndex = 1;
            this.labelSpecificFieldValue.Text = "label2";
            // 
            // labelSpecificField
            // 
            this.labelSpecificField.AutoSize = true;
            this.labelSpecificField.Location = new System.Drawing.Point(4, 4);
            this.labelSpecificField.Name = "labelSpecificField";
            this.labelSpecificField.Size = new System.Drawing.Size(0, 13);
            this.labelSpecificField.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBoxDescription);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(3, 107);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(161, 70);
            this.panel2.TabIndex = 2;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(7, 21);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDescription.Size = new System.Drawing.Size(142, 46);
            this.textBoxDescription.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Description";
            // 
            // labelTaskTitle
            // 
            this.labelTaskTitle.AutoSize = true;
            this.labelTaskTitle.Location = new System.Drawing.Point(71, 2);
            this.labelTaskTitle.Name = "labelTaskTitle";
            this.labelTaskTitle.Size = new System.Drawing.Size(35, 13);
            this.labelTaskTitle.TabIndex = 4;
            this.labelTaskTitle.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Asignee:";
            // 
            // labelAsigneeUsername
            // 
            this.labelAsigneeUsername.AutoSize = true;
            this.labelAsigneeUsername.Location = new System.Drawing.Point(49, 14);
            this.labelAsigneeUsername.Name = "labelAsigneeUsername";
            this.labelAsigneeUsername.Size = new System.Drawing.Size(35, 13);
            this.labelAsigneeUsername.TabIndex = 7;
            this.labelAsigneeUsername.Text = "label4";
            // 
            // buttonEditTask
            // 
            this.buttonEditTask.Location = new System.Drawing.Point(48, 208);
            this.buttonEditTask.Name = "buttonEditTask";
            this.buttonEditTask.Size = new System.Drawing.Size(75, 23);
            this.buttonEditTask.TabIndex = 8;
            this.buttonEditTask.Text = "Edit";
            this.buttonEditTask.UseVisualStyleBackColor = true;
            this.buttonEditTask.Click += new System.EventHandler(this.buttonEditTask_Click);
            // 
            // Task
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.buttonEditTask);
            this.Controls.Add(this.labelAsigneeUsername);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.labelTaskTitle);
            this.Name = "Task";
            this.Size = new System.Drawing.Size(189, 234);
            this.Load += new System.EventHandler(this.Task_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Task_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Task_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Task_MouseUp);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panelPriority.ResumeLayout(false);
            this.panelPriority.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panelPriority;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelTaskTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelSpecificFieldValue;
        private System.Windows.Forms.Label labelSpecificField;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelAsigneeUsername;
        public System.Windows.Forms.Button buttonEditTask;
    }
}
