using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularze_z_płaczem_i_łzami
{
    public partial class Protokolkomisji : Form
    {
        Protokol_komisji_klasa obiekt_protokolu = new Protokol_komisji_klasa();
        public Protokolkomisji()
        {
            InitializeComponent();
            numericUpDown_ocena_pracy.Maximum = 5; numericUpDown_ocena_pracy.Minimum = 0;
            numericUpDown_ocena_egzaminu.Maximum = 5; numericUpDown_ocena_egzaminu.Minimum = 0;
            numericUpDown_ocena_studiow.Maximum = 5; numericUpDown_ocena_studiow.Minimum = 0;
        }

        private void numericUpDown_ocena_pracy_ValueChanged(object sender, EventArgs e)
        {
            obiekt_protokolu.ocena_pracy = (int)numericUpDown_ocena_pracy.Value;
        }

        private void numericUpDown_ocena_egzaminu_ValueChanged(object sender, EventArgs e)
        {
            obiekt_protokolu.ocena_egzamin = (int)numericUpDown_ocena_egzaminu.Value;
        }

        private void numericUpDown_ocena_studiow_ValueChanged(object sender, EventArgs e)
        {
            obiekt_protokolu.ocena_studiow = (int)numericUpDown_ocena_studiow.Value;
        }

        private void comboBox_tytul_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox_tytul.SelectedIndex == 0)
            {
                obiekt_protokolu.tytul = true;
            }
            else if(comboBox_tytul.SelectedIndex == 1)
            {
                obiekt_protokolu.tytul = false;
            }
        }

        private void buttonZapisz_Click(object sender, EventArgs e)
        {
            System.Xml.Serialization.XmlSerializer save = new System.Xml.Serialization.XmlSerializer(obiekt_protokolu.GetType());  
            using (var writer = new StreamWriter("Protokol_komisji.xml"))
            {
                save.Serialize(writer, obiekt_protokolu);
            }
            MessageBox.Show("Pomyślnie zapisano", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void buttonWczytaj_Click(object sender, EventArgs e)
        {
            if (!File.Exists("./Protokol_komisji.xml"))
            {
                return;
            }
            System.Xml.Serialization.XmlSerializer load = new System.Xml.Serialization.XmlSerializer(obiekt_protokolu.GetType());
            using (var reader = new StreamReader("Protokol_komisji.xml"))
            {
                obiekt_protokolu = (Protokol_komisji_klasa)load.Deserialize(reader);
                numericUpDown_ocena_egzaminu.Value = obiekt_protokolu.ocena_egzamin;
                numericUpDown_ocena_pracy.Value = obiekt_protokolu.ocena_pracy;
                numericUpDown_ocena_studiow.Value = obiekt_protokolu.ocena_studiow;
                if(obiekt_protokolu.tytul == true)
                {
                    comboBox_tytul.SelectedIndex = 0;
                }
                else if(obiekt_protokolu.tytul == false)
                {
                    comboBox_tytul.SelectedIndex = 1;
                }

            }
            MessageBox.Show("Pomyślnie wczytano", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
