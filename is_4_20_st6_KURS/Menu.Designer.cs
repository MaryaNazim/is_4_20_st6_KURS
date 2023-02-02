
namespace is_4_20_st6_KURS
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.авторизацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.регистрацияToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.афишаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.схемаЗалаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(23, 96);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(440, 291);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.авторизацияToolStripMenuItem,
            this.регистрацияToolStripMenuItem1,
            this.афишаToolStripMenuItem,
            this.схемаЗалаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(20, 60);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(452, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // авторизацияToolStripMenuItem
            // 
            this.авторизацияToolStripMenuItem.Name = "авторизацияToolStripMenuItem";
            this.авторизацияToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.авторизацияToolStripMenuItem.Text = "Авторизация";
            this.авторизацияToolStripMenuItem.Click += new System.EventHandler(this.авторизацияToolStripMenuItem_Click);
            // 
            // регистрацияToolStripMenuItem1
            // 
            this.регистрацияToolStripMenuItem1.Name = "регистрацияToolStripMenuItem1";
            this.регистрацияToolStripMenuItem1.Size = new System.Drawing.Size(88, 20);
            this.регистрацияToolStripMenuItem1.Text = "Регистрация";
            this.регистрацияToolStripMenuItem1.Click += new System.EventHandler(this.регистрацияToolStripMenuItem1_Click);
            // 
            // афишаToolStripMenuItem
            // 
            this.афишаToolStripMenuItem.Name = "афишаToolStripMenuItem";
            this.афишаToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.афишаToolStripMenuItem.Text = "Афиша";
            this.афишаToolStripMenuItem.Click += new System.EventHandler(this.афишаToolStripMenuItem_Click);
            // 
            // схемаЗалаToolStripMenuItem
            // 
            this.схемаЗалаToolStripMenuItem.Name = "схемаЗалаToolStripMenuItem";
            this.схемаЗалаToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.схемаЗалаToolStripMenuItem.Text = "Схема зала";
            this.схемаЗалаToolStripMenuItem.Click += new System.EventHandler(this.схемаЗалаToolStripMenuItem_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 410);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Menu";
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.Text = "Menu";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem авторизацияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem регистрацияToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem афишаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem схемаЗалаToolStripMenuItem;
    }
}