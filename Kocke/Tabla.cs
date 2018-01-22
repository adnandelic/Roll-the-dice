using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace Kocke
{
    public partial class Tabla : Form
    {
        public Tabla()
        {
            InitializeComponent();
        }

        Igrac plavi, crveni;

        PictureBox[] panelSlCrveni;
        PictureBox[] panelSlPlavi;

        PictureBox[] slikeCrveni5;
        PictureBox[] slikePlavi5;

        Image[] kockeSlCrveni;
        Image[] kockeSlPlavi;

        Bitmap[] slikeCrveni = new Bitmap[7] { Properties.Resources.kocka_c0, Properties.Resources.kocka_c1, Properties.Resources.kocka_c2, 
        Properties.Resources.kocka_c3, Properties.Resources.kocka_c4, Properties.Resources.kocka_c5, Properties.Resources.kocka_c6 };

        Bitmap[] slikePlavi = new Bitmap[7] { Properties.Resources.kocka_p0, Properties.Resources.kocka_p1, Properties.Resources.kocka_p2, 
        Properties.Resources.kocka_p3, Properties.Resources.kocka_p4, Properties.Resources.kocka_p5, Properties.Resources.kocka_p6 };

        Bitmap[] pobjednikCrveni = new Bitmap[9] { Properties.Resources.cr1, Properties.Resources.cr2, Properties.Resources.cr3, 
        Properties.Resources.cr4, Properties.Resources.cr5, Properties.Resources.cr6, Properties.Resources.cr7, Properties.Resources.cr8, 
        Properties.Resources.cr9};

        Bitmap[] pobjednikPlavi = new Bitmap[9] { Properties.Resources.pl1, Properties.Resources.pl2, Properties.Resources.pl3, 
        Properties.Resources.pl4, Properties.Resources.pl5, Properties.Resources.pl6, Properties.Resources.pl7, Properties.Resources.pl8, 
        Properties.Resources.pl9};

        Label[] labeleSC;
        Label[] labeleSP;

        int[] pobjednik;

        int krajIgre;

        private void Tabla_Load(object sender, EventArgs e)
        {
            crveni = new Igrac();
            plavi = new Igrac();

            krajIgre = crveni.BrojRundi;

            PostaviImenaIgraca(crveni.ImeCrveni, plavi.ImePlavi);

            kockeSlCrveni = new Image[7];
            kockeSlPlavi = new Image[7];

            // postavljanje slika u Image niz
            for (int i = 0; i < kockeSlCrveni.Length; i++)
            {
                kockeSlCrveni[i] = slikeCrveni[i];
                kockeSlPlavi[i] = slikePlavi[i];
            }

            pobjednik = new int[9] { 20, 21, 22, 17, 12, 7, 2, 3, 4 };

            // labele za sume po rundama
            labeleSC = new Label[5] { labelSc1, labelSc2, labelSc3, labelSc4, labelSc5 };
            labeleSP = new Label[5] { labelSp1, labelSp2, labelSp3, labelSp4, labelSp5 };

            slikeCrveni5 = new PictureBox[5] { pictureBoxKocka_c1, pictureBoxKocka_c2, pictureBoxKocka_c3, 
            pictureBoxKocka_c4, pictureBoxKocka_c5 };

            slikePlavi5 = new PictureBox[5] { pictureBoxKocka_p1, pictureBoxKocka_p2, pictureBoxKocka_p3, 
            pictureBoxKocka_p4, pictureBoxKocka_p5 };

            //startna pozicija pictureBox-a u panelu
            int x = 5;
            int y = 5;

            panelSlCrveni = new PictureBox[25];
            panelSlPlavi = new PictureBox[25];

            //dinamicki postavljanje pictureBox-ova na formu u panel
            for (int i = 0; i <= 24; i++)
            {
                panelSlCrveni[i] = new PictureBox();
                panelSlCrveni[i].Size = new Size(40, 40);
                panelSlCrveni[i].Image = Properties.Resources.kocka_c0;
                panelSlCrveni[i].SizeMode = PictureBoxSizeMode.StretchImage;
                panelSlCrveni[i].Location = new Point(x, y);

                panelSlPlavi[i] = new PictureBox();
                panelSlPlavi[i].Size = new Size(40, 40);
                panelSlPlavi[i].Image = Properties.Resources.kocka_p0;
                panelSlPlavi[i].SizeMode = PictureBoxSizeMode.StretchImage;
                panelSlPlavi[i].Location = new Point(x, y);

                x += 40 + 3;

                if (i == 4 || i == 9 || i == 14 || i == 19)
                {
                    x = 5;
                    y += 40 + 3;
                }

                this.panel1.Controls.Add(panelSlCrveni[i]);
                this.panel2.Controls.Add(panelSlPlavi[i]);
            }
        }

        private bool ProvjeraZaResetRunde()
        {
            if (crveni.BrojacRunde == 5 && plavi.BrojacRunde == 5)
            {
                if (crveni.UkupnaSuma > plavi.UkupnaSuma)
                {
                    crveni.Pobjeda++;
                    labelPobjedaCr.Text = crveni.Pobjeda.ToString();
                }

                if (crveni.Pobjeda == krajIgre)
                {
                    SimulacijaPobjednik(panelSlCrveni, pobjednikPlavi, pobjednik);

                    labelPobjedaCr.Text = crveni.Pobjeda.ToString();
                }

                if (plavi.UkupnaSuma > crveni.UkupnaSuma)
                {
                    plavi.Pobjeda++;
                    labelPobjedaPl.Text = plavi.Pobjeda.ToString();
                }
                if (plavi.Pobjeda == krajIgre)
                {
                    SimulacijaPobjednik(panelSlPlavi, pobjednikCrveni, pobjednik);

                    labelPobjedaPl.Text = plavi.Pobjeda.ToString();
                }

                return true;
            }
            return false;
        }

        private void buttonZavrtiCrveni_Click(object sender, EventArgs e)
        {
            if (!crveni.StartStop)
                FormirajPanel(crveni, crveni.BrojKocke, crveni.BrojacSR, panelSlCrveni, kockeSlCrveni, labeleSC, labelSumaTotalCr);

            crveni.ZavrtiKocke(buttonZavrtiCrveni, timerSimulacijaCrveni);

            if (ProvjeraZaResetRunde())
                pictureBoxReset.Visible = true;
        }

        private void buttonZavrtiPlavi_Click(object sender, EventArgs e)
        {
            if (!plavi.StartStop)
                FormirajPanel(plavi, plavi.BrojKocke, plavi.BrojacSR, panelSlPlavi, kockeSlPlavi, labeleSP, labelSumaTotalPl);

            plavi.ZavrtiKocke(buttonZavrtiPlavi, timerSimulacijaPlavi);
            
            if (ProvjeraZaResetRunde())
                pictureBoxReset.Visible = true;
        }

        //simulacija vrtenja crvenih kocki
        private void timerSimulacijaCrveni_Tick(object sender, EventArgs e)
        {
            crveni.SimulacijaVrtenja(crveni.BrojKocke, slikeCrveni5, kockeSlCrveni);
        }

        //simulacija vrtenja plavih kocki
        private void timerSimulacijaPlavi_Tick(object sender, EventArgs e)
        {
            plavi.SimulacijaVrtenja(plavi.BrojKocke, slikePlavi5, kockeSlPlavi);
        }

        private void FormirajPanel(Igrac igrac, int[] niz, int brojacSR, PictureBox[] panelSl, Image[] kockeSl, Label[] labeleS, Label total)
        {
            int j = 0;
            for (int i = igrac.KorakRunde; i <= 24; i++)
            {
                panelSl[igrac.KorakRunde].Image = kockeSl[niz[j]];
                igrac.SumaRunde += niz[j];

                if (igrac.KorakRunde == 4 || igrac.KorakRunde == 9 || igrac.KorakRunde == 14 || igrac.KorakRunde == 19 || igrac.KorakRunde == 24)
                {
                    igrac.KorakRunde++;
                    igrac.UkupnaSuma += igrac.SumaRunde;
                    labeleS[igrac.BrojacSR].Text = igrac.SumaRunde.ToString();
                    labeleS[igrac.BrojacSR].Visible = true;
                    total.Text = igrac.UkupnaSuma.ToString();
                    igrac.BrojacSR++;
                    igrac.SumaRunde = 0;
                    break;
                }

                igrac.KorakRunde++;
                j++;
            }
        }

        private void RestujPanel(PictureBox[] niz25, PictureBox[] niz5, char boja)
        {
            for (int i = 0; i < 25; i++)
            {
                if (boja == 'c')
                    niz25[i].Image = Properties.Resources.kocka_c0;
                if (boja == 'p')
                    niz25[i].Image = Properties.Resources.kocka_p0;
            }

            for (int i = 0; i <= 4; i++)
            {
                if (boja == 'c')
                {
                    niz5[i].Image = Properties.Resources.kocka_c0;
                    labeleSC[i].Visible = false;
                }
                if (boja == 'p')
                {
                    niz5[i].Image = Properties.Resources.kocka_p0;
                    labeleSP[i].Visible = false;
                }
            }

            buttonZavrtiCrveni.Text = "Start";
            buttonZavrtiCrveni.Enabled = true;

            buttonZavrtiPlavi.Text = "Start";
            buttonZavrtiPlavi.Enabled = true;

            labelSumaTotalCr.Text = "0";
            crveni.UkupnaSuma = 0;
            crveni.SumaRunde = 0;
            crveni.KorakRunde = 0;
            crveni.BrojacRunde = 0;
            crveni.BrojacSR = 0;

            labelSumaTotalPl.Text = "0";
            plavi.UkupnaSuma = 0;
            plavi.SumaRunde = 0;
            plavi.KorakRunde = 0;
            plavi.BrojacRunde = 0;
            plavi.BrojacSR = 0;

            if (krajIgre == crveni.Pobjeda || krajIgre == plavi.Pobjeda)
            {
                crveni.Pobjeda = 0;
                plavi.Pobjeda = 0;
                labelPobjedaCr.Text = "0";
                labelPobjedaPl.Text = "0";
            }

            pictureBoxReset.Visible = false;
        }

        private void pictureBoxReset_Click(object sender, EventArgs e)
        {
            RestujPanel(panelSlCrveni, slikeCrveni5, 'c');
            RestujPanel(panelSlPlavi, slikePlavi5, 'p');
        }

        private void pictureBoxReset_MouseHover(object sender, EventArgs e)
        {
            pictureBoxReset.Image = Properties.Resources.reset2;
            pictureBoxReset.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBoxReset_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxReset.Image = Properties.Resources.reset1;
            pictureBoxReset.BorderStyle = BorderStyle.None;
        }

        private void PostaviImenaIgraca(string imeCr, string imePl)
        {
            for (int i = 0; i < imeCr.Length; i++)
            {
                labelImeCr.Text += imeCr[i].ToString().ToUpper() + "\n";
            }

            for (int i = 0; i < imePl.Length; i++)
            {
                labelImePl.Text += imePl[i].ToString().ToUpper() + "\n";
            }
        }

        private void SimulacijaPobjednik(PictureBox[] box, Bitmap[] bmap, int[] niz)
        {
            for (int i = 0; i < 9; i++)
            {
                box[niz[i]].Image = bmap[i];
                Application.DoEvents();
                Thread.Sleep(120);
            }
        }

        private void Tabla_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}