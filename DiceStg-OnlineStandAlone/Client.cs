using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiceStg_Online.Core;

namespace DiceStg_OnlineStandAlone
{
    public abstract class Client
    {
        public abstract ActionState Think(GameState state, int myPlayerNum);
        
    }
}
