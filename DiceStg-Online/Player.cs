using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceStg_Online.Core
{
    /// <summary>
    /// ゲームのプレイヤー
    /// </summary>
    public class Player
    {
        /// <summary>
        /// プレイヤーの規定HP
        /// </summary>
        public static uint DefaultHp = 100;

        public static int ShotInterval = 20;

        /// <summary>
        /// コンストラクタでIDとHPを設定
        /// </summary>
        public Player()
        {
            Id = idSeed;
            idSeed++;
            Hp = (int)DefaultHp;
            _shotIntervalCount = ShotInterval;
            Color = new ColorState(new Random(Id).Next(255), new Random(Id + 114).Next(255), new Random(Id + 514).Next(255));
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
        /// 場所と色を指定して初期化
        /// </summary>
        /// <param name="pos">プレイヤーの初期位置</param>
        /// <param name="color">プレイヤーの色</param>
        public Player(Point pos, ColorState color) : this(pos)
        {
            Color = color;
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
        /// プレイヤーの色
        /// </summary>
        public ColorState Color { get; private set; }

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
        /// Shotできる状態か
        /// </summary>
        public bool CanShooting
        {
            get { return (_shotIntervalCount <= 0); }
        }

        public void Move(Actions action)
        {
            switch(action)
            {
                case Actions.MoveDown:
                    Down();
                    break;
                case Actions.MoveUp:
                    Up();
                    break;
                case Actions.MoveLeft:
                    Left();
                    break;
                case Actions.MoveRight:
                    Right();
                    break;
                default:
                    break;
            }
        }
        
        /// <summary>
        /// 上に移動する
        /// </summary>
        public void Up()
        {
            Position.Y--;
            Update();
        }

        /// <summary>
        /// 下に移動する
        /// </summary>
        public void Down()
        {
            Position.Y++;
            Update();
        }

        /// <summary>
        /// 左に移動する
        /// </summary>
        public void Left()
        {
            Position.X--;
            Update();
        }

        /// <summary>
        /// 右に移動する
        /// </summary>
        public void Right()
        {
            Position.X++;
            Update();
        }

        /// <summary>
        /// 一動作毎に更新する用
        /// </summary>
        private void Update()
        {
            if (_shotIntervalCount > 0)
                _shotIntervalCount--;
        }
        
        /// <summary>
        /// ID設定用
        /// </summary>
        private static int idSeed = 0;

        private int _hp;

        private int _shotIntervalCount;
    }
}
