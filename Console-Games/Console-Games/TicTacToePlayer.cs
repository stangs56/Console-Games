using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Console_Games
{
    abstract class TicTacToePlayer
    {
        public TicTacToe game
        {
            set;
            protected get;
        }

        public int wins
        {
            private set;
            get;
        }

        public abstract Point makeMove(char piece, bool wrongLastMove);
        public virtual void playerWin()
        {
            this.wins++;
        }
    }
}
