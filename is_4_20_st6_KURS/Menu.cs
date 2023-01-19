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
            Form2_registr form2 = new Form2_registr();
            form2.ShowDialog();
        }

        private void афишаToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void авторизация1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1_auth1 form1_auth1 = new Form1_auth1();
            form1_auth1.ShowDialog();
        }

        private void фильтрзаписейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3_afishafilter form3_afishafilter = new Form3_afishafilter();
            form3_afishafilter.ShowDialog();
        }

        private void просмотрАфишиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }

        private void удалитьЗаписьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3_afishadelete form3_afishadelete = new Form3_afishadelete();
            form3_afishadelete.ShowDialog();
        }

        private void добавитьЗаписьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3_afishainsert form3_afishainsert = new Form3_afishainsert();
            form3_afishainsert.ShowDialog();
        }

        private void редактироватьБрониToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5_orderplacedatagrid form5_orderplacedatagrid = new Form5_orderplacedatagrid();
            form5_orderplacedatagrid.ShowDialog();
        }

        private void просмотрСхемыЗалаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.ShowDialog();
        }
    }
}
