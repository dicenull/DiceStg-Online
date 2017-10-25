using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiceStg_Online.Core;
using DxLibDLL;

namespace DiceStg_OnlineStandAlone.Phases
{
    /// <summary>
    /// ゲームフェーズ
    /// </summary>
    class GamePhase : Phase
    {
        public GamePhase(Game game)
        {
            this.game = game;
        }

        /// <summary>
        /// プレイヤーのアクションを元に更新する
        /// </summary>
        /// <returns></returns>
        protected override Phase update()
        {
            List<ActionState> actions = new List<ActionState>();

            for (int i = 0; i < game.State.Players.Count; i++)
            {
                ActionState action = ActionState.DoNothing;
                
                // テストとして0番目のプレイヤーのみ操作可能にした
                if(i == 0)
                {
                    if (key.IsPressed(DX.KEY_INPUT_W))
                        action = ActionState.MoveUp;
                    if (key.IsPressed(DX.KEY_INPUT_S))
                        action = ActionState.MoveDown;
                    if (key.IsPressed(DX.KEY_INPUT_D))
                        action = ActionState.MoveRight;
                    if (key.IsPressed(DX.KEY_INPUT_A))
                        action = ActionState.MoveLeft;
                }

                actions.Add(action);
            }
            
            // ゲーム状態を更新する
            game.Update(actions);

            // ゲーム状態を描画する
            gameStateDrawer.Draw(game.State);

            return this;
        }

        private Game game;
    }
}
