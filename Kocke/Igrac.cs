using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kocke
{
    public partial class Igrac : Form
    {
        public Igrac()
        {
            InitializeComponent();

            brojKocke = new int[5] { 0, 0, 0, 0, 0 };
            slucajni = new Random();
        }

        static string imeCrveni, imePlavi;
        static int brRundi;

        int brojacRunde = 0, sumaRunde = 0, ukupnaSuma = 0, brojacSR = 0, korakRunde = 0, pobjeda = 0;
        bool startStop = true;
        int[] brojKocke;
        Random slucajni;

        public string ImeCrveni
        {
            //set { imeCrveni = value; }
            get { return imeCrveni; }
        }

        public string ImePlavi
        {
            //set { imePlavi = value; }
            get { return imePlavi; }
        }

        public int BrojRundi
        {
            //set { brRundi = value; }
            get { return brRundi; }
        }

        public bool StartStop
        {
            set { startStop = value; }
            get { return startStop; }
        }

        public int BrojacRunde
        {
            set { brojacRunde = value; }
            get { return brojacRunde; }
        }

        public int SumaRunde
        {
            set { sumaRunde = value; }
            get { return sumaRunde; }
        }

        public int UkupnaSuma
        {
            set { ukupnaSuma = value; }
            get { return ukupnaSuma; }
        }

        public int BrojacSR
        {
            set { brojacSR = value; }
            get { return brojacSR; }
        }

        public int KorakRunde
        {
            set { korakRunde = value; }
            get { return korakRunde; }
        }

        public int Pobjeda
        {
            set { pobjeda = value; }
            get { return pobjeda; }
        }

        public int[] BrojKocke
        {
            set { brojKocke = value; }
            get { return brojKocke; }
        }

        public void SimulacijaVrtenja(int[] niz, PictureBox[] pictBox5, Image[] image6)
        {
            //random brojevi od 1 do 6 sprema ih u cjelobrojni niz BrojKocke[] koji će se prikazivati u 5 PictureBox-ova
            for (int i = 0; i < brojKocke.Length; i++)
                brojKocke[i] = slucajni.Next(1, 7);

            //simulacija vrtenja kockica
            //prikazuje kocke(slike) u PictureBox-ovima iz niza tipa Image gdje su smjestene slike na osnovu brojeva iz niza BrojKocke[]
            for (int i = 0; i < 5; i++)
                pictBox5[i].Image = image6[niz[i]];
        }


        public void ZavrtiKocke(Button dugme, Timer timer)
        {
            if (startStop)
            {
                startStop = false;
                dugme.Text = "Stop";
                timer.Start();
            }
            else
            {
                startStop = true;
                dugme.Text = "Start";
                timer.Stop();

                brojacRunde++;
            }

            if (brojacRunde == 5)
            {
                dugme.Text = "Kraj";
                dugme.Enabled = false;
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();

            if (textBoxCrveni.Text == "Ime Crveni")
            {
                IspisiGresku(errorProvider, textBoxCrveni, "Unesite ime Crvenog igrača", 5);
            }
            else if (textBoxPlavi.Text == "Ime Plavi")
            {
                IspisiGresku(errorProvider, textBoxPlavi, "Unesite ime Plavog igrača", 5);
            }
            else if (String.IsNullOrWhiteSpace(textBoxBrRundi.Text) || textBoxBrRundi.Text == "0")
            {
                IspisiGresku(errorProvider, textBoxBrRundi, "Unesite broj rundi", 5);
            }
            else
            {
                imeCrveni = textBoxCrveni.Text;
                imePlavi = textBoxPlavi.Text;
                brRundi = Convert.ToInt32(textBoxBrRundi.Text);

                Tabla formTabla = new Tabla();
                this.Hide();
                formTabla.Show();
            }
        }

        private void IspisiGresku(ErrorProvider errorProv, TextBox textBox, String poruka, int padding)
        {
            errorProv.SetError(textBox, poruka);
            errorProv.SetIconPadding(textBox, padding);
        }

        private void textBoxBrRundi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void Igrac_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
