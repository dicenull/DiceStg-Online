using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceStg_Online
{
    class Field
    {
        public static int DefaultWidth = 640;
        public static int DefaultHeight = 480;
        
        public Point StartPosition { get; }
        public int Width { get; }
        public int Height { get; }

        public Field() : this(new Point(0,0), DefaultWidth, DefaultHeight) { }
        public Field(Point startPos) : this(startPos, DefaultWidth, DefaultHeight) { }
        public Field(int w, int h) : this(new Point(0,0), w, h) { }
        
        public Field(Point startPos, int w, int h)
        {
            StartPosition = startPos;
            Width = w;
            Height = h;
        }
    }
}
