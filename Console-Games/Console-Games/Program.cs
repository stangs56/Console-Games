using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Games
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToePlayer p1 = new HumanTicTacToePlayer(), p2 = new AITicTacToePlayer();
            TicTacToe game = new TicTacToe(null, p2);
        }
    }
}
