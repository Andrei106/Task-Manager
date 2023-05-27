
namespace TaskManager
{
    partial class homeControl
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
            this.labelHome = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelHome
            // 
            this.labelHome.AutoSize = true;
            this.labelHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelHome.Location = new System.Drawing.Point(381, 141);
            this.labelHome.Name = "labelHome";
            this.labelHome.Size = new System.Drawing.Size(127, 46);
            this.labelHome.TabIndex = 1;
            this.labelHome.Text = "Home";
            // 
            // homeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelHome);
            this.Name = "homeControl";
            this.Size = new System.Drawing.Size(944, 427);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelHome;
    }
}
