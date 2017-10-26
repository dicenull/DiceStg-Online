using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiceStg_Online.Core;

namespace DiceStg_OnlineStandAlone.Clients
{
    class RansuchanClient : Client
    {
        public override ActionState Think(GameState state, int myPlayerNum)
        {
            List<ActionState> actions = new List<ActionState>();

            for(ActionState action = ActionState.MoveUp;action <= ActionState.DoNothing;action++)
            {
                actions.Add(action);
            }

            return actions[rnd.Next(actions.Count)];
        }

        private Random rnd = new Random();
    }
}
