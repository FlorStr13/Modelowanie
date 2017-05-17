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
        int ID;
        public Color color;
        public bool death;
        static int IDall=0;
        private static readonly Random rand = new Random();
        public Ziarno()
        {
            death = true;           
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
        }

        //funkcja do randomowego wybierania kolorow
        Color randColor()
        {
            Color randomColor = Color.FromArgb(rand.Next(256),rand.Next(256),rand.Next(256));
            return randomColor;
        }

    }
}
