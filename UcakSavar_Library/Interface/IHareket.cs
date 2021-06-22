using System.Drawing;
using UcakSavar_Library.Enum;

namespace UcakSavar_Library.Interface
{
    interface IHareket
    {
        Size AlanBoyutlari { get; }
        int Mesafe { get; }
        bool HareketEt(Yon yon);
    }
}
