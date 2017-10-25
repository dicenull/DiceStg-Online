using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;
using DiceStg_Online.Core;

namespace DiceStg_Online.Dxlib
{
    static class DxColorExtention
    {
        public static uint DxColor(this ColorState color)
        {
            return DX.GetColor(color.R, color.G, color.B);
        }
    }
}
