using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceStg_Online.Core
{
    public static class DirectionOfActionExtentions
    {
        public static DirectionState ToDirection(this ActionState action)
        {
            switch(action)
            {
                case ActionState.MoveDown:
                    return DirectionState.Down;
                case ActionState.MoveUp:
                    return DirectionState.Up;
                case ActionState.MoveRight:
                    return DirectionState.Right;
                case ActionState.MoveLeft:
                    return DirectionState.Left;
                default:
                    throw new FormatException("向きに変換できないアクションです。");
            }
        }
    }
}
