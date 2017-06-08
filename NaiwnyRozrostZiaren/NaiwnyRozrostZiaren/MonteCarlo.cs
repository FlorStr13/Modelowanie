using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaiwnyRozrostZiaren
{
    class MonteCarlo : Plansza
    {
        public class Dane
        {
            public int ID;
            public Color color;
            public int x{get;set;}
            public int y;
            public Dane(int ID, Color color)
            {
                this.ID = ID;
                this.color=color;
  
            }
            public Dane(int ID,Color color,int x,int y)
            {
                this.ID = ID;
                this.color = color;
                this.x = x;
                this.y = y;
            }
        }
        List<Dane> listaSasiadow;
        List<Dane> naBrzegu;
        public MonteCarlo()
        {
            listaSasiadow= new List<Dane>();
            this.naBrzegu= new List<Dane>();
        }


        public void inicjalizuj(Rozrost rozrost)
        {
            this.ziarna = rozrost.getZiarna();
            this.ziarnaPoKroku = rozrost.getZiarnaPoKroku();
            this.rozmiar_x = rozrost.getRozmiar_x();
            this.rozmiar_y = rozrost.getRozmiar_y();
        }


        public void run()
        {
            dodajNaBrzegu();
            while (naBrzegu.Count != 0)
            {
                int n = rand.Next(naBrzegu.Count);
                int energia1 = obliczEnergie(naBrzegu[n].x, naBrzegu[n].y);
                int StareID = this.ziarna[naBrzegu[n].x, naBrzegu[n].y].getId();
                dodajSasiadow(naBrzegu[n].x, naBrzegu[n].y);
                int i = rand.Next(listaSasiadow.Count);
                if (energia1 != 0)
                {
                    this.ziarna[naBrzegu[n].x, naBrzegu[n].y].setID(listaSasiadow[i].ID);
                    if (obliczEnergie(naBrzegu[n].x, naBrzegu[n].y) > energia1)
                    {
                        this.ziarna[naBrzegu[n].x, naBrzegu[n].y].setID(StareID);
                    }
                    else
                    {
                        this.ziarna[naBrzegu[n].x, naBrzegu[n].y].color = listaSasiadow[i].color;
                    }
                }
                naBrzegu.RemoveAt(n);
            }
        }

        int obliczEnergie(int x,int y)
        {
            int energia = 0;
            if ((x - 1) >= 0)
            {
                if (ziarna[x - 1, y].getId() != ziarna[x, y].getId())
                {
                    energia++;
                }
            }
            //prawo
            if ((x + 1) < rozmiar_x)
            {
                if (ziarna[x + 1, y].getId() != ziarna[x, y].getId())
                {
                    energia++;
                }
            }

            //gora
            if ((y - 1) >= 0)
            {
                if (ziarna[x, y - 1].getId() != ziarna[x, y].getId())
                {
                    energia++;
                }
            }

            //dol
            if ((y + 1) < rozmiar_y)
            {
                if (ziarna[x, y + 1].getId() != ziarna[x, y].getId())
                {
                    energia++;
                }
            }

            //lewodol
            if (((x - 1) >= 0) && ((y + 1) < rozmiar_y))
            {
                if (ziarna[x - 1, y + 1].getId() != ziarna[x, y].getId())
                {
                    energia++;
                }
            }

            //goraprawo
            if (((x + 1) < rozmiar_x) && ((y - 1) >= 0))
            {
                if (ziarna[x + 1, y - 1].getId() != ziarna[x, y].getId())
                {
                    energia++;
                }
            }

            //prawydol
            if (((x + 1) < rozmiar_x) && ((y + 1) < rozmiar_y))
            {
                if (ziarna[x + 1, y + 1].getId() != ziarna[x, y].getId())
                {
                    energia++;
                }
            }

            //lewogora
            if (((y - 1) >= 0) && ((x - 1) >= 0))
            {
                if (ziarna[x - 1, y - 1].getId() != ziarna[x, y].getId())
                {
                    energia++;
                }
            }
            return energia;
        }

        void dodajSasiadow(int x,int  y)
        {
            listaSasiadow.Clear();
            if ((x - 1) >= 0)
            {
                if (ziarna[x - 1, y].getId() != ziarna[x, y].getId())
                {
                    listaSasiadow.Add(new Dane(ziarna[x - 1, y].getId(), ziarna[x - 1, y].color));
                }
            }
            //prawo
            if ((x + 1) < rozmiar_x)
            {
                if (ziarna[x + 1, y].getId() != ziarna[x, y].getId())
                {
                    listaSasiadow.Add(new Dane(ziarna[x + 1, y].getId(), ziarna[x + 1, y].color));
                }
            }

            //gora
            if ((y - 1) >= 0)
            {
                if (ziarna[x, y - 1].getId() != ziarna[x, y].getId())
                {
                    listaSasiadow.Add(new Dane(ziarna[x, y-1].getId(), ziarna[x , y-1].color));
                }
            }

            //dol
            if ((y + 1) < rozmiar_y)
            {
                if (ziarna[x, y + 1].getId() != ziarna[x, y].getId())
                {
                    listaSasiadow.Add(new Dane(ziarna[x , y+1].getId(), ziarna[x, y+1].color));
                }
            }

            //lewodol
            if (((x - 1) >= 0) && ((y + 1) < rozmiar_y))
            {
                if (ziarna[x - 1, y + 1].getId() != ziarna[x, y].getId())
                {
                    listaSasiadow.Add(new Dane(ziarna[x - 1, y+1].getId(), ziarna[x - 1, y+1].color));
                }
            }

            //goraprawo
            if (((x + 1) < rozmiar_x) && ((y - 1) >= 0))
            {
                if (ziarna[x + 1, y - 1].getId() != ziarna[x, y].getId())
                {
                    listaSasiadow.Add(new Dane(ziarna[x + 1, y-1].getId(), ziarna[x + 1, y-1].color));
                }
            }

            //prawydol
            if (((x + 1) < rozmiar_x) && ((y + 1) < rozmiar_y))
            {
                if (ziarna[x + 1, y + 1].getId() != ziarna[x, y].getId())
                {
                    listaSasiadow.Add(new Dane(ziarna[x + 1, y+1].getId(), ziarna[x +1 , y+1].color));
                }
            }

            //lewogora
            if (((y - 1) >= 0) && ((x - 1) >= 0))
            {
                if (ziarna[x - 1, y - 1].getId() != ziarna[x, y].getId())
                {
                    listaSasiadow.Add(new Dane(ziarna[x - 1, y-1].getId(), ziarna[x - 1, y-1].color));
                }
            }

        }

         void dodajNaBrzegu()
        {
            this.naBrzegu.Clear();
            for (int i = 0; i < this.rozmiar_x; i++)
            {
                for (int j = 0; j < rozmiar_y; j++)
                {
                    if (obliczEnergie(i, j) != 0)
                    {
                        this.naBrzegu.Add(new Dane(ziarna[i,j].ID ,ziarna[i,j].color, i,j));
                    }
                }
            }
        }

        public void losujPlansze(int n)
        {
            for (int i=0; i<n;i++)
            {
                naBrzegu.Add(new Dane(i, randColor()));
            }
            for (int i = 0; i < rozmiar_x; i++)
            {
                for (int j = 0; j < rozmiar_y; j++)
                {
                    int m= rand.Next(naBrzegu.Count);
                    this.ziarna[i, j].ID = naBrzegu[m].ID;
                    this.ziarna[i, j].color = naBrzegu[m].color;
                }
            }
        
        
        }
        Color randColor()
        {
            Color randomColor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
            return randomColor;
        }
    }
}
