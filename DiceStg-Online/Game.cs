using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceStg_Online.Core
{
    public class Game
    {
        public Game(GameState initState)
        {
            State = initState;
        }

        public void Update(IList<Actions> actions)
        {
            if(actions == null)
            {
                throw new ArgumentException("ゲームの進行にはアクションが必要です。");
            }

            if(actions.Count != State.Players.Count)
            {
                throw new ArgumentException("プレイヤーの数と等しいアクションを入力してください。");
            }

            movePhase(actions);

            State = new GameState(State.Field, State.Players, State.Turn + 1);
        }

        public GameState State { get; private set; }

        private void movePhase(IList<Actions> actions)
        {
            for(int i = 0;i < State.Players.Count;i++)
            {
                Actions action = actions[i];
                Player player = State.Players[i];

                switch (action)
                {
                    case Actions.MoveUp:
                    case Actions.MoveDown:
                    case Actions.MoveRight:
                    case Actions.MoveLeft:
                        if (isInField(player.Position.Move(action)))
                            player.Move(action);
                        break;
                    case Actions.Shot:
                        if(player.CanShooting)
                        {

                        }
                        break;
                    case Actions.DoNothing:
                    default:
                        break;
                }

            }
        }
        
        private bool isInField(Point pos)
        {
            return (pos.X >= 0 && pos.Y >= 0 && pos.X < State.Field.Width && pos.Y < State.Field.Height);
        }
    }
}
