using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceStg_Online
{
    class GameState
    {
        public Field Field;
        public List<Player> Players;
        public int Turn;

        public GameState(Field field, List<Player> players, int turn)
        {
            Field = field;
            Players = players;
            Turn = turn;
        }
    }
}
