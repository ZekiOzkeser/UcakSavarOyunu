using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UcakSavar_Library.Concrete;
using UcakSavar_Library.Enum;

namespace UcakSavarOyunu
{
    public partial class AnaForm : Form
    {
        private readonly Oyun _oyun;
        public AnaForm()
        {
            InitializeComponent();
            _oyun = new Oyun(pnlAlt, pnlOyunAlani);
            _oyun.Baslat();
            _oyun.AtesEt();
            _oyun.SkorDegisti += Oyun_SkorDegisti;


        }

        public void AnaForm_Load(object sender,EventArgs e)
        {

        }
        private void AnaForm_KeyDown(object sender, KeyEventArgs e)
        {

            //switch (e.KeyCode)
            //{
            //    //case Keys.Enter:
            //    //    _oyun.Baslat();
            //    //    break;
            //    //case Keys.Right:
            //    //    _oyun.UcaksavariHareketEttir(Yon.Saga);
            //    //    break;
            //    //case Keys.Left:
            //    //    _oyun.UcaksavariHareketEttir(Yon.Sola);
            //    //    break;
            //    //case Keys.Space:
            //    //    _oyun.AtesEt();
            //    //    break;
            //}
        }

        private void Oyun_SkorDegisti(object sender, EventArgs e)
        {
            DialogResult dr = DialogResult.None;
            AnaForm_Load(sender, e);
            lblSkor.Text = _oyun.SkorArttir();

        }
    }
}
