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
        public GamePhase(Game game, IList<Client> clients)
        {
            this.game = game;
            this.clients = clients;
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
                if (game.State.Players[i].Dead)
                    actions.Add(ActionState.DoNothing);
                else
                {
                    ActionState action = clients[i].Think(new GameState(game.State), i);

                    actions.Add(action);
                }
            }
            
            // ゲーム状態を更新する
            game.Update(actions);

            // ゲーム状態を描画する
            gameStateDrawer.Draw(game.State);

            return this;
        }

        private Game game;
        private IList<Client> clients;
    }
}
