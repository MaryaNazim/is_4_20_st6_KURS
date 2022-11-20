using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MetroFramework.Components;
using MetroFramework.Forms;

namespace is_4_20_st6_KURS
{
    public partial class Form2 : MetroForm
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            metroTextBox2.PasswordChar = '●';
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            metroTextBox2.PasswordChar = '●';
            pictureBox2.Visible = false;
            pictureBox3.Visible = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            metroTextBox2.PasswordChar = '\0';
            pictureBox2.Visible = true;
            pictureBox3.Visible = false;
        }
    }
}
