using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.domain;

namespace TicTacToe.viewmodel
{
    class GameViewModel
    {
        private Game _game;

        public GameViewModel()
        {
            _game = new Game();
        }

        public Game Game
        {
            get { return _game; }
        }

        public bool StartGame()
        {
            Random rnd = new Random();
            while (!IsBoardFull())
            {
                if (Game.Turn == 0)
                {
                    if (Game.GameBoard.CheckForWin())
                    {
                        return true;
                    }
                }
                if (Game.Turn == 1)
                {
                    var number = rnd.Next(9) + 1;
                    while (!AIPlaceSymbol(number))
                    {
                        number = rnd.Next(9) + 1;
                    }
                    if (Game.GameBoard.CheckForWin())
                    {
                        return true;
                    }
                    Game.Turn = 0;
                }
            }
            return false;
        }

        public bool AIPlaceSymbol(int number)
        {
            if (Game.GameBoard.Board[number].Free) {
                Game.GameBoard.Board[number].Content = Game.O;
                return true;
            }
            return false;
        }

        public bool IsBoardFull()
        {
            for (int i = 1; i <= Game.GameBoard.Board.Count; i++)
            {
                if (Game.GameBoard.Board[i].Free)
                {
                    return false;
                }
            }
            return true;
        }

        Task WaitForButtonClickAsync()
        {
            return Task.Delay(100);
        }
    }
}
