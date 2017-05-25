using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaiwnyRozrostZiaren
{
    class Rozrost:Plansza
    {
 
        
        public Rozrost(int x)
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

       
        public Ziarno[,] getZiarna()
        {
            return this.ziarna;
        }
        public Ziarno[,] getZiarnaPoKroku()
        {
            return this.ziarnaPoKroku;
        }
        public int getRozmiar_x()
        {
            return this.rozmiar_x;
        }
        public int getRozmiar_y()
        {
            return this.rozmiar_y;
        }
        
       
       

        //przeliczanie wspolrzednych
        public void ozywPoKliku(Point cord)
        {
            double px = 500.0 / cord.X;
            double py = 500.0 / cord.Y;          
            int xx = (int)(rozmiar_x / px);
            int yy = (int)(rozmiar_y / py);
            if (!ziarna[xx, yy].ifdeath())
            {
                ziarna[xx, yy].ozyw();
                ziarnaPoKroku[xx, yy].copy(ziarna[xx, yy]);
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
            przepiszZiarnaDoPoKroku();
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
                                break;
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
            przepiszZiarnaDoPoKroku();
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
            przepiszZiarnaDoPoKroku();
        }

        //rekrystalizacje
        public bool ifend()
        { 
            for(int i=0;i<this.rozmiar_x;i++)
            {
                for(int j=0;j<this.rozmiar_y;j++)
                {
                    if(ziarna[i,j].death==true)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
