
namespace TaskManager
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.panelMain = new System.Windows.Forms.Panel();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnToDos = new System.Windows.Forms.Button();
            this.btnProject = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.labelApp = new System.Windows.Forms.Label();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.labelCurrent = new System.Windows.Forms.Label();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.register1 = new TaskManager.UserControls.Register();
            this.login1 = new TaskManager.UserControls.Login();
            this.toDosCtrl = new TaskManager.toDosControll();
            this.projectCtrl = new TaskManager.projectControl();
            this.homeCtrl = new TaskManager.homeControl();
            this.panelMain.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.panelTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.panelMain.Controls.Add(this.btnHelp);
            this.panelMain.Controls.Add(this.btnToDos);
            this.panelMain.Controls.Add(this.btnProject);
            this.panelMain.Controls.Add(this.btnHome);
            this.panelMain.Controls.Add(this.panelLogo);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(200, 690);
            this.panelMain.TabIndex = 0;
            // 
            // btnHelp
            // 
            this.btnHelp.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnHelp.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHelp.FlatAppearance.BorderSize = 0;
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelp.ForeColor = System.Drawing.SystemColors.Window;
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHelp.Location = new System.Drawing.Point(0, 280);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnHelp.Size = new System.Drawing.Size(200, 70);
            this.btnHelp.TabIndex = 4;
            this.btnHelp.Text = "     Help";
            this.btnHelp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnToDos
            // 
            this.btnToDos.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnToDos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnToDos.FlatAppearance.BorderSize = 0;
            this.btnToDos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToDos.ForeColor = System.Drawing.SystemColors.Window;
            this.btnToDos.Image = ((System.Drawing.Image)(resources.GetObject("btnToDos.Image")));
            this.btnToDos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnToDos.Location = new System.Drawing.Point(0, 210);
            this.btnToDos.Name = "btnToDos";
            this.btnToDos.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnToDos.Size = new System.Drawing.Size(200, 70);
            this.btnToDos.TabIndex = 3;
            this.btnToDos.Text = "     To-Dos";
            this.btnToDos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnToDos.UseVisualStyleBackColor = false;
            this.btnToDos.Click += new System.EventHandler(this.btnToDos_Click);
            // 
            // btnProject
            // 
            this.btnProject.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnProject.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProject.FlatAppearance.BorderSize = 0;
            this.btnProject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProject.ForeColor = System.Drawing.SystemColors.Window;
            this.btnProject.Image = ((System.Drawing.Image)(resources.GetObject("btnProject.Image")));
            this.btnProject.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProject.Location = new System.Drawing.Point(0, 140);
            this.btnProject.Name = "btnProject";
            this.btnProject.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnProject.Size = new System.Drawing.Size(200, 70);
            this.btnProject.TabIndex = 2;
            this.btnProject.Text = "     Project";
            this.btnProject.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProject.UseVisualStyleBackColor = false;
            this.btnProject.Click += new System.EventHandler(this.btnProject_Click);
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.ForeColor = System.Drawing.SystemColors.Window;
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.Location = new System.Drawing.Point(0, 70);
            this.btnHome.Name = "btnHome";
            this.btnHome.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnHome.Size = new System.Drawing.Size(200, 70);
            this.btnHome.TabIndex = 1;
            this.btnHome.Text = "     Home";
            this.btnHome.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.panelLogo.Controls.Add(this.labelApp);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.ForeColor = System.Drawing.Color.Transparent;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(200, 70);
            this.panelLogo.TabIndex = 0;
            // 
            // labelApp
            // 
            this.labelApp.AutoSize = true;
            this.labelApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelApp.Location = new System.Drawing.Point(35, 21);
            this.labelApp.Name = "labelApp";
            this.labelApp.Size = new System.Drawing.Size(125, 22);
            this.labelApp.TabIndex = 0;
            this.labelApp.Text = "Task Manager";
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panelTitle.Controls.Add(this.buttonLogout);
            this.panelTitle.Controls.Add(this.labelCurrent);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(200, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(1240, 70);
            this.panelTitle.TabIndex = 1;
            // 
            // labelCurrent
            // 
            this.labelCurrent.AutoSize = true;
            this.labelCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelCurrent.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.labelCurrent.Location = new System.Drawing.Point(31, 21);
            this.labelCurrent.Name = "labelCurrent";
            this.labelCurrent.Size = new System.Drawing.Size(108, 39);
            this.labelCurrent.TabIndex = 0;
            this.labelCurrent.Text = "Home";
            // 
            // buttonLogout
            // 
            this.buttonLogout.BackColor = System.Drawing.Color.SlateGray;
            this.buttonLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogout.Image = ((System.Drawing.Image)(resources.GetObject("buttonLogout.Image")));
            this.buttonLogout.Location = new System.Drawing.Point(1082, 12);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(137, 39);
            this.buttonLogout.TabIndex = 1;
            this.buttonLogout.Text = "       Logout";
            this.buttonLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonLogout.UseVisualStyleBackColor = false;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // register1
            // 
           // this.register1.ConnectAction = null;
            this.register1.ConnectActionBack = null;
            this.register1.Location = new System.Drawing.Point(844, 101);
            this.register1.Name = "register1";
            this.register1.Size = new System.Drawing.Size(304, 210);
            this.register1.TabIndex = 6;
            // 
            // login1
            // 
            this.login1.ConnectAction = null;
            this.login1.ConnectActionRegister = null;
            this.login1.Location = new System.Drawing.Point(525, 101);
            this.login1.Margin = new System.Windows.Forms.Padding(1);
            this.login1.Name = "login1";
            this.login1.Size = new System.Drawing.Size(289, 219);
            this.login1.TabIndex = 5;
            // 
            // toDosCtrl
            // 
            this.toDosCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toDosCtrl.Location = new System.Drawing.Point(200, 70);
            this.toDosCtrl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.toDosCtrl.Name = "toDosCtrl";
            this.toDosCtrl.Size = new System.Drawing.Size(1240, 620);
            this.toDosCtrl.TabIndex = 4;
            this.toDosCtrl.Visible = false;
            // 
            // projectCtrl
            // 
            this.projectCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.projectCtrl.Location = new System.Drawing.Point(200, 70);
            this.projectCtrl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.projectCtrl.Name = "projectCtrl";
            this.projectCtrl.Size = new System.Drawing.Size(1240, 620);
            this.projectCtrl.TabIndex = 3;
            this.projectCtrl.Visible = false;
            // 
            // homeCtrl
            // 
            this.homeCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.homeCtrl.Location = new System.Drawing.Point(200, 70);
            this.homeCtrl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.homeCtrl.Name = "homeCtrl";
            this.homeCtrl.Size = new System.Drawing.Size(1240, 620);
            this.homeCtrl.TabIndex = 2;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1440, 690);
            this.Controls.Add(this.register1);
            this.Controls.Add(this.login1);
            this.Controls.Add(this.toDosCtrl);
            this.Controls.Add(this.projectCtrl);
            this.Controls.Add(this.homeCtrl);
            this.Controls.Add(this.panelTitle);
            this.Controls.Add(this.panelMain);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "FormMain";
            this.Text = "Task Manager";
            this.panelMain.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnToDos;
        private System.Windows.Forms.Button btnProject;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Label labelApp;
        private homeControl homeCtrl;
        private projectControl projectCtrl;
        private toDosControll toDosCtrl;
        private System.Windows.Forms.Label labelCurrent;
        private UserControls.Login login1;
        private UserControls.Register register1;
        private System.Windows.Forms.Button buttonLogout;
    }
}

