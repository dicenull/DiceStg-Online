using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiceStg_Online.Core;

namespace DiceStg_OnlineStandAlone.Clients
{
    class DoNothingClient : Client
    {
        public override ActionState Think(GameState state, int myPlayerNum)
        {
            return ActionState.DoNothing;
        }
    }
}
