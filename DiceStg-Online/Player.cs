using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceStg_Online
{
    /// <summary>
    /// ゲームのプレイヤー
    /// </summary>
    class Player
    {
        /// <summary>
        /// プレイヤーの規定HP
        /// </summary>
        public static uint DefaultHp = 100;

        /// <summary>
        /// コンストラクタでIDとHPを設定
        /// </summary>
        public Player()
        {
            Id = idSeed;
            idSeed++;
            Hp = (int)DefaultHp;
        }

        /// <summary>
        /// 場所を指定して初期化
        /// </summary>
        /// <param name="pos">プレイヤーの初期位置</param>
        public Player(Point pos) : this()
        {
            Position = pos;
        }

        /// <summary>
        /// プレイヤーのID
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// プレイヤーの位置
        /// </summary>
        public Point Position { get; private set; }

        /// <summary>
        /// プレイヤーのHP
        /// </summary>
        public int Hp
        {
            get { return _hp; }
            set
            {
                _hp = value;
                if (_hp < 0)
                {
                    _hp = 0;
                    throw new ArgumentOutOfRangeException("HPは0未満の値に設定することができません。");
                }
            }
        }
        
        /// <summary>
        /// 上に移動する
        /// </summary>
        public void Up()
        {
            Position.Y--;
        }

        /// <summary>
        /// 下に移動する
        /// </summary>
        public void Down()
        {
            Position.Y++;
        }

        /// <summary>
        /// 左に移動する
        /// </summary>
        public void Left()
        {
            Position.X--;
        }

        /// <summary>
        /// 右に移動する
        /// </summary>
        public void Right()
        {
            Position.X++;
        }
        
        /// <summary>
        /// ID設定用
        /// </summary>
        private static int idSeed = 0;

        private int _hp;
    }
}
