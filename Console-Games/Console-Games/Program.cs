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
            TicTacToePlayer p1 = new HumanTicTacToePlayer(), p2 = new HumanTicTacToePlayer();
            TicTacToe game = new TicTacToe(p1, p2, 5);
            game.playGames();
            Console.ReadLine();
        }
    }
}
