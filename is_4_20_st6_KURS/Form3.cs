﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MetroFramework.Forms;

namespace is_4_20_st6_KURS
{
    public partial class Form3 : MetroForm
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 Form4 = new Form4();
            Form4.Show();
        }

        private void metroDateTime1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}