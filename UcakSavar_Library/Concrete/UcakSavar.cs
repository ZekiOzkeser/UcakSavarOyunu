using System.Drawing;
using UcakSavar_Library.Abstract;

namespace UcakSavar_Library.Concrete
{
    class UcakSavar:Cisim
    {
        public UcakSavar(int genislik,Size alanBoyutlari):base(alanBoyutlari)
        {

            Center = genislik / 2;
            Mesafe = Width;
        }
    }
}
