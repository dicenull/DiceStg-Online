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
    public class Player : IDiceStgObject
    {
        /// <summary>
        /// プレイヤーの規定HP
        /// </summary>
        public static uint DefaultHp = 50;

        public static int ShotInterval = 20;
        
        /// <summary>
        /// 場所を指定して初期化
        /// </summary>
        /// <param name="pos">プレイヤーの初期位置</param>
        public Player(Point pos) : this(pos, ColorState.NextColor) { }

        /// <summary>
        /// 場所と色を指定して初期化
        /// </summary>
        /// <param name="pos">プレイヤーの初期位置</param>
        /// <param name="color">プレイヤーの色</param>
        public Player(Point pos, ColorState color)
        {
            Id = idSeed;
            idSeed++;
            Hp = (int)DefaultHp;
            _shotIntervalCount = ShotInterval;
            Color = color;
            Position = pos;

            MyBullet = new Bullet(this, Direction);
            MyBullet.Disabling();
            Alive = true;
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
        /// プレイヤーの方向
        /// </summary>
        public DirectionState Direction { get; private set; }

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
                    MyBullet.Disabling();
                    Alive = false;
                }
            }
        }

        /// <summary>
        /// プレイヤーの弾
        /// </summary>
        public Bullet MyBullet { get; private set; }

        /// <summary>
        /// 生きているか
        /// </summary>
        public bool Alive { get; private set; }

        /// <summary>
        /// 死んでいるか
        /// </summary>
        public bool Dead { get { return !Alive; } }

        /// <summary>
        /// Shotできる状態か
        /// </summary>
        public bool CanShooting
        {
            get { return (_shotIntervalCount <= 0 && !MyBullet.IsEnable); }
        }

        public void ChangeDirection(ActionState action)
        {
            switch(action)
            {
                case ActionState.MoveDown:
                    Direction = DirectionState.Down;
                    break;
                case ActionState.MoveUp:
                    Direction = DirectionState.Up;
                    break;
                case ActionState.MoveLeft:
                    Direction = DirectionState.Left;
                    break;
                case ActionState.MoveRight:
                    Direction = DirectionState.Right;
                    break;
            }
        }

        public void Move(DirectionState dir)
        {
            Direction = dir;
            Position = Position.Move(dir);
            Update();
        }
        
        public void Shot()
        {
            if (!CanShooting)
            {
                Update();
                return;
            }

            MyBullet = new Bullet(this, Direction);
            
            _shotIntervalCount = ShotInterval;
        }

        /// <summary>
        /// 一動作毎に更新する用
        /// </summary>
        public void Update()
        {
            if (_shotIntervalCount > 0)
                _shotIntervalCount--;

            MyBullet.Update();
        }
        
        /// <summary>
        /// ID設定用
        /// </summary>
        private static int idSeed = 0;

        private int _hp;

        private int _shotIntervalCount;
        
    }
}
