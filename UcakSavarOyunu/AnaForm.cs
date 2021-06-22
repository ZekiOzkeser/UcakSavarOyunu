using System;
using System.Windows.Forms;
using UcakSavar_Library.Concrete;

namespace UcakSavarOyunu
{
    public partial class AnaForm : Form
    {
        private readonly Oyun _oyun;
        public AnaForm()
        {
            InitializeComponent();
            _oyun = new Oyun(pnlAlt, pnlOyunAlani, lblSkor);
            _oyun.Baslat();
            _oyun.AtesEt();
        }


        private void AnaForm_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.Enter:
                    _oyun.Baslat();
                    break;
                    //case Keys.Right:
                    //    _oyun.UcaksavariHareketEttir(Yon.Saga);
                    //    break;
                    //case Keys.Left:
                    //    _oyun.UcaksavariHareketEttir(Yon.Sola);  
                    break;
                case Keys.Space:
                    _oyun.AtesEt();
                    break;
            }
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt16(lblSkor.Text) < 3)
            {
                _oyun.Bitir();
                DialogResult dialog = new DialogResult();
                dialog=MessageBox.Show("Hakkınız Bitti!\n\nOyundan çıkılsın mı?","ÇIKIŞ", MessageBoxButtons.OKCancel);
                if (dialog==DialogResult.OK)
                {
                    this.Close();
                }
                else
                {
                    dialog = MessageBox.Show("Oyun Yeniden Başlıyor..\n\nBol Şanslar 😉 ", "", MessageBoxButtons.OK);
                    if(dialog==DialogResult.OK)
                        Application.Restart();
                }
                
            }

        }
    }
}
