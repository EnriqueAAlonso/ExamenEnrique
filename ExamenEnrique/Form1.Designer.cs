namespace ExamenEnrique
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.login1 = new ExamenEnrique.UserControls.Login();
            this.SuspendLayout();
            // 
            // login1
            // 
            this.login1.AutoSize = true;
            this.login1.BackColor = System.Drawing.Color.Transparent;
            this.login1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.login1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.login1.Location = new System.Drawing.Point(421, 107);
            this.login1.Name = "login1";
            this.login1.Size = new System.Drawing.Size(396, 459);
            this.login1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1216, 766);
            this.Controls.Add(this.login1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.Login login1;
    }
}

