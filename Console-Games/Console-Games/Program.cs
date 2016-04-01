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
            int boardSize;

            do
            {
                Console.Write("Enter Board Size: ");
            } while (int.TryParse(Console.ReadLine(), out boardSize) && boardSize < 0);

            TicTacToePlayer p1 = new HumanTicTacToePlayer(), p2 = new HumanTicTacToePlayer();
            TicTacToe game = new TicTacToe(p1, p2, boardSize);
            game.playGames();
            Console.ReadLine();
        }
    }
}
