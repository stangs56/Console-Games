using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Games
{
    abstract class Game
    {
        public int totalGames
        {
            protected set;
            get;
        }

        public void playGames(int numGames = 1)
        {
            if (numGames <= 0)
                throw new ArgumentOutOfRangeException("numGames should be greater than 0");

            for (int i = 0; i < numGames; i++)
            {
                this.playGame();
            }
        }

        protected abstract void playGame();
    }
}
