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
            this.selectCity1 = new ExamenEnrique.UserControls.SelectCity();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // login1
            // 
            this.login1.AutoSize = true;
            this.login1.BackColor = System.Drawing.Color.Transparent;
            this.login1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.login1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.login1.Location = new System.Drawing.Point(179, 93);
            this.login1.Name = "login1";
            this.login1.Size = new System.Drawing.Size(979, 463);
            this.login1.TabIndex = 0;
            // 
            // selectCity1
            // 
            this.selectCity1.BackColor = System.Drawing.Color.Transparent;
            this.selectCity1.Location = new System.Drawing.Point(195, 12);
            this.selectCity1.Name = "selectCity1";
            this.selectCity1.Size = new System.Drawing.Size(890, 632);
            this.selectCity1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Impact", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(994, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 57);
            this.button1.TabIndex = 2;
            this.button1.Text = "Add City";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1216, 766);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.selectCity1);
            this.Controls.Add(this.login1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.Login login1;
        private UserControls.SelectCity selectCity1;
        private System.Windows.Forms.Button button1;
    }
}

