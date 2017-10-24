using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiceStg_Online.Dxlib;
using DxLibDLL;

namespace DiceStg_OnlineStandAlone.Phases
{
    abstract class Phase
    {
        public Phase Update()
        {
            key.Update();

            Phase res = this.update();

            DX.ScreenFlip();

            return res;
        }

        protected abstract Phase update();

        protected static KeyManager key = new KeyManager();

        protected static GameStateDrawer gameStateDrawer = new GameStateDrawer();
    }
}
