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

        //string im1 = Properties.Resources.payazi_afisha; //im1 - переменная для хранения пути изображения 1

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
            switch (metroDateTime1.Value.ToShortDateString()) //dateTimePicker1.Value - значение в dateTimePicker1. ".ToShortDateString()" - преобразование типа данных в string
            {
                case "04.12.2022": //В случае если выбранная дата - 04.12.2022
                    Test();//Выводится картинка, по пути, прописанный в переменной im1
                    break;
            }
        }
        public void Test()
        {
            pictureBox1.Image = Properties.Resources.payazi_afisha;
            pictureBox1.Visible = true;
        }

    }
}
    

