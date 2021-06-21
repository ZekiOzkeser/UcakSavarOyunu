using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcakSavar_Library.Interface
{
    interface IOyun
    {
        bool DevamEdiyorMu { get; }

        void Baslat();
        void AtesEt();
    }
}
