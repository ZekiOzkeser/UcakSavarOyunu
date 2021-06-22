﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UcakSavar_Library.Abstract;

namespace UcakSavar_Library.Concrete
{
       internal class Fuze:Cisim
    {
        private static readonly Random Random = new Random();
        public Fuze(Size alanBoyutlari,int namluX):base(alanBoyutlari)
        {
            RastgeleKonumAyarla(namluX);
            Mesafe = (int)(Height * 1.5);
           
           
        }

        private void RastgeleKonumAyarla(int namluX)
        {            
            Bottom = Random.Next(AlanBoyutlari.Width - Width + 1);
            // Left = (int)(Height * 3);
            //Random.Next(alanBoyutlari.Height - Width + 1);
            // Right = Random.Next(AlanBoyutlari.Width - Width + 1);
            Center = namluX;
        }
        
       
        
    }
}
