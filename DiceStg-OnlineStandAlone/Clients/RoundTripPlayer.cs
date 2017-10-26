using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiceStg_Online.Core;

namespace DiceStg_OnlineStandAlone.Clients
{
    class RoundTripPlayer : Client
    {
        public override ActionState Think(GameState state, int myPlayerNum)
        {
            Player player = state.Players[myPlayerNum];

            if (player.Position.Y == 0)
                isUp = false;

            if (player.Position.Y == state.Field.Height - 1)
                isUp = true;

            if (isUp)
                return ActionState.MoveUp;
            else
                return ActionState.MoveDown;
        }

        private bool isUp = true;
    }
}
