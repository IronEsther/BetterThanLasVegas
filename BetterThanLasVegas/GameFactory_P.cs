using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BestesCasino;

namespace BestesCasino
{
    class GameFactory_P
    {
        public static IGame_P CreateGame(int gameType)
        {
            if (gameType == 1)
            {
                return new RandomNumberGame();
            }
            else if (gameType == 2)
            {
                return new SlotMachine();
            }
            else
            {
                throw new ArgumentException("Ungültiger Spieltyp.");
            }
        }
        public static TGame CreateGame<TGame>() where TGame : IGame_P
            {
                return Activator.CreateInstance<TGame>();
            }
    }
}
