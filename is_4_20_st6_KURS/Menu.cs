﻿using System;
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

        private void регистрацияToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form2_registr form2_registr = new Form2_registr();
            form2_registr.ShowDialog();
        }

        private void авторизацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1_auth1 form1_auth1 = new Form1_auth1();
            form1_auth1.ShowDialog();
        }

    }
}
