using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiceStg_Online.Core;
using DxLibDLL;

namespace DiceStg_Online.Dxlib
{
    /// <summary>
    /// ゲームの状態を描画するクラス
    /// </summary>
    public class GameStateDrawer
    {
        public GameStateDrawer()
        {
            FieldBasePos = new Point(16, 16);
            FieldRightBottomPos = new Point(640 - 16, 480 - 16);
            StatusBasePos = new Point(460, 0);
        }

        /// <summary>
        /// セル(0, 0)の左上の座標
        /// </summary>
        public Point FieldBasePos { get; set; }

        /// <summary>
        /// 最も右下のセルの右下の座標
        /// </summary>
        public Point FieldRightBottomPos { get; set; }

        /// <summary>
        /// プレイヤー一覧の左上の座標
        /// </summary>
        public Point PlayersBasePos { get; set; }

        /// <summary>
        /// ステータス描画の左上の座標
        /// </summary>
        public Point StatusBasePos { get; set; }

        /// <summary>
        /// ゲームの状態を描画する。
        /// </summary>
        /// <param name="state">ゲームの状態</param>
        public void Draw(GameState state)
        {
            DX.ClearDrawScreen();

            var field = state.Field;
            var players = state.Players;

            var lt = FieldBasePos;
            var rb = FieldRightBottomPos;
            var s1 = (field.Width > 0) ? (rb.X - lt.X) / field.Width : 0;
            var s2 = (field.Height > 0) ? (rb.Y - lt.Y) / field.Height : 0;
            var wh = Math.Min(s1, s2);

            // フィールド
            for (var y = 0; y < field.Height; ++y)
            {
                for (var x = 0; x < field.Width; ++x)
                {
                    var bas = new Point(
                        FieldBasePos.X + x * wh,
                        FieldBasePos.Y + y * wh);
                    
                    DX.DrawFillBox(
                        bas.X, bas.Y,
                        bas.X + wh, bas.Y + wh,
                        DX.GetColor(255, 255, 255));
                }
            }
            
            // players
            foreach(var player in players)
            {
                var x = player.Position.X;
                var y = player.Position.Y;
                var c = player.Color;

                var bas = new Point(
                           FieldBasePos.X + x * wh,
                           FieldBasePos.Y + y * wh);

                // draw player
                DX.DrawFillBox(bas.X, bas.Y, bas.X + wh, bas.Y + wh,
                    c.DxColor());

                // draw bullets
                foreach (var bullet in player.Bullets)
                {
                    if(bullet.IsEnable)
                    {
                        var center = new Point(
                            FieldBasePos.X + bullet.Position.X * wh + wh / 2,
                            FieldBasePos.Y + bullet.Position.Y * wh + wh / 2);

                        DX.DrawCircle(center.X, center.Y, wh / 2, c.DxColor());
                    }
                }
            }
            
            // draw turn
            DX.DrawString(StatusBasePos.X, StatusBasePos.Y,
                state.Turn.ToString(), DX.GetColor(255, 255, 255));
            
        }
    }
}
