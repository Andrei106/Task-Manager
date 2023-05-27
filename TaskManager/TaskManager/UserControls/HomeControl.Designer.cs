
namespace TaskManager
{
    partial class HomeControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeControl));
            this.labelHome = new System.Windows.Forms.Label();
            this.labelAdditionalText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelHome
            // 
            this.labelHome.AutoSize = true;
            this.labelHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelHome.Location = new System.Drawing.Point(414, 61);
            this.labelHome.Name = "labelHome";
            this.labelHome.Size = new System.Drawing.Size(379, 46);
            this.labelHome.TabIndex = 1;
            this.labelHome.Text = "Welcome to A4Task";
            // 
            // labelAdditionalText
            // 
            this.labelAdditionalText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelAdditionalText.Location = new System.Drawing.Point(309, 167);
            this.labelAdditionalText.Name = "labelAdditionalText";
            this.labelAdditionalText.Size = new System.Drawing.Size(632, 304);
            this.labelAdditionalText.TabIndex = 2;
            this.labelAdditionalText.Text = resources.GetString("labelAdditionalText.Text");
            // 
            // HomeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelAdditionalText);
            this.Controls.Add(this.labelHome);
            this.Name = "HomeControl";
            this.Size = new System.Drawing.Size(944, 511);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelHome;
        private System.Windows.Forms.Label labelAdditionalText;
    }
}
