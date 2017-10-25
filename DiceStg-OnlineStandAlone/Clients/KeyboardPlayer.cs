using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;
using DiceStg_Online.Core;

namespace DiceStg_OnlineStandAlone.Clients
{
    class KeyboardClient : Client
    {
        private int keyUp { get; }
        private int keyRight { get; }
        private int keyLeft { get; }
        private int keyDown { get; }
        private int keyShot { get; }

        public KeyboardClient(int keyUp, int keyRight, int keyLeft, int keyDown, int keyShot)
        {
            this.keyUp = keyUp;
            this.keyRight = keyRight;
            this.keyLeft = keyLeft;
            this.keyDown = keyDown;
            this.keyShot = keyShot;
        }

        public override ActionState Think(GameState state, int myPlayerNum)
        {
            if (DX.CheckHitKey(keyUp) != 0)
                return ActionState.MoveUp;

            if (DX.CheckHitKey(keyRight) != 0)
                return ActionState.MoveRight;

            if (DX.CheckHitKey(keyLeft) != 0)
                return ActionState.MoveLeft;

            if (DX.CheckHitKey(keyDown) != 0)
                return ActionState.MoveDown;

            if (DX.CheckHitKey(keyShot) != 0)
                return ActionState.Shot;

            return ActionState.DoNothing;
        }
    }
}
