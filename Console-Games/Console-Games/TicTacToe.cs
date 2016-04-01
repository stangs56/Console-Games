using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Console_Games
{
    class TicTacToe
    {
        private const char empty = ' ', p1Piece = 'X', p2Piece = 'O';

        private TicTacToePlayer player1, player2;
        private char[,] board;
        private int size;

        public int totalGames
        {
            private set;
            get;
        }

        public TicTacToe(TicTacToePlayer player1, TicTacToePlayer player2, int size = 3)
        {
            if (player1 == null)
                throw new ArgumentNullException("Player1 can't be null");
            if (player2 == null)
                throw new ArgumentNullException("Player2 can't be null");

            if (size <= 0)
                throw new ArgumentOutOfRangeException("size should be greater than 0");

            this.player1 = player1;
            this.player1.game = this;
            this.player2 = player2;
            this.player2.game = this;
            this.size = size;
            this.board = new char[size, size];

            //couldn't find a better way to initialize a multidimensional array
            for(int x = 0; x < size; x++)
            {
                for(int y = 0; y < size; y++)
                {
                    this.board[x, y] = empty;
                }
            }
        }

        public void playGames(int numGames = 1)
        {
            if (numGames <= 0)
                throw new ArgumentOutOfRangeException("numGames should be greater than 0");

            for(int i = 0; i < numGames; i++)
            {
                this.playGame();
            }
        }

        /// <summary>
        /// Prints the game board to console
        /// 
        /// should probably be moved somewhere else to keep
        /// this class abstracted from the UI
        /// </summary>
        public void printBoard()
        {
            //maybe move to player class???
            //or human player class???

            for(int i = 0; i < this.size; i++)
            {
                Console.Write(" {0}", i + 1);
            }
            Console.WriteLine();

            //this whole thing could be a lot better
            for(int y = 0; y < this.size; y++)
            {
                Console.Write(y + 1);

                for(int x = 0; x < this.size; x++)
                {
                    Console.Write(this.board[x, y]);
                    Console.Write('|');
                }

                Console.WriteLine();

                Console.Write(" ");
                for(int i = 0; i < 2*this.size; i++)
                {
                    Console.Write('-');
                }

                Console.WriteLine();
            }
        }

        private void playGame()
        {
            this.totalGames++;

            bool turn = true;

            while (!this.isBoardFull())
            {
                //alternate between player 1 and 2
                TicTacToePlayer cur = turn ? this.player1 : this.player2;
                char piece = turn ? p1Piece : p2Piece;
                turn = !turn;

                Point spot;
                bool wrong = false;
                while (true) {
                    spot = cur.makeMove(piece, wrong);
                    if (spot.X < 1 || spot.X > this.size || spot.Y < 1 || spot.Y > this.size)
                    {
                        wrong = true;
                        continue;
                    }

                    spot.X--;
                    spot.Y--;

                    if (this.board[(int)spot.X, (int)spot.Y] == empty)
                        break;
                    wrong = true;
                }

                this.board[(int)spot.X, (int)spot.Y] = piece;

                //current player won
                if (this.checkWin())
                {
                    cur.playerWin();
                    return;
                }
            }

            //shouldn't be in this class
            //TODO: remove
            Console.WriteLine("TIE?!?!?!?!");
            Console.ReadLine();
        }

        /// <summary>
        /// Checks if the board has any open spaces
        /// </summary>
        /// <returns>true if the board is full</returns>
        private bool isBoardFull()
        {
            foreach(char cur in this.board)
            {
                //if an empty space is found the board has possible moves
                if (cur == empty)
                    return false;
            }

            //no empty space was found
            return true;
        }

        /// <summary>
        /// Checks the board and determines if there is a winner
        /// </summary>
        /// <returns>Whether someone won</returns>
        private bool checkWin()
        {
            //maybe go through and directly use variable
            //I'm lazy though, I could remove this line
            //but I like using 'this'
            int size = this.size;

            //a manual loop is used becuase we need to access elements around it
            for (int x = 0; x < size; x++)
            {
                for(int y = 0; y < size; y++)
                {
                    bool win;
                    char cur = this.board[x, y];
                    if (cur == empty)
                        continue;

                    //check horizontal
                    win = true;

                    for (int i = 0; i < size; i++)
                    {
                        if (this.board[i, y] != cur)
                            win = false;
                    }

                    if (win)
                        return true;

                    //check vertical
                    win = true;

                    for(int i = 0; i < size; i++)
                    {
                        if (this.board[x, i] != cur)
                            win = false;
                    }

                    if (win)
                        return true;

                    //check diagonal

                    //only check if on a diagonal
                    if (x == y)
                    {
                        win = true;

                        for (int i = 0; i < size; i++)
                        {
                            if (this.board[i, i] != cur)
                                win = false;
                        }

                        if (win)
                            return true;
                    }
                }
            }
            return false;
        }
    }
}
