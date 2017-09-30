using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceStg_Online.Core
{
    enum Direction
    {
        Up, Down, Left, Right
    }
    
    class Bullet
    {
        public Point Position { get; private set; }
        public bool IsEnable { get; private set; }

        public Bullet(Player p, Direction dir)
        {
            Position = p.Position;
            IsEnable = p.CanShooting;
            Direction = dir;
        }

        public void Update()
        {
            if (!IsEnable)
                return;

            switch(Direction)
            {
                case Direction.Left:
                    Position.X--;
                    break;
                case Direction.Right:
                    Position.X++;
                    break;
                case Direction.Up:
                    Position.Y--;
                    break;
                case Direction.Down:
                    Position.Y++;
                    break;
            }
        }

        public void Disabling()
        {
            IsEnable = false;
        }

        private Direction Direction { get; }
    }
    
}
