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
    public partial class Menu_admin : MetroForm
    {
        public Menu_admin()
        {
            InitializeComponent();
        }

        private void metroLabel2_Click(object sender, EventArgs e)
        {
            Form3_afishadelete form3_afishadelete = new Form3_afishadelete();
            form3_afishadelete.ShowDialog();
        }

        private void metroLabel3_Click(object sender, EventArgs e)
        {
            Form3_afishafilter form3_afishafilter = new Form3_afishafilter();
            form3_afishafilter.ShowDialog();
        }

        private void metroLabel4_Click(object sender, EventArgs e)
        {
            Form3_afishainsert form3_afishainsert = new Form3_afishainsert();
            form3_afishainsert.ShowDialog();
        }

        private void metroLabel5_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel6_Click(object sender, EventArgs e)
        {
            Form5_orderplaces form5_orderplaces = new Form5_orderplaces();
            form5_orderplaces.ShowDialog();
        }

        private void metroLabel7_Click(object sender, EventArgs e)
        {
            Form6_employ form6_employ = new Form6_employ();
            form6_employ.ShowDialog();
        }

        private void metroLabel8_Click(object sender, EventArgs e)
        {
            Form7_afisharooms form7_afisharooms = new Form7_afisharooms();
            form7_afisharooms.ShowDialog();
        }
    }
}
