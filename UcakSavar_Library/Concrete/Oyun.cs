using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UcakSavar_Library.Interface;

namespace UcakSavar_Library.Concrete
{
    public class Oyun : IOyun
    {
        #region Alanlar

     
        private readonly Timer _hareketTimer = new Timer { Interval = 100 };
        private readonly Timer _ucakOlusturTimer = new Timer { Interval =2000 };
        private readonly Timer _atesEtTimer = new Timer { Interval = 800 };
        private static int Skor;
        private readonly Panel _altPanel;
        private readonly Panel _oyunPanel;
        private UcakSavar _ucakSavar;
        private readonly List<Fuze> _fuzeler = new List<Fuze>();
        private readonly List<Ucak> _ucaklar = new List<Ucak>();

        private Label skor;

        #endregion
       
        #region Ozellikler   
        public bool DevamEdiyorMu { get; private set; }
        #endregion

        #region Metodlar

        public Oyun(Panel altPanel, Panel oyunAlani,Label lblSkor)
        {
            _altPanel = altPanel;
            _oyunPanel = oyunAlani;
            _hareketTimer.Tick += HareketTimer_Tick;
            _ucakOlusturTimer.Tick += UcakOlusturmaTimer_Tick;
            _atesEtTimer.Tick += AtesEtTimer_Tick;
            skor = lblSkor;
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
                skor.Text = SkorArttir();
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
                var ulastiMi = fuze.HareketEt(Enum.Yon.Yukari);
                if (ulastiMi)
                {
                    _fuzeler.Remove(fuze);
                    _oyunPanel.Controls.Remove(fuze);
                }

                if (fuze.Top <=0)
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
            if (Skor == 10)
            {
                Bitir();
                Skor = 0;
                DialogResult dialog = new DialogResult();
                dialog=MessageBox.Show("Kazandınız !\n\nTekrar Oynamak ister misiniz ?","", MessageBoxButtons.YesNo);
                if (dialog==DialogResult.Yes)
                    Application.Restart();
               
                else 
                    Application.Exit();
            }
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
       

        public void Bitir()
        {
            if (!DevamEdiyorMu) return;

            DevamEdiyorMu = false;
            ZamanlayilariDurdur();

        }
        
        #endregion
    }
}
