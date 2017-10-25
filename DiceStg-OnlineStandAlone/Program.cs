using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiceStg_Online.Core;
using DiceStg_Online.Dxlib;
using DiceStg_OnlineStandAlone.Phases;
using DxLibDLL;

namespace DiceStg_OnlineStandAlone
{
    public class Program
    {
        static void Main()
        {
            new Program().Run();
        }

        private void Run()
        {
            // game state init
            List<Player> players = new List<Player>();
            var clients = new List<Client>();
            players.Add(new Player(new Point(0, 0)));
            clients.Add(new Clients.KeyboardClient(DX.KEY_INPUT_W, DX.KEY_INPUT_D, DX.KEY_INPUT_A, DX.KEY_INPUT_S, DX.KEY_INPUT_SPACE));
            
            players.Add(new Player(new Point(10, 0)));
            clients.Add(new Clients.RoundTripPlayer());
            
            GameState state = new GameState(new Field(30, 30), players);

            Phase phase = new GamePhase(new Game(state), clients);

            // Dxlib init
            DX.ChangeWindowMode(DX.TRUE);
            DX.DxLib_Init();
            DX.SetDrawScreen(DX.DX_SCREEN_BACK);

            while(DX.ProcessMessage() == 0)
            {
                phase = phase.Update();

                if(phase == null)
                {
                    break;
                }
            }

            DX.DxLib_End();
        }
    }
}
