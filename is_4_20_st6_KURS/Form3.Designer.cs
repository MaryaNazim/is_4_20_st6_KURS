
namespace is_4_20_st6_KURS
{
    partial class Form3
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
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.афишаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.купитьБилетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оТеареToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.артистыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.операToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.балетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metroDateTime1 = new MetroFramework.Controls.MetroDateTime();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(562, 513);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(200, 100);
            this.metroPanel1.TabIndex = 12;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(244, 118);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(130, 19);
            this.metroLabel1.TabIndex = 13;
            this.metroLabel1.Text = "название спектакля";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.афишаToolStripMenuItem,
            this.купитьБилетToolStripMenuItem,
            this.оТеареToolStripMenuItem,
            this.артистыToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(20, 60);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(559, 24);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // афишаToolStripMenuItem
            // 
            this.афишаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.операToolStripMenuItem,
            this.балетToolStripMenuItem});
            this.афишаToolStripMenuItem.Name = "афишаToolStripMenuItem";
            this.афишаToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.афишаToolStripMenuItem.Text = "Афиша";
            // 
            // купитьБилетToolStripMenuItem
            // 
            this.купитьБилетToolStripMenuItem.Name = "купитьБилетToolStripMenuItem";
            this.купитьБилетToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.купитьБилетToolStripMenuItem.Text = "Купить билет";
            this.купитьБилетToolStripMenuItem.Click += new System.EventHandler(this.купитьБилетToolStripMenuItem_Click);
            // 
            // оТеареToolStripMenuItem
            // 
            this.оТеареToolStripMenuItem.Name = "оТеареToolStripMenuItem";
            this.оТеареToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.оТеареToolStripMenuItem.Text = "О теаре";
            // 
            // артистыToolStripMenuItem
            // 
            this.артистыToolStripMenuItem.Name = "артистыToolStripMenuItem";
            this.артистыToolStripMenuItem.Size = new System.Drawing.Size(116, 20);
            this.артистыToolStripMenuItem.Text = "Актёрский состав";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(22, 20);
            this.toolStripMenuItem1.Text = " ";
            // 
            // операToolStripMenuItem
            // 
            this.операToolStripMenuItem.Name = "операToolStripMenuItem";
            this.операToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.операToolStripMenuItem.Text = "опера";
            this.операToolStripMenuItem.Click += new System.EventHandler(this.операToolStripMenuItem_Click);
            // 
            // балетToolStripMenuItem
            // 
            this.балетToolStripMenuItem.Name = "балетToolStripMenuItem";
            this.балетToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.балетToolStripMenuItem.Text = "балет";
            // 
            // metroDateTime1
            // 
            this.metroDateTime1.Location = new System.Drawing.Point(29, 108);
            this.metroDateTime1.MaxDate = new System.DateTime(2022, 12, 31, 0, 0, 0, 0);
            this.metroDateTime1.MinDate = new System.DateTime(2022, 1, 1, 0, 0, 0, 0);
            this.metroDateTime1.MinimumSize = new System.Drawing.Size(0, 29);
            this.metroDateTime1.Name = "metroDateTime1";
            this.metroDateTime1.Size = new System.Drawing.Size(200, 29);
            this.metroDateTime1.TabIndex = 18;
            this.metroDateTime1.Value = new System.DateTime(2022, 12, 1, 0, 0, 0, 0);
            this.metroDateTime1.ValueChanged += new System.EventHandler(this.metroDateTime1_ValueChanged);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 543);
            this.Controls.Add(this.metroDateTime1);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form3";
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem афишаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem операToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem балетToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem купитьБилетToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оТеареToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem артистыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private MetroFramework.Controls.MetroDateTime metroDateTime1;
    }
}