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
        /// 必要な情報をもとに初期化する
        /// </summary>
        /// <param name="field">初期フィールド</param>
        /// <param name="players">参加するプレイヤー</param>
        public GameState(Field field, List<Player> players)
        {
            Field = field;
            Players = players;
            Turn = 0;
        }
    }
}
