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

        private void metroButton1_Click(object sender, EventArgs e)
        { 
            Form3_afishainsert form3_afishainsert = new Form3_afishainsert();
            form3_afishainsert.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6_employinsert form6_employinsert = new Form6_employinsert();
            form6_employinsert.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5_orderplaces form5_orderplaces = new Form5_orderplaces();
            form5_orderplaces.ShowDialog();
        }
    }
}
