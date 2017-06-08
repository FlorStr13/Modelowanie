using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaiwnyRozrostZiaren
{
    class Rekrystalizacja:Plansza
    {
        double A;
        double B;
        double time;
        double deltaP;
        double p;
        double pk_1;
        const int k = 10;
        double pKrytyczne;
        List<Ziarno> naBrzegu;
        private static readonly Random rand = new Random();
        public Rekrystalizacja()
        {
            A = 86710969050178.5;
            B= 9.41268203527779;          
            naBrzegu = new List<Ziarno>();
        }

        public void pobierzZiarna(Rozrost rozrost)
        {
            this.ziarna=rozrost.getZiarna();
            this.ziarnaPoKroku = rozrost.getZiarnaPoKroku();
            this.rozmiar_x = rozrost.getRozmiar_x();
            this.rozmiar_y = rozrost.getRozmiar_y();
            this.pKrytyczne = 4215840142323.42 / (this.rozmiar_x * this.rozmiar_y);
            this.zabijZiarna();
            time = 0.001;
            deltaP = 0;
            p = 0;
            pk_1 = 0;
        }

        public void rekrystalizuj()
        {
            this.czyMaSasiadow();
            this.p = this.obliczP();
            this.deltaP = this.p - this.pk_1;
            nadajPZiarna();
            startRekrystalizacji();
            time += 0.001;
            this.krokCzasowy();
        }

        void czyMaSasiadow()
        {
            this.naBrzegu.Clear();
            for (int i = 0; i < this.rozmiar_x; i++)
            {
                for (int j = 0; j < rozmiar_y; j++)
                {
                    if (policzSasiadowZiarna(i, j) != 0)
                    {
                        this.ziarna[i, j].setSasiedzi(true);
                        this.naBrzegu.Add(ziarna[i, j]);
                    }
                }
            }
        }
        int policzSasiadowZiarna(int x, int y)
        {
            int ilesasiadow = 0;
            //lewo
            if ((x - 1) >= 0)
            {
                if (ziarna[x - 1, y].getId() != ziarna[x, y].getId())
                {
                    ilesasiadow++;
                }
            }
            //prawo
            if ((x + 1) < rozmiar_x)
            {
                if (ziarna[x + 1, y].getId() != ziarna[x, y].getId())
                {
                    ilesasiadow++;
                }
            }

            //gora
            if ((y - 1) >= 0)
            {
                if (ziarna[x, y - 1].getId() != ziarna[x, y].getId())
                {
                    ilesasiadow++;
                }
            }

            //dol
            if ((y + 1) < rozmiar_y)
            {
                if (ziarna[x, y + 1].getId() != ziarna[x, y].getId())
                {
                    ilesasiadow++;
                }
            }

            //lewodol
            if (((x - 1) >= 0) && ((y + 1) < rozmiar_y))
            {
                if (ziarna[x - 1, y + 1].getId() != ziarna[x, y].getId())
                {
                    ilesasiadow++;
                }
            }

            //goraprawo
            if (((x + 1) < rozmiar_x) && ((y - 1) >= 0))
            {
                if (ziarna[x + 1, y - 1].getId() != ziarna[x, y].getId())
                {
                    ilesasiadow++;
                }
            }

            //prawydol
            if (((x + 1) < rozmiar_x) && ((y + 1) < rozmiar_y))
            {
                if (ziarna[x + 1, y + 1].getId() != ziarna[x, y].getId())
                {
                    ilesasiadow++;
                }
            }

            //lewogora
            if (((y - 1) >= 0) && ((x - 1) >= 0))
            {
                if (ziarna[x - 1, y - 1].getId() != ziarna[x, y].getId())
                {
                    ilesasiadow++;
                }
            }
            return ilesasiadow;
        }
        double obliczP()
        {
            return (A / B) + (1 - (A / B)) * Math.Pow(Math.E, -B * time);
        }

        void nadajPZiarna()
        {
            /*System.Console.Write("Delta: ");
            System.Console.Write(deltaP);*/
            double pKomurki = this.deltaP / (this.rozmiar_y * this.rozmiar_x);
            for(int i=0;i<this.rozmiar_x;i++)
            {
                for(int j=0;j<this.rozmiar_y;j++)
                {
                    if(ziarna[i,j].getSasiedzi())
                    {
                        ziarna[i, j].addP((0.8*pKomurki));
                        this.deltaP -= 0.8 * pKomurki;
                    }
                    else
                    {
                        ziarna[i, j].addP((0.2 * pKomurki));
                        this.deltaP -= 0.2 * pKomurki;
                    }
                }
            }
            double ile = deltaP / k;
            /*System.Console.Write("ile: ");
            System.Console.WriteLine(ile);*/
            while(deltaP>0)
            {
                int n = rand.Next(naBrzegu.Count());
                naBrzegu[n].addP(ile);
                deltaP-=ile;
            }
        }

        void startRekrystalizacji()
        {
            for (int i = 0; i < this.rozmiar_x; i++)
            {
                for (int j = 0; j < this.rozmiar_y; j++)
                {
                    if ((ziarna[i, j].getP()>this.pKrytyczne) && ziarna[i,j].death == true)
                    {
                        ziarna[i, j] = new Ziarno();
                        ziarna[i, j].ozyw();
                        ziarna[i, j].setP(0.1);
                        this.ziarnaPoKroku[i, j].copy(ziarna[i, j]);
                    }
                }
            }
        }
        void zabijZiarna()
        {
            for (int i = 0; i < this.rozmiar_x; i++)
            {
                for (int j = 0; j < this.rozmiar_y; j++)
                {
                    this.ziarna[i, j].kill();
                    this.ziarnaPoKroku[i, j].kill();
                    this.ziarna[i, j].setP(0);
                    this.ziarnaPoKroku[i, j].setP(0);
                }
            }
        }
    }
}
