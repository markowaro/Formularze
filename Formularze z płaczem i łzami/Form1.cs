using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularze_z_płaczem_i_łzami
{
    public partial class Form1 : Form
    {
        public string p = "promotor";
        public string r = "recenzent";
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 0)
            {
                Karta_Pracy f2 = new Karta_Pracy();
                f2.Show();
            }
            else if(comboBox1.SelectedIndex == 1)
            {
                Opinia_pracy f3 = new Opinia_pracy(r);
                f3.Show ();
            }
            else if(comboBox1.SelectedIndex == 2)
            {
                Opinia_pracy f3 = new Opinia_pracy(p);
                f3.Show();

            }
            else if(comboBox1.SelectedIndex == 3)
            {
                Protokolkomisji f4 = new Protokolkomisji();
                f4.Show();
            }   
        }
    }
}
