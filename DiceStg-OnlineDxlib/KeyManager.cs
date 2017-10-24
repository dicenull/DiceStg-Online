using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;

namespace DiceStg_Online.Dxlib
{
    public class KeyManager
    {
        /// <summary>
        /// キーの入力を受け取り、各キーの入力時間を更新する
        /// </summary>
        public void Update()
        {
            flip = 1 - flip;
            DX.GetHitKeyStateAll(keys[flip]);
            Parallel.ForEach(Enumerable.Range(0, 256), i =>
            {
                if (keys[flip][i] == 0 ^ keys[1 - flip][i] == 0)
                {
                    times[i] = 1;
                }
                else
                {
                    ++times[i];
                }
            });
        }

        /// <summary>
        /// 与えられたキーが押されているかを判定する
        /// </summary>
        /// <param name="key">押されているか判定するキー</param>
        /// <returns>そのキーが押されているか</returns>
        public bool IsPressing(int key)
        {
            return keys[flip][key] != 0;
        }

        /// <summary>
        /// 与えられたキーが押されている時間を返す
        /// </summary>
        /// <param name="key">判定するキー</param>
        /// <returns>与えられたキーが押されている時間</returns>
        public int GetPressingTime(int key)
        {
            return IsPressing(key) ? times[key] : 0;
        }

        /// <summary>
        /// 与えられたキーが押されたかを判定する
        /// </summary>
        /// <param name="key">判定するキー</param>
        /// <returns>そのキーが押されたか</returns>
        public bool IsPressed(int key)
        {
            return keys[flip][key] != 0 && keys[1 - flip][key] == 0;
        }

        /// <summary>
        /// 与えられたキーが離されているかを判定する
        /// </summary>
        /// <param name="key">判定するキー</param>
        /// <returns>そのキーが離されているか</returns>
        public bool IsReleasing(int key)
        {
            return keys[flip][key] == 0;
        }

        /// <summary>
        /// 与えられたキーが離されている時間を返す
        /// </summary>
        /// <param name="key">判定するキー</param>
        /// <returns>そのキーが離されている時間</returns>
        public int GetReleasingTime(int key)
        {
            return IsReleasing(key) ? times[key] : 0;
        }

        /// <summary>
        /// 与えられたキーが離されたか判定する
        /// </summary>
        /// <param name="key">判定するキー</param>
        /// <returns>そのキーが離されたか</returns>
        public bool IsReleased(int key)
        {
            return keys[flip][key] == 0 && keys[1 - flip][key] != 0;
        }

        private byte[][] keys = { new byte[256], new byte[256] };
        private int flip = 0;
        private int[] times = new int[256];
    }
}
