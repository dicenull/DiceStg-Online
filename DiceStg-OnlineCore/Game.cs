using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceStg_Online.Core
{
    public class Game
    {
        /// <summary>
        /// 初期ステータスを使用して初期化
        /// </summary>
        /// <param name="initState"></param>
        public Game(GameState initState)
        {
            State = initState;
        }

        /// <summary>
        /// 全Playerのアクションを元にゲームを更新
        /// </summary>
        /// <param name="actions"></param>
        public void Update(IList<ActionState> actions)
        {
            if(actions == null)
            {
                throw new ArgumentException("ゲームの進行にはアクションが必要です。");
            }

            if(actions.Count != State.Players.Count)
            {
                throw new ArgumentException("プレイヤーの数と等しいアクションを入力してください。");
            }

            // 判定
            judgePhase();

            // 行動
            actionPhase(actions);

            // 状態を更新
            State = new GameState(State.Field, State.Players, State.Turn + 1);
        }

        /// <summary>
        /// ゲームの状態
        /// </summary>
        public GameState State { get; private set; }

        private void judgePhase()
        {
            for (int i = 0; i < State.Players.Count; i++)
            {
                Player player = State.Players[i];

                if (player.Dead)
                    continue;

                IDiceStgObject obj = getObject(player.Position);

                // 画面買いに行く弾は無効化
                if (!isInField(player.MyBullet.Position.Move(player.MyBullet.Direction)))
                    player.MyBullet.Disabling();

                // プレイヤーの位置に弾があったらダメージ計算
                if (obj is Bullet && player.Position == obj.Position)
                {
                    Bullet bullet = obj as Bullet;

                    if (!bullet.IsEnable)
                        continue;

                    player.Hp -= bullet.Damage;
                    
                    bullet.Disabling();
                }
            }
        }

        /// <summary>
        /// アクションを元にオブジェクトを移動させる
        /// </summary>
        /// <param name="actions">プレイヤーごとのアクション</param>
        private void actionPhase(IList<ActionState> actions)
        {
            for(int i = 0;i < State.Players.Count;i++)
            {
                ActionState action = actions[i];
                Player player = State.Players[i];

                if (player.Dead)
                    continue;
                
                switch (action)
                {
                    case ActionState.MoveUp:
                    case ActionState.MoveDown:
                    case ActionState.MoveRight:
                    case ActionState.MoveLeft:
                        var dir = action.ToDirection();
                        if (isInField(player.Position.Move(dir)) && canPass(player.Position.Move(dir)))
                            player.Move(dir);
                        else
                            player.ChangeDirection(action);
                        break;
                    case ActionState.Shot:
                        player.Shot();
                        break;
                    case ActionState.DoNothing:
                    default:
                        player.Update();
                        break;
                }

            }
        }

        /// <summary>
        /// その場所がフィールド内にあるか判定する
        /// </summary>
        /// <param name="pos">判断する場所</param>
        /// <returns>その場所がフィールド内にあるか</returns>
        private bool isInField(Point pos)
        {
            return (pos.X >= 0 && pos.Y >= 0 && pos.X < State.Field.Width && pos.Y < State.Field.Height);
        }
        
        private bool canPass(Point pos)
        {
            return !(getObject(pos) is Player);
        }

        private IDiceStgObject getObject(Point pos)
        {
            IDiceStgObject res = null;
            foreach(Player p in State.Players)
            {
                if(p.Position == pos)
                {
                    res = p;
                    break;
                }

                if(p.MyBullet.Position == pos)
                {
                    res = p.MyBullet;
                    break;
                }
            }

            return res;
        }
        
        // todo 通行可能か
        // todo その場所に何があるか
    }
}
