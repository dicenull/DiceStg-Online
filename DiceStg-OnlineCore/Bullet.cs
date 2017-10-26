using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceStg_Online.Core
{
    /// <summary>
    /// 弾を管理するクラス
    /// </summary>
    public class Bullet : IDiceStgObject
    {
        /// <summary>
        /// 弾の場所
        /// </summary>
        public Point Position { get; private set; }

        /// <summary>
        /// この弾が有効か
        /// </summary>
        public bool IsEnable { get; private set; }

        /// <summary>
        /// 方向と親のプレイヤーを指定して初期化する
        /// </summary>
        /// <param name="p">親プレイヤー</param>
        /// <param name="dir">発射する方向</param>
        public Bullet(Player p, DirectionState dir)
        {
            Position = p.Position.CopyTo();
            IsEnable = p.CanShooting;
            Direction = dir;
        }

        /// <summary>
        /// 弾の状態を更新する
        /// </summary>
        public void Update()
        {
            if (!IsEnable)
                return;

            // 方向に応じて弾を動かす
            switch(Direction)
            {
                case DirectionState.Left:
                    Position.X--;
                    break;
                case DirectionState.Right:
                    Position.X++;
                    break;
                case DirectionState.Up:
                    Position.Y--;
                    break;
                case DirectionState.Down:
                    Position.Y++;
                    break;
            }
            
        }

        public void Disabling()
        {
            IsEnable = false;
        }

        private DirectionState Direction { get; }
    }
    
}
