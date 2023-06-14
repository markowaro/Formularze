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
    public partial class Karta_Pracy : Form
    {
        Karta_glowna obiekt_karty = new Karta_glowna();
        public Karta_Pracy()
        {
            InitializeComponent();
        }

        private void textBox_jednostka_promotora_TextChanged(object sender, EventArgs e)
        {
            obiekt_karty.jednostka_prom = textBox_jednostka_promotora.Text;
        }

        private void textBox_promotor_TextChanged(object sender, EventArgs e)
        {
            obiekt_karty.promotor = textBox_promotor.Text;
        }

        private void textBox_termin_oddania_TextChanged(object sender, EventArgs e)
        {
            obiekt_karty.termin_oddania = textBox_termin_oddania.Text;
        }

        private void textBox_zakres_TextChanged(object sender, EventArgs e)
        {
            obiekt_karty.zakres = textBox_zakres.Text;
        }

        private void textBox_dane_wejsciowe_TextChanged(object sender, EventArgs e)
        {
            obiekt_karty.dane_wejsciowe = textBox_dane_wejsciowe.Text;
        }

        private void textBox_tytul_pracy_ang_TextChanged(object sender, EventArgs e)
        {
            obiekt_karty.tytul_pracy_ang = textBox_tytul_pracy_ang.Text;
        }

        private void textBox_tytul_pracy_TextChanged(object sender, EventArgs e)
        {
            obiekt_karty.tytul_pracy = textBox_tytul_pracy.Text;
        }

        private void textBox_imie_nazwisko_TextChanged(object sender, EventArgs e)
        {
            obiekt_karty.imie_nazwisko = textBox_imie_nazwisko.Text;
        }

        private void buttonZapisz_Click(object sender, EventArgs e)
        {
            System.Xml.Serialization.XmlSerializer zapis = new System.Xml.Serialization.XmlSerializer(obiekt_karty.GetType());
            using (var writer = new StreamWriter("Karta_pracy.xml"))
            {
                zapis.Serialize(writer, obiekt_karty);
            }

            MessageBox.Show("Plik Karta_pracy.xml został zapisany.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonWczytaj_Click(object sender, EventArgs e)
        {
            if (!File.Exists("./Karta_pracy.xml"))
            {
                return;
            }

            System.Xml.Serialization.XmlSerializer odczyt = new System.Xml.Serialization.XmlSerializer(obiekt_karty.GetType());
            using (var reader = new StreamReader("Karta_pracy.xml"))
            {
                obiekt_karty = (Karta_glowna)odczyt.Deserialize(reader);
                textBox_imie_nazwisko.Text = obiekt_karty.imie_nazwisko; 
                textBox_tytul_pracy.Text = obiekt_karty.tytul_pracy; 
                textBox_tytul_pracy_ang.Text = obiekt_karty.tytul_pracy_ang;
                textBox_dane_wejsciowe.Text = obiekt_karty.dane_wejsciowe;
                textBox_zakres.Text = obiekt_karty.zakres;
                textBox_termin_oddania.Text = obiekt_karty.termin_oddania;
                textBox_promotor.Text = obiekt_karty.promotor;
                textBox_jednostka_promotora.Text = obiekt_karty.jednostka_prom;
            }

            MessageBox.Show("Plik Karta_pracy.xml został wczytany.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
