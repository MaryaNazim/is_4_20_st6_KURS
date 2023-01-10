using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace is_4_20_st6_KURS
{
    public partial class Menu : MetroForm
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void авторизацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1_auth1 form1_Auth = new Form1_auth1();
            form1_Auth.ShowDialog();
        }

        private void регистрацияToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form2_registr Form2 = new Form2_registr();
            Form2.ShowDialog();
        }

        private void афишаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 Form3 = new Form3();
            Form3.ShowDialog();
        }

        private void схемаЗалаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 Form4 = new Form4();
            Form4.ShowDialog();
        }

        private void авторизация1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1_auth1 Form1_auth1 = new Form1_auth1();
            Form1_auth1.ShowDialog();
        }
    }
}
