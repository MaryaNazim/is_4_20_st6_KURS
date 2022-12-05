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
    public partial class Form3 : MetroForm
    {
        public Form3()
        {
            InitializeComponent();
            metroLabel1.Visible = false;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            metroDateTime1.Visible = false;
            metroDateTime1.Format = DateTimePickerFormat.Custom; 

        }

        private void купитьБилетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 Form4 = new Form4();
            Form4.Show();
        }

        private void афишаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            metroDateTime1.Visible = true;
        }
        private void metroDateTime1_ValueChanged(object sender, EventArgs e)
        {
            Picture();
        }
        private void Picture()
        {
            metroDateTime1.CustomFormat = "dddd 4 декабря 2022";
            pictureBox1.Visible = true;
            metroLabel1.Text = String.Format("Паяльцы");
        }

    }
}
    

