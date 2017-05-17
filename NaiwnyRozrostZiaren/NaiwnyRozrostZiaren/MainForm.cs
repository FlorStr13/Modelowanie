using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NaiwnyRozrostZiaren
{
    public partial class MainForm : Form
    {
        bool running=false;
        Plansza plansza;
        public MainForm()
        {
            plansza = new Plansza(100);
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            plansza.krokCzasowy();
            pictureBox1.Image = plansza.wyswietl();
        }

        private void start_stop_Click(object sender, EventArgs e)
        {
            if(running ==false)
            {
                plansza.setBrzegowe(this.checkBox1.Checked);
                plansza.setSasiedstwo(this.comboBox1.SelectedIndex);
                timer1.Start();
                running = true;
                start_stop.Text = "Stop";
                this.losowoButton.Enabled = false;
                this.rownoButton.Enabled = false;
                this.LosowoRButton.Enabled = false;
            }
            else
            {
                timer1.Stop();
                running = false;
                start_stop.Text = "Start";
                this.losowoButton.Enabled = true;
                this.rownoButton.Enabled = true;
                this.LosowoRButton.Enabled = true;
            }
        }

        private void losowoButton_Click(object sender, EventArgs e)
        {
            try
            {
                
                int ile = int.Parse(this.iloscText.Text);
                
                if (ile <= 0)
                {
                    MessageBox.Show("ile musza wieksze od zera", "Blad",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                }
                else
                {
                   
                    plansza.wstawLosowo(ile);
                    pictureBox1.Image = plansza.wyswietl();
                }
              
            }
            catch (FormatException exp)
            {
                MessageBox.Show("Ile musza byc liczbami", "Blad",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            }
        }

        private void LosowoRButton_Click(object sender, EventArgs e)
        {
            try
            {
                int ile = int.Parse(this.iloscText.Text);
                int r = int.Parse(this.promienText.Text);
                if (ile <= 0 || r<=0)
                {
                    MessageBox.Show("Ile  oraz  r musza wieksze od zera", "Blad",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                }
                else
                {
                    plansza.wstawLosowoZR(ile, r);
                    pictureBox1.Image = plansza.wyswietl();
                }

            }
            catch (FormatException exp)
            {
                MessageBox.Show("Wielkość ile  oraz r musza byc liczbami", "Blad",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            }
        }

        private void RownoButton_Click(object sender, EventArgs e)
        {
            try
            {
                int ile = int.Parse(this.iloscText.Text);

                if ( ile <= 0)
                {
                    MessageBox.Show("Ile musza wieksze od zera", "Blad",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                }
                else
                {
                    plansza.wstawRonomiernie(ile+1);
                    pictureBox1.Image = plansza.wyswietl();
                }

            }
            catch (FormatException exp)
            {
                MessageBox.Show("Ile musza byc liczbami", "Blad",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (this.running == false)
            {
                MouseEventArgs me = (MouseEventArgs)e;
                Point coordinates = me.Location;
                //System.Console.Write(coordinates);
                plansza.ozywPoKliku(coordinates);
                pictureBox1.Image = plansza.wyswietl();
            }
        }

        private void stworzButton_Click(object sender, EventArgs e)
        {
            try
            {
                int x = int.Parse(this.wielkoscText.Text);
                if (x<= 0)
                {
                    MessageBox.Show("Wielkość musza wieksze od zera", "Blad",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                }
                else
                {
                    plansza = new Plansza(x);
                    pictureBox1.Image = plansza.wyswietl();
                }
               
            }
            catch (FormatException exp)
            {
                MessageBox.Show("Wielkość musza byc liczbami", "Blad",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            }
        }

    }
}
