using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Console_Games
{
    class HumanTicTacToePlayer : TicTacToePlayer
    {

        public override Point makeMove(char piece, bool wrongLastMove)
        {
            Console.Clear();
            if (wrongLastMove)
            {
                Console.WriteLine("Invalid choice, press enter to try again");
                Console.ReadLine();
            }

            this.game.printBoard();


            int x = -1, y = -1;
            string[] vals;

            do {
                Console.WriteLine("Your piece is \"{0}\"", piece);
                Console.WriteLine("Enter x and then y coordinate seperated by a space ie \"2 3\"");
                vals = Console.ReadLine().Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
            } while (!int.TryParse(vals[0], out x) || !int.TryParse(vals[1], out y));

            return new Point(x, y);
        }

        public override void playerWin()
        {
            base.playerWin();
            Console.WriteLine("You win!!!!");
        }
    }
}
