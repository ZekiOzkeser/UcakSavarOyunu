using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UcakSavar_Library.Enum;
using UcakSavar_Library.Interface;

namespace UcakSavar_Library.Concrete
{
    public class Oyun : IOyun
    {
        #region Alanlar
        private readonly Timer _hareketTimer = new Timer { Interval = 100 };
        private readonly Timer _ucakOlusturTimer = new Timer { Interval = 4000 };
        private readonly Timer _atesEtTimer = new Timer { Interval = 2000 };


        private static int Skor;
        private readonly Panel _altPanel;
        private readonly Panel _oyunPanel;
        private UcakSavar _ucakSavar;
        private readonly List<Fuze> _fuzeler = new List<Fuze>();
        private readonly List<Ucak> _ucaklar = new List<Ucak>();

        #endregion
        #region Olaylar
        public event EventHandler SkorDegisti;
        #endregion

        #region Ozellikler   
        public bool DevamEdiyorMu { get; private set; }



        #endregion

        #region Metodlar

        public Oyun(Panel altPanel, Panel oyunAlani)
        {
            _altPanel = altPanel;
            _oyunPanel = oyunAlani;
            _hareketTimer.Tick += HareketTimer_Tick;
            _ucakOlusturTimer.Tick += UcakOlusturmaTimer_Tick;
            _atesEtTimer.Tick += AtesEtTimer_Tick;
        }

        private void AtesEtTimer_Tick(object sender, EventArgs e)
        {
            AtesEt();
        }

        private void HareketTimer_Tick(object sender, EventArgs e)
        {
            FuzeleriHareketEttir();
            UcaklariHareketEttir();
            VurulanUcaklarSil();

        }

        private void VurulanUcaklarSil()
        {
            for (int i = _ucaklar.Count - 1; i >= 0; i--)
            {
                var ucak = _ucaklar[i];

                var vuranFuze = ucak.VurulduMu(_fuzeler);
                if (vuranFuze is null) continue;

                _ucaklar.Remove(ucak);
                _fuzeler.Remove(vuranFuze);
                _oyunPanel.Controls.Remove(ucak);
                _oyunPanel.Controls.Remove(vuranFuze);
                SkorArttir();

            }
        }

        private void UcaklariHareketEttir()
        {

            for (int i = _ucaklar.Count - 1; i >= 0; i--)
            {
                var ucak = _ucaklar[i];
                var carptiMi = ucak.HareketEt(Enum.Yon.Saga);
                if (!carptiMi) continue;

                _ucaklar.Remove(ucak);
                _oyunPanel.Controls.Remove(ucak);

            }

        }

        private void UcakOlusturmaTimer_Tick(object sender, EventArgs e)
        {

            UcakOlustur();

        }
        private void FuzeleriHareketEttir()
        {
            for (int i = _fuzeler.Count - 1; i >= 0; i--)
            {
                var fuze = _fuzeler[i];
                Random rnd=new Random();
                ballHareket(5, 5, fuze);
                var ulastiMi = fuze.HareketEt(Enum.Yon.Yukari);
                if (ulastiMi)
                {
                    _fuzeler.Remove(fuze);
                    _oyunPanel.Controls.Remove(fuze);
                }
            }

        }

        public void AtesEt()
        {
            if (!DevamEdiyorMu) return;
            var fuze = new Fuze(_oyunPanel.Size, _ucakSavar.Center);
            _fuzeler.Add(fuze);
            _oyunPanel.Controls.Add(fuze);


        }

        public void Baslat()
        {
            if (DevamEdiyorMu) return;


            DevamEdiyorMu = true;
            ZamanlayilariBaslat();
            UcakSavarOlustur();
            UcakOlustur();
        }


        public string SkorArttir()
        {
            Skor++;
            return Skor.ToString();

        }
        private void ZamanlayilariBaslat()
        {
            _hareketTimer.Start();
            _ucakOlusturTimer.Start();
            _atesEtTimer.Start();

        }

        private void ZamanlayilariDurdur()
        {
            _hareketTimer.Stop();
            _ucakOlusturTimer.Stop();
            _atesEtTimer.Stop();
        }

        private void UcakOlustur()
        {
            var ucak = new Ucak(_oyunPanel.Size);
            _ucaklar.Add(ucak);
            _oyunPanel.Controls.Add(ucak);

        }

        private void UcakSavarOlustur()
        {
            _ucakSavar = new UcakSavar(_altPanel.Width, _altPanel.Size);

            _altPanel.Controls.Add(_ucakSavar);

        }
       

        private void Bitir()
        {
            if (!DevamEdiyorMu) return;

            DevamEdiyorMu = false;
            ZamanlayilariDurdur();


        }

        //public void UcaksavariHareketEttir(Yon yon)
        //{
        //    if (!DevamEdiyorMu) return;


        //    _ucakSavar.HareketEt(yon);
        //}

        private void ballHareket(int yerX,int yerY,Fuze fuze)
        {
            if (_oyunPanel.Width <= fuze.Right)
                yerX = yerX * -1;

            else if (0 >= fuze.Left)
                yerX = yerX * -1;

            if (_oyunPanel.Height <= fuze.Bottom)
                yerY = yerY * -1;
            else if (0 >= fuze.Top)
                yerY = yerY * -1;

            else if (fuze.Bottom >= _ucakSavar.Top && fuze.Right >= _ucakSavar.Left && fuze.Left <= _ucakSavar.Right)
                yerY = yerY * -1;

            fuze.Location = new Point(fuze.Left + yerX, fuze.Top + yerY);
        }

        #endregion
    }
}
