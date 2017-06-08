using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaiwnyRozrostZiaren
{
    class Ziarno
    {
        public int ID { get; set; }
        public Color color;
        static int IDall=0;
        private static readonly Random rand = new Random();
        //do rozrostu
        public bool death;
        //do rekrystalizacji
        double p;
        bool sasiedzi;

        public Ziarno()
        {
            color = Color.White;
            sasiedzi = false;
            death = true;
            p = 0;
        }

        public void ozyw()
        {
            this.ID = IDall++;
            this.death = false;
            this.color = randColor();
        }


        public void  copy(Ziarno kiopiowane)
        {
            this.ID = kiopiowane.ID;
            this.death = kiopiowane.death;
            this.color = kiopiowane.color;
            this.p = kiopiowane.p;
        }

        //funkcja do randomowego wybierania kolorow
        Color randColor()
        {
            Color randomColor = Color.FromArgb(rand.Next(256),rand.Next(256),rand.Next(256));
            return randomColor;
        }

        public bool ifdeath()
        {
            if (this.death==false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public double getP()
        {
            return this.p;
        }
        public void setP(double p)
        {
            this.p = p;
        }
        public void addP(double p)
        {
            this.p += p;
        }
        public bool getSasiedzi()
        {
            return this.sasiedzi;
        }
        public void setSasiedzi(bool sasiedzi)
        {
            this.sasiedzi = sasiedzi;
        }
        public int getId()
        {
            return this.ID;
        }
        public void kill()
        {
            this.death = true;
        }

        public void setID(int id)
        {
            this.ID = id;
        }
    }
}
