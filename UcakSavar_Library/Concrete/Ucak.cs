using System;
using System.Collections.Generic;
using System.Drawing;
using UcakSavar_Library.Abstract;

namespace UcakSavar_Library.Concrete
{
    class Ucak : Cisim
    {
        private static readonly Random Random = new Random();
        public Ucak(Size alanBoyutlari) : base(alanBoyutlari)
        {
            Mesafe = (int)(Width * 0.1);
            Top = Random.Next(alanBoyutlari.Height - Height + 1);
        }

        public Fuze  VurulduMu(List<Fuze> fuzeler)
        {
            foreach (var fuze  in fuzeler)
            {
                var vurulduMu = fuze.Top < Bottom && fuze.Right > Left && fuze.Left < Right;
                if (vurulduMu)
                    return fuze;
            
            }
            return null ;
        }
    }
}
