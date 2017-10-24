using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiceStg_Online.Core;
using DxLibDLL;

namespace DiceStg_OnlineStandAlone.Phases
{
    class GamePhase : Phase
    {
        public GamePhase(Game game)
        {
            this.game = game;
        }

        protected override Phase update()
        {
            List<Actions> actions = new List<Actions>();

            for (int i = 0; i < game.State.Players.Count; i++)
            {
                Actions action = Actions.DoNothing;
                
                // テストとして0番目のプレイヤーのみ操作可能にした
                if(i == 0)
                {
                    if (key.IsPressed(DX.KEY_INPUT_W))
                        action = Actions.MoveUp;
                    if (key.IsPressed(DX.KEY_INPUT_S))
                        action = Actions.MoveDown;
                    if (key.IsPressed(DX.KEY_INPUT_D))
                        action = Actions.MoveRight;
                    if (key.IsPressed(DX.KEY_INPUT_A))
                        action = Actions.MoveLeft;
                }

                actions.Add(action);
            }
            
            game.Update(actions);

            gameStateDrawer.Draw(game.State);

            return this;
        }

        private Game game;
    }
}
