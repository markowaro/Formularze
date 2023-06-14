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
    public partial class Opinia_pracy : Form
    {
        public string temp_val = "";
        Opinia_promotora op = new Opinia_promotora();
        Opinia_recenzenta or = new Opinia_recenzenta();
        
        public Opinia_pracy(string typ)
        {
            InitializeComponent();
            this.temp_val = typ;
            if(temp_val == "promotor")
            {
                label1.Text = "Imie i nazwisko promotora: ";
            }
            else if(temp_val == "recenzent")
            {
                label1.Text = "Imie i nazwisko recenzenta: ";
            }


        }

        private void textBox_imie_nazwisko_TextChanged(object sender, EventArgs e)
        {
            if(temp_val == "promotor")
            {
                op.imie_nazwisko_promotora = textBox_imie_nazwisko.Text; 
            }
            else
            {
                or.imie_nazwisko_recenzenta = textBox_imie_nazwisko.Text;
            }
        }

        private void textBox_tytul_pracy_TextChanged(object sender, EventArgs e)
        {
            if (temp_val == "promotor")
            {
                op.tytul_pracy = textBox_tytul_pracy.Text;
            }
            else
            {
                or.tytul_pracy = textBox_tytul_pracy.Text;

            }
        }

        private void textBox_tytul_pracy_ang_TextChanged(object sender, EventArgs e)
        {
            if (temp_val == "promotor")
            {
                op.tytul_pracy_ang = textBox_tytul_pracy_ang.Text;
            }
            else
            {
                or.tytul_pracy_ang = textBox_tytul_pracy_ang.Text;

            }
        }

        private void textBox_realizacja_TextChanged(object sender, EventArgs e)
        {
            if (temp_val == "promotor")
            {
                op.realizacja = textBox_realizacja.Text;
            }
            else
            {
                or.realizacja = textBox_realizacja.Text;

            }
        }

        private void textBox_istotnosc_TextChanged(object sender, EventArgs e)
        {
            if (temp_val == "promotor")
            {
                op.istotnosc = textBox_istotnosc.Text;
            }
            else
            {
                or.istotnosc = textBox_istotnosc.Text;

            }
        }

        private void textBox_praktycznosc_TextChanged(object sender, EventArgs e)
        {
            if (temp_val == "promotor")
            {
                op.praktycznosc = textBox_praktycznosc.Text;
            }
            else
            {
                or.praktycznosc = textBox_praktycznosc.Text;

            }
        }

        private void textBox_poprawnosc_TextChanged(object sender, EventArgs e)
        {
            if (temp_val == "promotor")
            {
                op.poprawnosc = textBox_poprawnosc.Text;
            }
            else
            {
                or.poprawnosc = textBox_poprawnosc.Text;

            }
        }

        private void textBox_bibliografia_TextChanged(object sender, EventArgs e)
        {
            if (temp_val == "promotor")
            {
                op.bibliografia = textBox_bibliografia.Text;
            }
            else
            {
                or.bibliografia = textBox_bibliografia.Text;

            }
        }

        private void textBox_zredagowanie_TextChanged(object sender, EventArgs e)
        {
            if (temp_val == "promotor")
            {
                op.zredagowanie = textBox_zredagowanie.Text;
            }
            else
            {
                or.zredagowanie = textBox_zredagowanie.Text;

            }
        }

        private void textBox_wiedza_TextChanged(object sender, EventArgs e)
        {
            if (temp_val == "promotor")
            {
                op.wiedza = textBox_wiedza.Text;
            }
            else
            {
                or.wiedza = textBox_wiedza.Text;

            }
        }

        private void textBox_zaangazowanie_TextChanged(object sender, EventArgs e)
        {
            if (temp_val == "promotor")
            {
                op.zaangazowanie = textBox_zaangazowanie.Text;
            }
            else
            {
                or.zaangazowanie = textBox_zaangazowanie.Text;

            }
        }

        private void buttonZapisz_Click(object sender, EventArgs e)
        {
            if (temp_val == "promotor")
            {
                System.Xml.Serialization.XmlSerializer save = new System.Xml.Serialization.XmlSerializer(op.GetType());
                using (var writer = new StreamWriter("Opinia_promotora.xml"))
                {
                    save.Serialize(writer, op);
                }

                MessageBox.Show("Plik Opinia_promotora.xml został zapisany.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                System.Xml.Serialization.XmlSerializer save = new System.Xml.Serialization.XmlSerializer(or.GetType());
                using (var writer = new StreamWriter("Opinia_recenzenta.xml"))
                {
                    save.Serialize(writer, or);
                }

                MessageBox.Show("Plik Opinia_recenzenta.xml został zapisany.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonWczytaj_Click(object sender, EventArgs e)
        {
            if (temp_val == "promotor")
            {
                if (!File.Exists("./Opinia_promotora.xml"))
                {
                    return;
                }

                System.Xml.Serialization.XmlSerializer load = new System.Xml.Serialization.XmlSerializer(op.GetType());
                using (var reader = new StreamReader("Opinia_promotora.xml"))
                {
                    op = (Opinia_promotora)load.Deserialize(reader);
                    textBox_imie_nazwisko.Text = op.imie_nazwisko_promotora;
                    textBox_tytul_pracy.Text = op.tytul_pracy;
                    textBox_tytul_pracy_ang.Text = op.tytul_pracy_ang;
                    textBox_realizacja.Text = op.realizacja;
                    textBox_istotnosc.Text = op.istotnosc;
                    textBox_praktycznosc.Text = op.praktycznosc; 
                    textBox_poprawnosc.Text = op.poprawnosc; 
                    textBox_bibliografia.Text = op.bibliografia;
                    textBox_zredagowanie.Text = op.zredagowanie;
                    textBox_wiedza.Text = op.wiedza;
                    textBox_zaangazowanie.Text = op.zaangazowanie;
                }

                MessageBox.Show("Plik Opinia_promotora.xml został wczytany.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (!File.Exists("./Opinia_recenzenta.xml"))
                {
                    return;
                }

                System.Xml.Serialization.XmlSerializer load = new System.Xml.Serialization.XmlSerializer(or.GetType());
                using (var reader = new StreamReader("Opinia_recenzenta.xml"))
                {
                    or = (Opinia_recenzenta)load.Deserialize(reader);
                    textBox_imie_nazwisko.Text = or.imie_nazwisko_recenzenta;
                    textBox_tytul_pracy.Text = or.tytul_pracy;
                    textBox_tytul_pracy_ang.Text = or.tytul_pracy_ang;
                    textBox_realizacja.Text = or.realizacja;
                    textBox_istotnosc.Text = or.istotnosc;
                    textBox_praktycznosc.Text = or.praktycznosc;
                    textBox_poprawnosc.Text = or.poprawnosc;
                    textBox_bibliografia.Text = or.bibliografia;
                    textBox_zredagowanie.Text = or.zredagowanie;
                    textBox_wiedza.Text = or.wiedza;
                    textBox_zaangazowanie.Text = or.zaangazowanie;
                }

                MessageBox.Show("Plik Opinia_recenzenta.xml został wczytany.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
