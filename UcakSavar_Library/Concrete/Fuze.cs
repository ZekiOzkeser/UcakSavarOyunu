using System;
using System.Drawing;
using UcakSavar_Library.Abstract;

namespace UcakSavar_Library.Concrete
{
    internal class Fuze : Cisim
    {
       
        public int Yon;
        public Fuze(Size alanBoyutlari, int namluX) : base(alanBoyutlari)
        {
            Random rnd = new Random();
            int leftOrRight = rnd.Next(100);
            int yonDeger = rnd.Next(AlanBoyutlari.Width - namluX + 1) - 150;
            if (leftOrRight <= 40)
            {
                Yon = yonDeger * -1;
                
            }
            else if (leftOrRight <= 60)
            {
                Yon = 0;
                
            }
            else
            {
                Yon = yonDeger;
               
            }

            RastgeleKonumAyarla(namluX);
            Mesafe = (int)(Height * 1.5);


        }

        private void RastgeleKonumAyarla(int namluX)
        {
            Top = AlanBoyutlari.Height;
            Center = namluX;
        }


    }
}
