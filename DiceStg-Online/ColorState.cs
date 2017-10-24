using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceStg_Online.Core
{
    public class ColorState
    {
        public int R { get; private set; }
        public int G { get; private set; }
        public int B { get; private set; }

        public ColorState(int r, int g, int b)
        {
            this.R = r;
            this.G = g;
            this.B = b;
        }
        
        public override string ToString()
        {
            return string.Format("#{0:x2}{1:x2}{2:x2}", R, G, B);
        }

        public static ColorState NextColor
        {
            get
            {
                ColorState color = ((Palette)(ptr)).Color();
                ptr = (ptr + 1) % Enum.GetNames(typeof(Palette)).Length;

                return color;
            }
        }

        static int ptr = 0;
    }

    static class PaletteExtern
    {
        
        public static ColorState Color(this Palette palette)
        {
            switch(palette)
            {
                case Palette.Black:
                    return new ColorState(0, 0, 0);
                case Palette.White:
                    return new ColorState(255, 255, 255);
                case Palette.Red:
                    return new ColorState(255, 0, 0);
                case Palette.Green:
                    return new ColorState(0, 255, 0);
                case Palette.Blue:
                    return new ColorState(0, 0, 255);
                case Palette.Yellow:
                    return new ColorState(255, 255, 0);

                default: // 存在しない場合はショッキングピンクを返す
                    return new ColorState(248, 0, 163);
            }
        }
    }
}
