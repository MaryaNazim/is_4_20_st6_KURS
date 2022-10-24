using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Components;
using MetroFramework.Forms;


namespace is_4_20_st6_KURS
{
    public partial class Form0 : MetroForm
    {
        public Form0()
        {
            InitializeComponent();
        }

        private void ЛИЧНЫЙКАБИНЕТToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

    }
}
