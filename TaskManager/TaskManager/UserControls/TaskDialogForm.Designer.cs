
namespace TaskManager.UserControls
{
    partial class TaskDialogForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonCreateNewTask = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.panelPriority = new System.Windows.Forms.Panel();
            this.textBoxPriority = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panelPurpose = new System.Windows.Forms.Panel();
            this.textBoxPurpose = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panelSeverity = new System.Windows.Forms.Panel();
            this.textBoxSeverity = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1.SuspendLayout();
            this.panelTitle.SuspendLayout();
            this.panelPriority.SuspendLayout();
            this.panelPurpose.SuspendLayout();
            this.panelSeverity.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(14, 23);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(198, 20);
            this.textBoxTitle.TabIndex = 9;
            this.textBoxTitle.TextChanged += new System.EventHandler(this.textBoxInput_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Title";
            // 
            // buttonCreateNewTask
            // 
            this.buttonCreateNewTask.Location = new System.Drawing.Point(120, 16);
            this.buttonCreateNewTask.Name = "buttonCreateNewTask";
            this.buttonCreateNewTask.Size = new System.Drawing.Size(75, 23);
            this.buttonCreateNewTask.TabIndex = 6;
            this.buttonCreateNewTask.Text = "Create";
            this.buttonCreateNewTask.UseVisualStyleBackColor = true;
            this.buttonCreateNewTask.Click += new System.EventHandler(this.buttonCreateNewTask_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(203, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(84, 13);
            this.labelTitle.TabIndex = 5;
            this.labelTitle.Text = "Create new task";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(17, 16);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 10;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.panelTitle);
            this.flowLayoutPanel1.Controls.Add(this.panelPriority);
            this.flowLayoutPanel1.Controls.Add(this.panelPurpose);
            this.flowLayoutPanel1.Controls.Add(this.panelSeverity);
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(124, 25);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(232, 413);
            this.flowLayoutPanel1.TabIndex = 11;
            // 
            // panelTitle
            // 
            this.panelTitle.Controls.Add(this.textBoxTitle);
            this.panelTitle.Controls.Add(this.label2);
            this.panelTitle.Location = new System.Drawing.Point(3, 3);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(225, 55);
            this.panelTitle.TabIndex = 12;
            // 
            // panelPriority
            // 
            this.panelPriority.Controls.Add(this.textBoxPriority);
            this.panelPriority.Controls.Add(this.label3);
            this.panelPriority.Location = new System.Drawing.Point(3, 64);
            this.panelPriority.Name = "panelPriority";
            this.panelPriority.Size = new System.Drawing.Size(225, 55);
            this.panelPriority.TabIndex = 13;
            // 
            // textBoxPriority
            // 
            this.textBoxPriority.Location = new System.Drawing.Point(14, 23);
            this.textBoxPriority.Name = "textBoxPriority";
            this.textBoxPriority.Size = new System.Drawing.Size(198, 20);
            this.textBoxPriority.TabIndex = 9;
            this.textBoxPriority.TextChanged += new System.EventHandler(this.textBoxInput_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Priority";
            // 
            // panelPurpose
            // 
            this.panelPurpose.Controls.Add(this.textBoxPurpose);
            this.panelPurpose.Controls.Add(this.label4);
            this.panelPurpose.Location = new System.Drawing.Point(3, 125);
            this.panelPurpose.Name = "panelPurpose";
            this.panelPurpose.Size = new System.Drawing.Size(225, 55);
            this.panelPurpose.TabIndex = 13;
            // 
            // textBoxPurpose
            // 
            this.textBoxPurpose.Location = new System.Drawing.Point(14, 23);
            this.textBoxPurpose.Name = "textBoxPurpose";
            this.textBoxPurpose.Size = new System.Drawing.Size(198, 20);
            this.textBoxPurpose.TabIndex = 9;
            this.textBoxPurpose.TextChanged += new System.EventHandler(this.textBoxInput_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Purpose";
            // 
            // panelSeverity
            // 
            this.panelSeverity.Controls.Add(this.textBoxSeverity);
            this.panelSeverity.Controls.Add(this.label5);
            this.panelSeverity.Location = new System.Drawing.Point(3, 186);
            this.panelSeverity.Name = "panelSeverity";
            this.panelSeverity.Size = new System.Drawing.Size(225, 55);
            this.panelSeverity.TabIndex = 14;
            // 
            // textBoxSeverity
            // 
            this.textBoxSeverity.Location = new System.Drawing.Point(14, 23);
            this.textBoxSeverity.Name = "textBoxSeverity";
            this.textBoxSeverity.Size = new System.Drawing.Size(198, 20);
            this.textBoxSeverity.TabIndex = 9;
            this.textBoxSeverity.TextChanged += new System.EventHandler(this.textBoxInput_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Severity";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBoxDescription);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(3, 247);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(225, 118);
            this.panel2.TabIndex = 13;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(14, 23);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDescription.Size = new System.Drawing.Size(198, 92);
            this.textBoxDescription.TabIndex = 9;
            this.textBoxDescription.TextChanged += new System.EventHandler(this.textBoxInput_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Description";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonCancel);
            this.panel1.Controls.Add(this.buttonCreateNewTask);
            this.panel1.Location = new System.Drawing.Point(3, 371);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(225, 42);
            this.panel1.TabIndex = 15;
            // 
            // TaskDialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 450);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.labelTitle);
            this.Name = "TaskDialogForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.panelPriority.ResumeLayout(false);
            this.panelPriority.PerformLayout();
            this.panelPurpose.ResumeLayout(false);
            this.panelPurpose.PerformLayout();
            this.panelSeverity.ResumeLayout(false);
            this.panelSeverity.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonCreateNewTask;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelPriority;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelPurpose;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelSeverity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TextBox textBoxTitle;
        public System.Windows.Forms.TextBox textBoxPriority;
        public System.Windows.Forms.TextBox textBoxPurpose;
        public System.Windows.Forms.TextBox textBoxSeverity;
        public System.Windows.Forms.TextBox textBoxDescription;
    }
}