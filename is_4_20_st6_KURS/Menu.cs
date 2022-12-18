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

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Form3 Form3 = new Form3();
            Form3.ShowDialog();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Form1_auth Form1_auth = new Form1_auth();
            Form1_auth.ShowDialog();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            Form2_registr Form2_registr = new Form2_registr();
            Form2_registr.ShowDialog();
        }
    }
}
