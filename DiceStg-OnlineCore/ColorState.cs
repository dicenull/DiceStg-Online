using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceStg_Online.Core
{
    /// <summary>
    /// 色を管理するクラス
    /// </summary>
    public class ColorState
    {
        /// <summary>
        /// 赤
        /// </summary>
        public int R { get; private set; }

        /// <summary>
        /// 緑
        /// </summary>
        public int G { get; private set; }

        /// <summary>
        /// 青
        /// </summary>
        public int B { get; private set; }

        /// <summary>
        /// それぞれい色を指定して初期化
        /// </summary>
        /// <param name="r">赤</param>
        /// <param name="g">緑</param>
        /// <param name="b">青</param>
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

        /// <summary>
        /// 列挙されている色を順番に取得できる
        /// </summary>
        public static ColorState NextColor
        {
            get
            {
                ColorState color = ((Palette)(ptr)).Color();
                // 値を範囲を超えないようにする
                ptr = (ptr + 1) % Enum.GetNames(typeof(Palette)).Length;

                return color;
            }
        }

        // NextColorようポインタ
        static int ptr = 0;
    }

    /// <summary>
    /// PaletteからColorを取得できるようにする
    /// </summary>
    static class PaletteExtention
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
