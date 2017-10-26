using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceStg_Online.Core
{
    /// <summary>
    /// ゲーム進行に必要な情報を合わせたもの
    /// </summary>
    public class GameState
    {
        /// <summary>
        /// フィールド
        /// </summary>
        public Field Field;

        /// <summary>
        /// 全プレイヤー
        /// </summary>
        public List<Player> Players;

        /// <summary>
        /// ターン数
        /// </summary>
        public int Turn;

        /// <summary>
        /// 生きているプレイヤーの数
        /// </summary>
        public int AlivePlayerCount { get { return Players.Select(p => p.Alive).Count(); } }

        /// <summary>
        /// 必要な情報をもとに初期化する
        /// </summary>
        /// <param name="field">初期フィールド</param>
        /// <param name="players">参加するプレイヤー</param>
        /// <param name="turn">ターン数</param>
        public GameState(Field field, List<Player> players, int turn)
        {
            Field = field;
            Players = players;
            Turn = turn;
        }

        public GameState(GameState state) : this(state.Field, state.Players, state.Turn) { }

        public GameState(Field field, List<Player> players) : this(field, players, 0) { }
    }
}
