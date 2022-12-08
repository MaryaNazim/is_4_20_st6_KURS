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
        string im1 = "C:/Users/Brux/Desktop/изображения/афиша/payazi-afisha.jpg"; //im1 - переменная для хранения пути изображения 1
        string im2 = "C:/Users/Brux/Desktop/изображения/афиша/237karenina.jpg"; //im2- переменная для хранения пути изображения 2

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
                    Test(im1);//Выводится картинка, по пути, прописанный в переменной im1
                    break;
                case "05.12.2022":
                    Test(im2);
                    break;
            }
        }
        public void Test(string one)
        {
            pictureBox1.Image = Image.FromFile(one);
            pictureBox1.Visible = true;
        }
        public void Test1(string one)
        {
            pictureBox2.Image = Image.FromFile(one);
            pictureBox2.Visible = true;
        }

    }
}
    

