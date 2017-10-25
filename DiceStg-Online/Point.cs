namespace DiceStg_Online.Core
{
    /// <summary>
    /// 場所を表すクラス
    /// </summary>
    public class Point
    {
        /// <summary>
        /// X座標の位置
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Y座標の位置
        /// </summary>
        public int Y { get; set; }
        
        public Point() : this(0, 0) { }
        
        /// <summary>
        /// 座標の指定して初期化する
        /// </summary>
        /// <param name="x">x座標の初期値</param>
        /// <param name="y">y座標の初期値</param>
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        
        public static Point operator-- (Point p)
        {
            p.X--;
            p.Y--;

            return p;
        }

        public static Point operator++ (Point p)
        {
            p.X++;
            p.Y++;

            return p;
        }
        
        public static Point operator+ (Point p1, Point p2)
        {
            return new Point(p1.X + p2.X, p1.Y + p2.Y);
        }

        public static Point operator+ (Point p, int v)
        {
            return new Point(p.X + v, p.Y + v);
        }

        public static Point operator- (Point p1, Point p2)
        {
            return new Point(p1.X - p2.X, p1.Y - p2.Y);
        }

        public static Point operator-(Point p, int v)
        {
            return new Point(p.X - v, p.Y - v);
        }
    }

    static class PointExtensions
    {
        public static Point Move(this Point p, ActionState action)
        {
            switch (action)
            {
                case ActionState.MoveUp:
                    return new Point(p.X, p.Y - 1);
                case ActionState.MoveDown:
                    return new Point(p.X, p.Y + 1);
                case ActionState.MoveLeft:
                    return new Point(p.X - 1, p.Y);
                case ActionState.MoveRight:
                    return new Point(p.X + 1, p.Y);
                case ActionState.DoNothing:
                    return p;
            }

            return p;
        }
    }
}
