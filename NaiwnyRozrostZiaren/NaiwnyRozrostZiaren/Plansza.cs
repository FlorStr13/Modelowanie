using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaiwnyRozrostZiaren
{
    class Plansza
    {
        Ziarno[,] ziarna;
        Ziarno[,] ziarnaPoKroku;
        int rozmiar_x;
        int rozmiar_y;
        //oznacza jakie sasiedstwo robic
        int sasiedstwo;
        //do warunkow
        bool periodyczne;
        //potrzebne do hex rand zeby raz bylo prawe raz lewe
        static int nrKroku = 0;
        //do pen rand zeby zawsze byl random
        private static readonly Random rand = new Random();

        public Plansza(int x)
        {
            rozmiar_x=x;
            rozmiar_y=x;
            ziarna = new Ziarno[rozmiar_x, rozmiar_y];
            ziarnaPoKroku = new Ziarno[rozmiar_x, rozmiar_y];
            for (int i = 0; i < this.rozmiar_x; i++)
            {
                for (int j = 0; j < this.rozmiar_y; j++)
                {
                    ziarna[i, j] = new Ziarno();
                    ziarnaPoKroku[i, j] = new Ziarno();
                }
            }           
        }

        public void setSasiedstwo(int s)
        {
            this.sasiedstwo = s;
        }
        public void setBrzegowe(bool war)
        {
            this.periodyczne = war;
        }
        void przepisz()
        {
            for (int i = 0; i < this.rozmiar_x; i++)
            {
                for (int j = 0; j < this.rozmiar_y; j++)
                {
                    ziarnaPoKroku[i, j].copy(ziarna[i, j]);
                }
            }
        }

        //wyswietlanie wziete z gry w zycie
        public Bitmap wyswietl()
        {
            Bitmap map = new Bitmap(rozmiar_x, rozmiar_y);
            for (int i = 0; i < this.rozmiar_x; i++)
            {
                for (int j = 0; j < this.rozmiar_y; j++)
                {
                    if (this.ziarna[i, j].death == false)
                    {
                        map.SetPixel(i, j, this.ziarna[i, j].color);
                    }
                   
                }
            }
            return zmien(map);
        }

        Bitmap zmien(Bitmap stara)
        {
            Bitmap nowa = new Bitmap(500, 500);
            int x = nowa.Height / stara.Height;
            int y = nowa.Width / stara.Width;
            for (int i = 0; i < this.rozmiar_x; i++)
            {
                for (int j =0; j < this.rozmiar_y; j++)
                {
                    if (this.ziarna[i, j].death == false)
                    {
                        for (int k = 0; k < x; k++)
                        {
                            for (int l = 0; l < y; l++)
                            {                              
                                    nowa.SetPixel((i * x + k), (j * y + l), this.ziarna[i, j].color);
                            }

                        }
                    }
                }
            }
            return nowa;
        }
        //koniec wyswietlania to trzeba przerobic zeby tylko 1 Bitmapa byla
        
       
        public void krokCzasowy()
        {
            for (int i = 0; i < this.rozmiar_x; i++)
            {
                for (int j = 0; j < this.rozmiar_y; j++)
                {
                    if (ziarna[i,j].death==false)
                    {
                        switch(this.sasiedstwo)
                        {
                            case 0:
                                sasiedzstwoVonNeumann(i, j);
                                break;
                            case 1:
                                sasiedstwoMoore(i, j);
                                break;
                            case 2:
                                sasiedzstwoHexagonalLeft(i, j);
                                break;
                            case 3:             
                                sasiedzstwoHexagonalRigth(i, j);
                                break;
                            case 4:
                                sasiedzstwoHexagonalRand(i, j);
                                break;
                            case 5:
                                sasiedstwoPentagonalRand(i, j);
                                break;

                        }
                        //sasiedstwoMoore(i, j);
                        //sasiedzstwoVonNeumann(i, j);
                        //sasiedzstwoHexagonalRigth(i, j);
                        //sasiedzstwoHexagonalLeft(i, j);
                        //sasiedzstwoHexagonalRand(i, j);
                        //sasiedstwoPentagonalRand(i, j);
                    }
                    
                }
            }
            for (int i = 0; i < this.rozmiar_x; i++)
            {
                for (int j = 0; j < this.rozmiar_y; j++)
                {
                    ziarna[i, j].copy(ziarnaPoKroku[i, j]);
                }
            }
            nrKroku++;
        }

        //przeliczanie wspolrzednych
        public void ozywPoKliku(Point cord)
        {
            double px = 500.0 / cord.X;
            double py = 500.0 / cord.Y;          
            int xx = (int)(rozmiar_x / px);
            int yy = (int)(rozmiar_y / py);
            if (ziarna[xx, yy].death==true)
            {
                ziarna[xx, yy].ozyw();
                ziarnaPoKroku[xx, yy].copy(ziarna[xx, yy]);
            }
            
        }
        //SASIEDSTWA!!!
        //sasiedztow na 8
        void sasiedstwoMoore(int x,int y)
        {
            //lewo
            if ((x - 1) >= 0)
            {
                if (ziarna[x - 1, y].death == true)
                {
                    ziarnaPoKroku[x - 1, y].copy(ziarna[x, y]);
                }
            }
            else
            {
                if ((ziarna[this.rozmiar_x-1, y].death == true)&&this.periodyczne)
                {
                    ziarnaPoKroku[this.rozmiar_x-1, y].copy(ziarna[x, y]);
                }
            }
            //prawo
            if ((x + 1) < rozmiar_x)
            {
                if (ziarna[x + 1, y].death == true)
                {
                    ziarnaPoKroku[x + 1, y].copy(ziarna[x, y]);
                }
            }
            else
            {
                if ((ziarna[0, y].death == true) && this.periodyczne)
                {
                    ziarnaPoKroku[0, y].copy(ziarna[x, y]);
                }
            }
            //gora
            if ((y - 1) >= 0)
            {
                if (ziarna[x, y - 1].death == true)
                {
                    ziarnaPoKroku[x, y - 1].copy(ziarna[x, y]);
                }
            }
            else
            {
                if ((ziarna[x, this.rozmiar_y-1].death == true)&&this.periodyczne)
                {
                    ziarnaPoKroku[x, this.rozmiar_y - 1].copy(ziarna[x, y]);
                }
            }
            //dol
            if ((y + 1) < rozmiar_y)
            {
                if (ziarna[x, y + 1].death == true)
                {
                    ziarnaPoKroku[x, y + 1].copy(ziarna[x, y]);
                }
            }
            else
            {
                if ((ziarna[x, 0].death == true)&&this.periodyczne)
                {
                    ziarnaPoKroku[x, 0].copy(ziarna[x, y]);
                }
            }
            //lewodol
            if (((x - 1) >= 0) && ((y + 1) < rozmiar_y))
            {
                if (ziarna[x - 1, y + 1].death == true)
                {
                    ziarnaPoKroku[x - 1, y + 1].copy(ziarna[x, y]);
                }
            }
            else
            {
                if ((ziarna[0, this.rozmiar_y-1].death == true) && this.periodyczne)
                {
                    ziarnaPoKroku[0, this.rozmiar_y - 1].copy(ziarna[x, y]);
                }
            }
            //goraprawo
            if (((x + 1) < rozmiar_x) && ((y - 1) >= 0))
            {
                if (ziarna[x + 1, y - 1].death == true)
                {
                    ziarnaPoKroku[x + 1, y - 1].copy(ziarna[x, y]);
                }
            }
            else
            {
                if ((ziarna[this.rozmiar_x-1, 0].death == true) && this.periodyczne)
                {
                    ziarnaPoKroku[this.rozmiar_x - 1, 0].copy(ziarna[x, y]);
                }
            }
            //prawydol
            if (((x + 1) < rozmiar_x) && ((y + 1) < rozmiar_y))
            {
                if (ziarna[x + 1, y + 1].death == true)
                {
                    ziarnaPoKroku[x + 1, y + 1].copy(ziarna[x, y]);
                }
            }
            else
            {
                if ((ziarna[0, 0].death == true) && this.periodyczne)
                {
                    ziarnaPoKroku[0, 0].copy(ziarna[x, y]);
                }
            }
            //lewogora
            if (((y - 1) >= 0) && ((x - 1) >= 0))
            {
                if (ziarna[x - 1, y - 1].death == true)
                {
                    ziarnaPoKroku[x - 1, y - 1].copy(ziarna[x, y]);
                }
            }
            else
            {
                if ((ziarna[this.rozmiar_x - 1,this.rozmiar_y-1].death == true) && this.periodyczne)
                {
                    ziarnaPoKroku[this.rozmiar_x - 1, this.rozmiar_y - 1].copy(ziarna[x, y]);
                }
            }
        
        }
        //sasiedztow na 4
        void sasiedzstwoVonNeumann(int x,int y)
        {
            //lewo
            if ((x - 1) >= 0)
            {
                if (ziarna[x - 1, y].death == true)
                {
                    ziarnaPoKroku[x - 1, y].copy(ziarna[x, y]);
                }
            }
            else
            {
                if ((ziarna[this.rozmiar_x - 1, y].death == true) && this.periodyczne)
                {
                    ziarnaPoKroku[this.rozmiar_x - 1, y].copy(ziarna[x, y]);
                }
            }
            //prawo
            if ((x + 1) < rozmiar_x)
            {
                if (ziarna[x + 1, y].death == true)
                {
                    ziarnaPoKroku[x + 1, y].copy(ziarna[x, y]);
                }
            }
            else
            {
                if ((ziarna[0, y].death == true) && this.periodyczne)
                {
                    ziarnaPoKroku[0, y].copy(ziarna[x, y]);
                }
            }
            //gora
            if ((y - 1) >= 0)
            {
                if (ziarna[x, y - 1].death == true)
                {
                    ziarnaPoKroku[x, y - 1].copy(ziarna[x, y]);
                }
            }
            else
            {
                if ((ziarna[x, this.rozmiar_y - 1].death == true) && this.periodyczne)
                {
                    ziarnaPoKroku[x, this.rozmiar_y - 1].copy(ziarna[x, y]);
                }
            }
            //dol
            if ((y + 1) < rozmiar_y)
            {
                if (ziarna[x, y + 1].death == true)
                {
                    ziarnaPoKroku[x, y + 1].copy(ziarna[x, y]);
                }
            }
            else
            {
                if ((ziarna[x, 0].death == true) && this.periodyczne)
                {
                    ziarnaPoKroku[x, 0].copy(ziarna[x, y]);
                }
            }
        }
        //sasiedstwo heksagonalne prawe
        void sasiedzstwoHexagonalRigth(int x, int y)
        {
            //lewo
            if ((x - 1) >= 0)
            {
                if (ziarna[x - 1, y].death == true)
                {
                    ziarnaPoKroku[x - 1, y].copy(ziarna[x, y]);
                }
            }
            else
            {
                if ((ziarna[this.rozmiar_x - 1, y].death == true) && this.periodyczne)
                {
                    ziarnaPoKroku[this.rozmiar_x - 1, y].copy(ziarna[x, y]);
                }
            }
            //prawo
            if ((x + 1) < rozmiar_x)
            {
                if (ziarna[x + 1, y].death == true)
                {
                    ziarnaPoKroku[x + 1, y].copy(ziarna[x, y]);
                }
            }
            else
            {
                if ((ziarna[0, y].death == true) && this.periodyczne)
                {
                    ziarnaPoKroku[0, y].copy(ziarna[x, y]);
                }
            }
            //gora
            if ((y - 1) >= 0)
            {
                if (ziarna[x, y - 1].death == true)
                {
                    ziarnaPoKroku[x, y - 1].copy(ziarna[x, y]);
                }
            }
            else
            {
                if ((ziarna[x, this.rozmiar_y - 1].death == true) && this.periodyczne)
                {
                    ziarnaPoKroku[x, this.rozmiar_y - 1].copy(ziarna[x, y]);
                }
            }
            //dol
            if ((y + 1) < rozmiar_y)
            {
                if (ziarna[x, y + 1].death == true)
                {
                    ziarnaPoKroku[x, y + 1].copy(ziarna[x, y]);
                }
            }
            else
            {
                if ((ziarna[x, 0].death == true) && this.periodyczne)
                {
                    ziarnaPoKroku[x, 0].copy(ziarna[x, y]);
                }
            }
            //lewodol
            if (((x - 1) >= 0) && ((y + 1) < rozmiar_y))
            {
                if (ziarna[x - 1, y + 1].death == true)
                {
                    ziarnaPoKroku[x - 1, y + 1].copy(ziarna[x, y]);
                }
            }
            else
            {
                if ((ziarna[0, this.rozmiar_y - 1].death == true) && this.periodyczne)
                {
                    ziarnaPoKroku[0, this.rozmiar_y - 1].copy(ziarna[x, y]);
                }
            }
            //goraprawo
            if (((x + 1) < rozmiar_x) && ((y - 1) >= 0))
            {
                if (ziarna[x + 1, y - 1].death == true)
                {
                    ziarnaPoKroku[x + 1, y - 1].copy(ziarna[x, y]);
                }
            }
            else
            {
                if ((ziarna[this.rozmiar_x - 1, 0].death == true) && this.periodyczne)
                {
                    ziarnaPoKroku[this.rozmiar_x - 1, 0].copy(ziarna[x, y]);
                }
            }
        }
        //sasiedstwo heksagonalne lewe
        void sasiedzstwoHexagonalLeft(int x, int y)
        {
            //lewo
            if ((x - 1) >= 0)
            {
                if (ziarna[x - 1, y].death == true)
                {
                    ziarnaPoKroku[x - 1, y].copy(ziarna[x, y]);
                }
            }
            else
            {
                if ((ziarna[this.rozmiar_x - 1, y].death == true) && this.periodyczne)
                {
                    ziarnaPoKroku[this.rozmiar_x - 1, y].copy(ziarna[x, y]);
                }
            }
            //prawo
            if ((x + 1) < rozmiar_x)
            {
                if (ziarna[x + 1, y].death == true)
                {
                    ziarnaPoKroku[x + 1, y].copy(ziarna[x, y]);
                }
            }
            else
            {
                if ((ziarna[0, y].death == true) && this.periodyczne)
                {
                    ziarnaPoKroku[0, y].copy(ziarna[x, y]);
                }
            }
            //gora
            if ((y - 1) >= 0)
            {
                if (ziarna[x, y - 1].death == true)
                {
                    ziarnaPoKroku[x, y - 1].copy(ziarna[x, y]);
                }
            }
            else
            {
                if ((ziarna[x, this.rozmiar_y - 1].death == true) && this.periodyczne)
                {
                    ziarnaPoKroku[x, this.rozmiar_y - 1].copy(ziarna[x, y]);
                }
            }
            //dol
            if ((y + 1) < rozmiar_y)
            {
                if (ziarna[x, y + 1].death == true)
                {
                    ziarnaPoKroku[x, y + 1].copy(ziarna[x, y]);
                }
            }
            else
            {
                if ((ziarna[x, 0].death == true) && this.periodyczne)
                {
                    ziarnaPoKroku[x, 0].copy(ziarna[x, y]);
                }
            }
            //prawydol
            if (((x + 1) < rozmiar_x) && ((y + 1) < rozmiar_y))
            {
                if (ziarna[x + 1, y + 1].death == true)
                {
                    ziarnaPoKroku[x + 1, y + 1].copy(ziarna[x, y]);
                }
            }
            else
            {
                if ((ziarna[0, 0].death == true) && this.periodyczne)
                {
                    ziarnaPoKroku[0, 0].copy(ziarna[x, y]);
                }
            }
            //lewogora
            if (((y - 1) >= 0) && ((x - 1) >= 0))
            {
                if (ziarna[x - 1, y - 1].death == true)
                {
                    ziarnaPoKroku[x - 1, y - 1].copy(ziarna[x, y]);
                }
            }
            else
            {
                if ((ziarna[this.rozmiar_x - 1, this.rozmiar_y - 1].death == true) && this.periodyczne)
                {
                    ziarnaPoKroku[this.rozmiar_x - 1, this.rozmiar_y - 1].copy(ziarna[x, y]);
                }
            }

        }
        //heksagonalne losowe 
        void sasiedzstwoHexagonalRand(int x,int y)
        {
            if (nrKroku % 2 == 0)
            {
                sasiedzstwoHexagonalRigth(x, y);
                       
            }
            else
            {
                sasiedzstwoHexagonalLeft(x, y);
            }           
        }
        //Pentagonal losowe
        void sasiedstwoPentagonalRand(int x,int y)
        {
            int ktore=rand.Next(1,5);
            switch (ktore)
            {
                case 1:
                    pentagonal1(x, y);
                    break;
                case 2:
                    pentagonal2(x, y);
                    break;
                case 3:
                    pentagonal3(x, y);
                    break;
                case 4:
                    pentagonal4(x, y);
                    break;
            }
            
        }
        void pentagonal1(int x,int y)
        {
            //gora
            if ((y - 1) >= 0)
            {
                if (ziarna[x, y - 1].death == true)
                {
                    ziarnaPoKroku[x, y - 1].copy(ziarna[x, y]);
                }
            }
            else
            {
                if ((ziarna[x, this.rozmiar_y - 1].death == true) && this.periodyczne)
                {
                    ziarnaPoKroku[x, this.rozmiar_y - 1].copy(ziarna[x, y]);
                }
            }
            //dol
            if ((y + 1) < rozmiar_y)
            {
                if (ziarna[x, y + 1].death == true)
                {
                    ziarnaPoKroku[x, y + 1].copy(ziarna[x, y]);
                }
            }
            else
            {
                if ((ziarna[x, 0].death == true) && this.periodyczne)
                {
                    ziarnaPoKroku[x, 0].copy(ziarna[x, y]);
                }
            }
            //lewo
            if ((x - 1) >= 0)
            {
                if (ziarna[x - 1, y].death == true)
                {
                    ziarnaPoKroku[x - 1, y].copy(ziarna[x, y]);
                }
            }
            else
            {
                if ((ziarna[this.rozmiar_x - 1, y].death == true) && this.periodyczne)
                {
                    ziarnaPoKroku[this.rozmiar_x - 1, y].copy(ziarna[x, y]);
                }
            }
            //lewogora
            if (((y - 1) >= 0) && ((x - 1) >= 0))
            {
                if (ziarna[x - 1, y - 1].death == true)
                {
                    ziarnaPoKroku[x - 1, y - 1].copy(ziarna[x, y]);
                }
            }
            else
            {
                if ((ziarna[this.rozmiar_x - 1, this.rozmiar_y - 1].death == true) && this.periodyczne)
                {
                    ziarnaPoKroku[this.rozmiar_x - 1, this.rozmiar_y - 1].copy(ziarna[x, y]);
                }
            }
            //lewodol
            if (((x - 1) >= 0) && ((y + 1) < rozmiar_y))
            {
                if (ziarna[x - 1, y + 1].death == true)
                {
                    ziarnaPoKroku[x - 1, y + 1].copy(ziarna[x, y]);
                }
            }
            else
            {
                if ((ziarna[0, this.rozmiar_y - 1].death == true) && this.periodyczne)
                {
                    ziarnaPoKroku[0, this.rozmiar_y - 1].copy(ziarna[x, y]);
                }
            }
        }
        void pentagonal2(int x, int y)
        {
            //gora
            if ((y - 1) >= 0)
            {
                if (ziarna[x, y - 1].death == true)
                {
                    ziarnaPoKroku[x, y - 1].copy(ziarna[x, y]);
                }
            }
            else
            {
                if ((ziarna[x, this.rozmiar_y - 1].death == true) && this.periodyczne)
                {
                    ziarnaPoKroku[x, this.rozmiar_y - 1].copy(ziarna[x, y]);
                }
            }
            //dol
            if ((y + 1) < rozmiar_y)
            {
                if (ziarna[x, y + 1].death == true)
                {
                    ziarnaPoKroku[x, y + 1].copy(ziarna[x, y]);
                }
            }
            else
            {
                if ((ziarna[x, 0].death == true) && this.periodyczne)
                {
                    ziarnaPoKroku[x, 0].copy(ziarna[x, y]);
                }
            }
            //prawo
            if ((x + 1) < rozmiar_x)
            {
                if (ziarna[x + 1, y].death == true)
                {
                    ziarnaPoKroku[x + 1, y].copy(ziarna[x, y]);
                }
            }
            else
            {
                if ((ziarna[0, y].death == true) && this.periodyczne)
                {
                    ziarnaPoKroku[0, y].copy(ziarna[x, y]);
                }
            }
            //goraprawo
            if (((x + 1) < rozmiar_x) && ((y - 1) >= 0))
            {
                if (ziarna[x + 1, y - 1].death == true)
                {
                    ziarnaPoKroku[x + 1, y - 1].copy(ziarna[x, y]);
                }
            }
            else
            {
                if ((ziarna[this.rozmiar_x - 1, 0].death == true) && this.periodyczne)
                {
                    ziarnaPoKroku[this.rozmiar_x - 1, 0].copy(ziarna[x, y]);
                }
            }
            //prawydol
            if (((x + 1) < rozmiar_x) && ((y + 1) < rozmiar_y))
            {
                if (ziarna[x + 1, y + 1].death == true)
                {
                    ziarnaPoKroku[x + 1, y + 1].copy(ziarna[x, y]);
                }
            }
            else
            {
                if ((ziarna[0, 0].death == true) && this.periodyczne)
                {
                    ziarnaPoKroku[0, 0].copy(ziarna[x, y]);
                }
            }
        }
        void pentagonal3(int x, int y)
        {
            //dol
            if ((y + 1) < rozmiar_y)
            {
                if (ziarna[x, y + 1].death == true)
                {
                    ziarnaPoKroku[x, y + 1].copy(ziarna[x, y]);
                }
            }
            else
            {
                if ((ziarna[x, 0].death == true) && this.periodyczne)
                {
                    ziarnaPoKroku[x, 0].copy(ziarna[x, y]);
                }
            }
            //lewo
            if ((x - 1) >= 0)
            {
                if (ziarna[x - 1, y].death == true)
                {
                    ziarnaPoKroku[x - 1, y].copy(ziarna[x, y]);
                }
            }
            else
            {
                if ((ziarna[this.rozmiar_x - 1, y].death == true) && this.periodyczne)
                {
                    ziarnaPoKroku[this.rozmiar_x - 1, y].copy(ziarna[x, y]);
                }
            }
            //prawo
            if ((x + 1) < rozmiar_x)
            {
                if (ziarna[x + 1, y].death == true)
                {
                    ziarnaPoKroku[x + 1, y].copy(ziarna[x, y]);
                }
            }
            else
            {
                if ((ziarna[0, y].death == true) && this.periodyczne)
                {
                    ziarnaPoKroku[0, y].copy(ziarna[x, y]);
                }
            }
            //prawydol
            if (((x + 1) < rozmiar_x) && ((y + 1) < rozmiar_y))
            {
                if (ziarna[x + 1, y + 1].death == true)
                {
                    ziarnaPoKroku[x + 1, y + 1].copy(ziarna[x, y]);
                }
            }
            else
            {
                if ((ziarna[0, 0].death == true) && this.periodyczne)
                {
                    ziarnaPoKroku[0, 0].copy(ziarna[x, y]);
                }
            }
            //lewodol
            if (((x - 1) >= 0) && ((y + 1) < rozmiar_y))
            {
                if (ziarna[x - 1, y + 1].death == true)
                {
                    ziarnaPoKroku[x - 1, y + 1].copy(ziarna[x, y]);
                }
            }
            else
            {
                if ((ziarna[0, this.rozmiar_y - 1].death == true) && this.periodyczne)
                {
                    ziarnaPoKroku[0, this.rozmiar_y - 1].copy(ziarna[x, y]);
                }
            }
        }
        void pentagonal4(int x, int y)
        {
            //gora
            if ((y - 1) >= 0)
            {
                if (ziarna[x, y - 1].death == true)
                {
                    ziarnaPoKroku[x, y - 1].copy(ziarna[x, y]);
                }
            }
            else
            {
                if ((ziarna[x, this.rozmiar_y - 1].death == true) && this.periodyczne)
                {
                    ziarnaPoKroku[x, this.rozmiar_y - 1].copy(ziarna[x, y]);
                }
            }
            //prawo
            if ((x + 1) < rozmiar_x)
            {
                if (ziarna[x + 1, y].death == true)
                {
                    ziarnaPoKroku[x + 1, y].copy(ziarna[x, y]);
                }
            }
            else
            {
                if ((ziarna[0, y].death == true) && this.periodyczne)
                {
                    ziarnaPoKroku[0, y].copy(ziarna[x, y]);
                }
            }
            //lewo
            if ((x - 1) >= 0)
            {
                if (ziarna[x - 1, y].death == true)
                {
                    ziarnaPoKroku[x - 1, y].copy(ziarna[x, y]);
                }
            }
            else
            {
                if ((ziarna[this.rozmiar_x - 1, y].death == true) && this.periodyczne)
                {
                    ziarnaPoKroku[this.rozmiar_x - 1, y].copy(ziarna[x, y]);
                }
            }
            //goraprawo
            if (((x + 1) < rozmiar_x) && ((y - 1) >= 0))
            {
                if (ziarna[x + 1, y - 1].death == true)
                {
                    ziarnaPoKroku[x + 1, y - 1].copy(ziarna[x, y]);
                }
            }
            else
            {
                if ((ziarna[this.rozmiar_x - 1, 0].death == true) && this.periodyczne)
                {
                    ziarnaPoKroku[this.rozmiar_x - 1, 0].copy(ziarna[x, y]);
                }
            }
            //lewogora
            if (((y - 1) >= 0) && ((x - 1) >= 0))
            {
                if (ziarna[x - 1, y - 1].death == true)
                {
                    ziarnaPoKroku[x - 1, y - 1].copy(ziarna[x, y]);
                }
            }
            else
            {
                if ((ziarna[this.rozmiar_x - 1, this.rozmiar_y - 1].death == true) && this.periodyczne)
                {
                    ziarnaPoKroku[this.rozmiar_x - 1, this.rozmiar_y - 1].copy(ziarna[x, y]);
                }
            }
        }

        //Losowanie zarodkow
        public void wstawLosowo(int n)
        {
            Random rand = new Random();

            for (int i = 0; i < n; )
            {
                int x = rand.Next(1, this.rozmiar_x);
                int y = rand.Next(1, this.rozmiar_y);
                if (ziarna[x,y].death == true)
                {                  
                    this.ziarna[x, y].ozyw();
                    i++;
                }
            }
            przepisz();
        }
        public void wstawLosowoZR(int n,int r)
        {
            Random rand = new Random();
            Point[] tab = new Point[n];
            for (int i = 0; i < n; )
            {
                int x = rand.Next(1, this.rozmiar_x);
                int y = rand.Next(1, this.rozmiar_y);
                tab[i].X = x;
                tab[i].Y = y;
                if (ziarna[x , y].death == true)
                {
                    if (i == 0)
                    {
                        this.ziarna[x, y].ozyw();
                        i++;
                    }
                    else
                    {
                        //jak jest chociaz w jednym kolko to sie nie naryje
                        bool ifpossible = true;
                        for(int j=0;j<i;j++)
                        {                          
                            if ((System.Math.Pow((x - tab[j].X), 2) + System.Math.Pow((y - tab[j].Y), 2)) <= System.Math.Pow(r, 2))
                            {
                                ifpossible = false;
                            }
                        }
                        if (ifpossible==true)
                        {
                            this.ziarna[x, y].ozyw();
                            i++;
                        }
                    }
                }
            }
            przepisz();
        }
        public void wstawRonomiernie(int n)//trzeba podac +1
        {         
            int x =  this.rozmiar_x / n;
            int y = this.rozmiar_y / n;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1; j++)
                {
                    this.ziarna[(x*i)+x, (y*j)+y].ozyw();
                }
            }
            przepisz();
        }
    }
}
