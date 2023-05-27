
namespace TaskManager.UserControls
{
    partial class Register
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
            this.groupBoxRegister = new System.Windows.Forms.GroupBox();
            this.textBoxRegisterConfirmPassword = new System.Windows.Forms.TextBox();
            this.labelRegisterConfirmPassword = new System.Windows.Forms.Label();
            this.textBoxRegisterPassword = new System.Windows.Forms.TextBox();
            this.textBoxRegisterUsername = new System.Windows.Forms.TextBox();
            this.labelRegisterPassword = new System.Windows.Forms.Label();
            this.labelRegisterUsername = new System.Windows.Forms.Label();
            this.buttonRegisterAddUser = new System.Windows.Forms.Button();
            this.buttonRegisterBack = new System.Windows.Forms.Button();
            this.groupBoxRegister.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxRegister
            // 
            this.groupBoxRegister.Controls.Add(this.textBoxRegisterConfirmPassword);
            this.groupBoxRegister.Controls.Add(this.labelRegisterConfirmPassword);
            this.groupBoxRegister.Controls.Add(this.textBoxRegisterPassword);
            this.groupBoxRegister.Controls.Add(this.textBoxRegisterUsername);
            this.groupBoxRegister.Controls.Add(this.labelRegisterPassword);
            this.groupBoxRegister.Controls.Add(this.labelRegisterUsername);
            this.groupBoxRegister.Location = new System.Drawing.Point(16, 22);
            this.groupBoxRegister.Name = "groupBoxRegister";
            this.groupBoxRegister.Size = new System.Drawing.Size(272, 138);
            this.groupBoxRegister.TabIndex = 0;
            this.groupBoxRegister.TabStop = false;
            this.groupBoxRegister.Text = "Register";
            // 
            // textBoxRegisterConfirmPassword
            // 
            this.textBoxRegisterConfirmPassword.Location = new System.Drawing.Point(109, 105);
            this.textBoxRegisterConfirmPassword.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxRegisterConfirmPassword.Name = "textBoxRegisterConfirmPassword";
            this.textBoxRegisterConfirmPassword.Size = new System.Drawing.Size(149, 20);
            this.textBoxRegisterConfirmPassword.TabIndex = 6;
            // 
            // labelRegisterConfirmPassword
            // 
            this.labelRegisterConfirmPassword.AutoSize = true;
            this.labelRegisterConfirmPassword.Location = new System.Drawing.Point(5, 112);
            this.labelRegisterConfirmPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRegisterConfirmPassword.Name = "labelRegisterConfirmPassword";
            this.labelRegisterConfirmPassword.Size = new System.Drawing.Size(91, 13);
            this.labelRegisterConfirmPassword.TabIndex = 5;
            this.labelRegisterConfirmPassword.Text = "Confirm Password";
            // 
            // textBoxRegisterPassword
            // 
            this.textBoxRegisterPassword.Location = new System.Drawing.Point(109, 67);
            this.textBoxRegisterPassword.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxRegisterPassword.Name = "textBoxRegisterPassword";
            this.textBoxRegisterPassword.Size = new System.Drawing.Size(149, 20);
            this.textBoxRegisterPassword.TabIndex = 4;
            // 
            // textBoxRegisterUsername
            // 
            this.textBoxRegisterUsername.Location = new System.Drawing.Point(109, 27);
            this.textBoxRegisterUsername.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxRegisterUsername.Name = "textBoxRegisterUsername";
            this.textBoxRegisterUsername.Size = new System.Drawing.Size(149, 20);
            this.textBoxRegisterUsername.TabIndex = 3;
            // 
            // labelRegisterPassword
            // 
            this.labelRegisterPassword.AutoSize = true;
            this.labelRegisterPassword.Location = new System.Drawing.Point(22, 70);
            this.labelRegisterPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRegisterPassword.Name = "labelRegisterPassword";
            this.labelRegisterPassword.Size = new System.Drawing.Size(53, 13);
            this.labelRegisterPassword.TabIndex = 2;
            this.labelRegisterPassword.Text = "Password";
            // 
            // labelRegisterUsername
            // 
            this.labelRegisterUsername.AutoSize = true;
            this.labelRegisterUsername.Location = new System.Drawing.Point(22, 27);
            this.labelRegisterUsername.Name = "labelRegisterUsername";
            this.labelRegisterUsername.Size = new System.Drawing.Size(55, 13);
            this.labelRegisterUsername.TabIndex = 0;
            this.labelRegisterUsername.Text = "Username";
            // 
            // buttonRegisterAddUser
            // 
            this.buttonRegisterAddUser.Location = new System.Drawing.Point(16, 166);
            this.buttonRegisterAddUser.Name = "buttonRegisterAddUser";
            this.buttonRegisterAddUser.Size = new System.Drawing.Size(119, 32);
            this.buttonRegisterAddUser.TabIndex = 1;
            this.buttonRegisterAddUser.Text = "Register";
            this.buttonRegisterAddUser.UseVisualStyleBackColor = true;
            this.buttonRegisterAddUser.Click += new System.EventHandler(this.buttonRegisterAddUser_Click);
            // 
            // buttonRegisterBack
            // 
            this.buttonRegisterBack.Location = new System.Drawing.Point(175, 166);
            this.buttonRegisterBack.Name = "buttonRegisterBack";
            this.buttonRegisterBack.Size = new System.Drawing.Size(113, 32);
            this.buttonRegisterBack.TabIndex = 2;
            this.buttonRegisterBack.Text = "Back";
            this.buttonRegisterBack.UseVisualStyleBackColor = true;
            this.buttonRegisterBack.Click += new System.EventHandler(this.buttonRegisterBack_Click);
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonRegisterBack);
            this.Controls.Add(this.buttonRegisterAddUser);
            this.Controls.Add(this.groupBoxRegister);
            this.Name = "Register";
            this.Size = new System.Drawing.Size(304, 210);
            this.groupBoxRegister.ResumeLayout(false);
            this.groupBoxRegister.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxRegister;
        private System.Windows.Forms.Label labelRegisterUsername;
        private System.Windows.Forms.Label labelRegisterPassword;
        private System.Windows.Forms.TextBox textBoxRegisterPassword;
        private System.Windows.Forms.TextBox textBoxRegisterUsername;
        private System.Windows.Forms.TextBox textBoxRegisterConfirmPassword;
        private System.Windows.Forms.Label labelRegisterConfirmPassword;
        private System.Windows.Forms.Button buttonRegisterAddUser;
        private System.Windows.Forms.Button buttonRegisterBack;
    }
}
