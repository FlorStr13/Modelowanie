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
        Rozrost rozrost;
        Rekrystalizacja rekrystalizacja;
        MonteCarlo monteCarlo;
        public MainForm()
        {
            rozrost = new Rozrost(100);
            //rozrost = new Rozrost(10);
            rekrystalizacja = new Rekrystalizacja();
            monteCarlo = new MonteCarlo();
            InitializeComponent();
        }

        private void wyswietl()
        {
            pictureBox1.Image = rozrost.wyswietl();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            rozrost.krokCzasowy();
            wyswietl();
        }

        private void start_stop_Click(object sender, EventArgs e)
        {
            if(running ==false)
            {
                rozrost.setBrzegowe(this.checkBox1.Checked);
                rozrost.setSasiedstwo(this.comboBox1.SelectedIndex);
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
                   
                    rozrost.wstawLosowo(ile);
                    wyswietl();
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
                    rozrost.wstawLosowoZR(ile, r);
                    wyswietl();
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
                    rozrost.wstawRonomiernie(ile+1);
                    wyswietl();
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
                rozrost.ozywPoKliku(coordinates);
                wyswietl();
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
                    rozrost = new Rozrost(x);
                    rekrystalizacja = new Rekrystalizacja();
                    wyswietl();
                    timer1.Stop();
                    timer2.Stop();
                }
               
            }
            catch (FormatException exp)
            {
                MessageBox.Show("Wielkość musza byc liczbami", "Blad",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            }
        }

        private void rekrystalizacjaButton_Click(object sender, EventArgs e)
        {
           if(rozrost.ifend() && running ==false)
           {
               rekrystalizacja.setBrzegowe(this.checkBox1.Checked);
               rekrystalizacja.setSasiedstwo(this.comboBox1.SelectedIndex);
               rekrystalizacja.pobierzZiarna(rozrost);             
               this.timer2.Start();
               running = true;
               System.Console.Write("dziala");
           }
           else
           {
               this.timer2.Stop();
               running = false;
               System.Console.Write("nie dziala");
           }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.pictureBox1.Image=rekrystalizacja.wyswietl();
            rekrystalizacja.rekrystalizuj();
        }

       

        private void timer3_Tick(object sender, EventArgs e)
        {
            monteCarlo.run();
            wyswietl();
        }

        private void monte_carlo_Click(object sender, EventArgs e)
        {
            if ( running == false)
            {
                monteCarlo.inicjalizuj(rozrost);               
                timer3.Start();
                running = true;
                System.Console.Write("dziala");
            }
            else
            {
                this.timer3.Stop();
                running = false;
                System.Console.Write("nie dziala");
            }
        }

        private void button1_Click(object sender, EventArgs e)
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
                    monteCarlo.inicjalizuj(rozrost);
                    monteCarlo.losujPlansze(ile);
                    wyswietl();
                }

            }
            catch (FormatException exp)
            {
                MessageBox.Show("Ile musza byc liczbami", "Blad",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            }
           
        }



    }
}
