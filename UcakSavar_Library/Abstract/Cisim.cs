using System;
using System.Drawing;
using System.Windows.Forms;
using UcakSavar_Library.Concrete;
using UcakSavar_Library.Enum;
using UcakSavar_Library.Interface;

namespace UcakSavar_Library.Abstract
{
    abstract class Cisim : PictureBox, IHareket
    {
        public Size AlanBoyutlari { get; }
        public int Mesafe { get; protected set; }
        public Cisim(Size alanBoyutlari)
        {
            Image = Image = Image.FromFile($@"img\{GetType().Name}.png");
            AlanBoyutlari = alanBoyutlari;
            SizeMode = PictureBoxSizeMode.AutoSize;

        }
        public new int Right
        {
            get => base.Right;
            set => Left = value - Width;
        }

        public new int Bottom
        {
            get => base.Bottom;
            set => Top = value - Height;
        }

        public int Center
        {
            get => Left + Width / 2;
            set => Left = value - Width / 2;
        }

        public int Middle
        {
            get => Top + Height / 2;
            set => Top = value - Height / 2;
        }

        public bool HareketEt(Yon yon)
        {
            switch (yon)
            {               
                case Yon.Yukari:
                    return YukariHareketEttir();
                case Yon.Saga:
                    return SagaHareketEttir();
                case Yon.Asagi:
                    return AsagiHareketEttir();
                case Yon.Sola:
                    return SolaHareketEttir();
                default:
                    throw new ArgumentOutOfRangeException(nameof(yon), yon, null);
            }
        }

            

        private bool SolaHareketEttir()
        {
            if (Left == 0) return true;

            var yeniLeft = Left - Mesafe;
            var tasacakMi = yeniLeft < 0;
            Left = tasacakMi ? 0 : yeniLeft;

            return Left == 0;
        }

        private bool AsagiHareketEttir()
        {
            if (Bottom == AlanBoyutlari.Height) return true;

            var yeniBottom = Bottom + Mesafe;
            var tasacakMi = yeniBottom > AlanBoyutlari.Height;

            Bottom = tasacakMi ? AlanBoyutlari.Height : yeniBottom;

            return Bottom == AlanBoyutlari.Height;
        }

        private bool SagaHareketEttir()
        {
            if (Right == AlanBoyutlari.Width) return true;

            var yeniRight = Right + Mesafe;
            var tasacakMi = yeniRight > AlanBoyutlari.Width;

            Right = tasacakMi ? AlanBoyutlari.Width : yeniRight;

            return Right == AlanBoyutlari.Width;
        }

        private bool YukariHareketEttir()       
        {  
            if (Top == 0) return true;

            if (nameof(Fuze) == GetType().Name)
            {
                int yon = ((Fuze)this).Yon;
                Left = Right- yon;
            }
            var yeniTop = Top - Mesafe;
            var tasacakMi = yeniTop < 0 || Left > AlanBoyutlari.Width;
            Top = tasacakMi ? 0 : yeniTop;

            return Top == 0;
        }


    }
}
