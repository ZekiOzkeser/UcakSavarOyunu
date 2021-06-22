using System;
using System.Drawing;
using UcakSavar_Library.Abstract;

namespace UcakSavar_Library.Concrete
{
    internal class Fuze : Cisim
    {
        private static readonly Random Random = new Random();
        public int Yon;
        public Fuze(Size alanBoyutlari, int namluX) : base(alanBoyutlari)
        {
            int leftOrRight = Random.Next(100);
            int yonDeger = Random.Next(AlanBoyutlari.Width - namluX + 1) - 150;
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
            //Left = Random.Next(AlanBoyutlari.Height - Height + 1);
            //if (Left <= 0)
            //    Right = Random.Next(AlanBoyutlari.Height - Height + 1);
            Center = namluX;
        }


    }
}
