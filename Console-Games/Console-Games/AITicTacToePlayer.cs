using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Console_Games
{
    class AITicTacToePlayer : TicTacToePlayer
    {

        public override Point makeMove(char piece, bool wrongLastMove)
        {
            throw new NotImplementedException();
        }

        public override void playerWin()
        {
            base.playerWin();
            throw new NotImplementedException();
        }
    }
}
