
namespace TaskManager
{
    partial class ProjectControl
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
            this.components = new System.ComponentModel.Container();
            this.labelSelectProject = new System.Windows.Forms.Label();
            this.splitContainerSelectOrCreateProject = new System.Windows.Forms.SplitContainer();
            this.textBoxCurrentProjectDescription = new System.Windows.Forms.TextBox();
            this.labelCurrentProjectDescription = new System.Windows.Forms.Label();
            this.comboBoxCurrentProject = new System.Windows.Forms.ComboBox();
            this.labelCurrentProject = new System.Windows.Forms.Label();
            this.textBoxProjectDescription = new System.Windows.Forms.TextBox();
            this.buttonCreateProject = new System.Windows.Forms.Button();
            this.textBoxProjectName = new System.Windows.Forms.TextBox();
            this.labelProjectName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelCreateProject = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSelectOrCreateProject)).BeginInit();
            this.splitContainerSelectOrCreateProject.Panel1.SuspendLayout();
            this.splitContainerSelectOrCreateProject.Panel2.SuspendLayout();
            this.splitContainerSelectOrCreateProject.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelSelectProject
            // 
            this.labelSelectProject.AutoSize = true;
            this.labelSelectProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelSelectProject.Location = new System.Drawing.Point(194, 145);
            this.labelSelectProject.Name = "labelSelectProject";
            this.labelSelectProject.Size = new System.Drawing.Size(209, 33);
            this.labelSelectProject.TabIndex = 0;
            this.labelSelectProject.Text = "Select Project";
            // 
            // splitContainerSelectOrCreateProject
            // 
            this.splitContainerSelectOrCreateProject.Location = new System.Drawing.Point(0, 0);
            this.splitContainerSelectOrCreateProject.Name = "splitContainerSelectOrCreateProject";
            // 
            // splitContainerSelectOrCreateProject.Panel1
            // 
            this.splitContainerSelectOrCreateProject.Panel1.BackColor = System.Drawing.Color.GhostWhite;
            this.splitContainerSelectOrCreateProject.Panel1.Controls.Add(this.textBoxCurrentProjectDescription);
            this.splitContainerSelectOrCreateProject.Panel1.Controls.Add(this.labelCurrentProjectDescription);
            this.splitContainerSelectOrCreateProject.Panel1.Controls.Add(this.comboBoxCurrentProject);
            this.splitContainerSelectOrCreateProject.Panel1.Controls.Add(this.labelCurrentProject);
            this.splitContainerSelectOrCreateProject.Panel1.Controls.Add(this.labelSelectProject);
            // 
            // splitContainerSelectOrCreateProject.Panel2
            // 
            this.splitContainerSelectOrCreateProject.Panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.splitContainerSelectOrCreateProject.Panel2.Controls.Add(this.textBoxProjectDescription);
            this.splitContainerSelectOrCreateProject.Panel2.Controls.Add(this.buttonCreateProject);
            this.splitContainerSelectOrCreateProject.Panel2.Controls.Add(this.textBoxProjectName);
            this.splitContainerSelectOrCreateProject.Panel2.Controls.Add(this.labelProjectName);
            this.splitContainerSelectOrCreateProject.Panel2.Controls.Add(this.label1);
            this.splitContainerSelectOrCreateProject.Panel2.Controls.Add(this.labelCreateProject);
            this.splitContainerSelectOrCreateProject.Size = new System.Drawing.Size(1314, 631);
            this.splitContainerSelectOrCreateProject.SplitterDistance = 641;
            this.splitContainerSelectOrCreateProject.TabIndex = 1;
            // 
            // textBoxCurrentProjectDescription
            // 
            this.textBoxCurrentProjectDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxCurrentProjectDescription.Location = new System.Drawing.Point(155, 319);
            this.textBoxCurrentProjectDescription.Multiline = true;
            this.textBoxCurrentProjectDescription.Name = "textBoxCurrentProjectDescription";
            this.textBoxCurrentProjectDescription.ReadOnly = true;
            this.textBoxCurrentProjectDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxCurrentProjectDescription.Size = new System.Drawing.Size(355, 139);
            this.textBoxCurrentProjectDescription.TabIndex = 8;
            // 
            // labelCurrentProjectDescription
            // 
            this.labelCurrentProjectDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelCurrentProjectDescription.Location = new System.Drawing.Point(151, 286);
            this.labelCurrentProjectDescription.Name = "labelCurrentProjectDescription";
            this.labelCurrentProjectDescription.Size = new System.Drawing.Size(193, 45);
            this.labelCurrentProjectDescription.TabIndex = 3;
            this.labelCurrentProjectDescription.Text = "Description";
            // 
            // comboBoxCurrentProject
            // 
            this.comboBoxCurrentProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBoxCurrentProject.FormattingEnabled = true;
            this.comboBoxCurrentProject.Location = new System.Drawing.Point(155, 242);
            this.comboBoxCurrentProject.Name = "comboBoxCurrentProject";
            this.comboBoxCurrentProject.Size = new System.Drawing.Size(249, 28);
            this.comboBoxCurrentProject.TabIndex = 2;
            this.comboBoxCurrentProject.SelectedIndexChanged += new System.EventHandler(this.comboBoxCurrentProject_SelectedIndexChanged);
            // 
            // labelCurrentProject
            // 
            this.labelCurrentProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelCurrentProject.Location = new System.Drawing.Point(151, 208);
            this.labelCurrentProject.Name = "labelCurrentProject";
            this.labelCurrentProject.Size = new System.Drawing.Size(193, 45);
            this.labelCurrentProject.TabIndex = 1;
            this.labelCurrentProject.Text = "Current Project";
            // 
            // textBoxProjectDescription
            // 
            this.textBoxProjectDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxProjectDescription.Location = new System.Drawing.Point(164, 319);
            this.textBoxProjectDescription.Multiline = true;
            this.textBoxProjectDescription.Name = "textBoxProjectDescription";
            this.textBoxProjectDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxProjectDescription.Size = new System.Drawing.Size(355, 139);
            this.textBoxProjectDescription.TabIndex = 7;
            // 
            // buttonCreateProject
            // 
            this.buttonCreateProject.BackColor = System.Drawing.Color.GreenYellow;
            this.buttonCreateProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonCreateProject.Location = new System.Drawing.Point(273, 482);
            this.buttonCreateProject.Name = "buttonCreateProject";
            this.buttonCreateProject.Size = new System.Drawing.Size(135, 41);
            this.buttonCreateProject.TabIndex = 6;
            this.buttonCreateProject.Text = "Create";
            this.buttonCreateProject.UseVisualStyleBackColor = false;
            this.buttonCreateProject.Click += new System.EventHandler(this.buttonCreateProject_Click);
            // 
            // textBoxProjectName
            // 
            this.textBoxProjectName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxProjectName.Location = new System.Drawing.Point(164, 242);
            this.textBoxProjectName.Name = "textBoxProjectName";
            this.textBoxProjectName.Size = new System.Drawing.Size(255, 26);
            this.textBoxProjectName.TabIndex = 4;
            // 
            // labelProjectName
            // 
            this.labelProjectName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelProjectName.Location = new System.Drawing.Point(160, 208);
            this.labelProjectName.Name = "labelProjectName";
            this.labelProjectName.Size = new System.Drawing.Size(193, 45);
            this.labelProjectName.TabIndex = 3;
            this.labelProjectName.Text = "Name";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(160, 286);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 45);
            this.label1.TabIndex = 2;
            this.label1.Text = "Description";
            // 
            // labelCreateProject
            // 
            this.labelCreateProject.AutoSize = true;
            this.labelCreateProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelCreateProject.Location = new System.Drawing.Point(180, 145);
            this.labelCreateProject.Name = "labelCreateProject";
            this.labelCreateProject.Size = new System.Drawing.Size(215, 33);
            this.labelCreateProject.TabIndex = 1;
            this.labelCreateProject.Text = "Create Project";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // ProjectControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerSelectOrCreateProject);
            this.Name = "ProjectControl";
            this.Size = new System.Drawing.Size(1314, 631);
            this.splitContainerSelectOrCreateProject.Panel1.ResumeLayout(false);
            this.splitContainerSelectOrCreateProject.Panel1.PerformLayout();
            this.splitContainerSelectOrCreateProject.Panel2.ResumeLayout(false);
            this.splitContainerSelectOrCreateProject.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSelectOrCreateProject)).EndInit();
            this.splitContainerSelectOrCreateProject.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelSelectProject;
        private System.Windows.Forms.SplitContainer splitContainerSelectOrCreateProject;
        private System.Windows.Forms.Label labelCreateProject;
        private System.Windows.Forms.ComboBox comboBoxCurrentProject;
        private System.Windows.Forms.Label labelCurrentProject;
        private System.Windows.Forms.Button buttonCreateProject;
        private System.Windows.Forms.TextBox textBoxProjectName;
        private System.Windows.Forms.Label labelProjectName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox textBoxProjectDescription;
        private System.Windows.Forms.TextBox textBoxCurrentProjectDescription;
        private System.Windows.Forms.Label labelCurrentProjectDescription;
    }
}
