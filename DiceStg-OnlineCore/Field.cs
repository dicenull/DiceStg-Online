using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceStg_Online.Core
{
    public class Field
    {
        /// <summary>
        /// フィールドのデフォルトの幅
        /// </summary>
        public static int DefaultWidth = 640;

        /// <summary>
        /// フィールドのデフォルトの高さ
        /// </summary>
        public static int DefaultHeight = 480;
        
        /// <summary>
        /// フィールドの幅
        /// </summary>
        public int Width { get; }

        /// <summary>
        /// フィールドの高さ
        /// </summary>
        public int Height { get; }

        /// <summary>
        /// デフォルト値を使用して初期化
        /// </summary>
        public Field() : this(DefaultWidth, DefaultHeight) { }
        
        /// <summary>
        /// 幅と高さを指定して初期化
        /// </summary>
        /// <param name="w">幅</param>
        /// <param name="h">高さ</param>
        public Field(int w, int h)
        {
            Width = w;
            Height = h;
        }
    }
}
