using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Games
{
    class MainMenu
    {
        /// <summary>
        /// Displays menu
        /// </summary>
        /// <param name="title"></param>
        /// <param name="choices"></param>
        /// <param name="alias"></param>
        /// <returns>1-indexed choice</returns>
        public static int showMenu(string title, string[] choices, Dictionary<string, int> alias = null)
        {
            while (true)
            {
                Console.WriteLine(title);

                //manual loop is used for numbering
                for(int i = 0; i < choices.Length; i++)
                {
                    Console.WriteLine("{0}. {1}", i + 1, choices[i]);
                }

                Console.WriteLine("Enter your selection: ");
                string option = Console.ReadLine();

                int choice;
                if(alias != null && alias.TryGetValue(option.ToLower(), out choice))
                {
                    return choice;
                }

                if(int.TryParse(option, out choice) && choice > 0 && choice < choices.Length)
                {
                    return choice;
                }
            }
        }


        public MainMenu()
        {
            
        }

        public void show()
        {
            Dictionary<string, int> alias = new Dictionary<string, int>();

            alias["quit"] = 1;
            alias["q"] = 1;
            alias["ttt"] = 2;
            alias["tictactoe"] = 2;
            alias["bs"] = 3;

            switch(MainMenu.showMenu("Choose a game", new string[] { "quit", "Tic Tac Toe", "Battle Ship"}, alias))
            {
                case 1:
                    return;
                case 2:
                    this.showTicTacToeMenu();
                    break;
                case 3:
                    this.showBattleshipMenu();
                    break;
            }
        }

        private TicTacToePlayer showTTTPlayerMenu(string prompt)
        {
            Dictionary<string, int> alias = new Dictionary<string, int>();

            alias["h"] = 1;
            alias["ai"] = 2;
            alias["c"] = 3;

            switch (MainMenu.showMenu(prompt, new string[] {"Human Player", "AI Player", "Cancel" }, alias))
            {
                case 1:
                    return new HumanTicTacToePlayer();
                case 2:
                    return new AITicTacToePlayer();
                case 3:
                default:
                    return null;
            }
        }

        private void showTicTacToeMenu()
        {
            int boardSize;

            do
            {
                Console.Write("Enter Board Size: ");
            } while (int.TryParse(Console.ReadLine(), out boardSize) && boardSize < 0);

            TicTacToePlayer p1 = this.showTTTPlayerMenu("Choose Player 1");

            if (p1 == null)
                return;
            
            TicTacToePlayer p2 = this.showTTTPlayerMenu("Choose Player 2");

            if (p2 == null)
                return;

            TicTacToe game = new TicTacToe(p1, p2, boardSize);
            game.playGames();
            Console.ReadLine();
        }

        private void showBattleshipMenu()
        {
            throw new NotImplementedException();
        }
    }
}
