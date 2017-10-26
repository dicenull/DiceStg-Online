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
        /// 弾のダメージ量
        /// </summary>
        public int Damage { get; private set; }

        /// <summary>
        /// 方向と親のプレイヤーを指定して初期化する
        /// </summary>
        /// <param name="p">親プレイヤー</param>
        /// <param name="dir">発射する方向</param>
        /// <param name="damage">弾のダメージ量</param>
        public Bullet(Player p, DirectionState dir, int damage)
        {
            Position = p.Position.CopyTo();
            IsEnable = p.CanShooting;
            Direction = dir;
            Damage = damage;
        }

        public Bullet(Player p, DirectionState dir) : this(p, dir, 3) { }

        /// <summary>
        /// 弾の状態を更新する
        /// </summary>
        public void Update()
        {
            if (!IsEnable)
                return;

            // 方向に応じて弾を動かす
            Position = Position.Move(Direction);
        }

        public void Disabling()
        {
            IsEnable = false;
        }

        public DirectionState Direction { get; }
    }
    
}
