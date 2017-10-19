using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.domain
{
    class Game
    {
        private Player _humanPlayer;
        private Player _aiPlayer;
        private GameBoard _gameBoard;
        private static readonly string _x = "X";
        private static readonly string _o = "O";
        private int _turn;

        public Game()
        {
            _humanPlayer = new HumanPlayer("Cedric");
            _aiPlayer = new AIPlayer();
            _gameBoard = new GameBoard();
        }

        public async void StartGame()
        {
            Random rnd = new Random();
            while (true)
            { 
                Turn = 0;
                while (Turn == 0)
                {
                    await WaitForButtonClickAsync();
                }
                while (Turn == 1)
                {
                    var number = rnd.Next(9) + 1;
                    GameBoard.Board[number].Content = O;
                    Turn = 0;
                }
            }
        }

        Task WaitForButtonClickAsync()
        {
            return Task.Delay(1);
        }

        public int Turn
        {
            get { return _turn; }
            set { _turn = value; }
        }

        public Player HumanPlayer
        {
            get { return _humanPlayer; }
            set { _humanPlayer = value; }
        }

        public Player AIPlayer
        {
            get { return _aiPlayer; }
            set { _aiPlayer = value; }
        }

        public GameBoard GameBoard
        {
            get { return _gameBoard; }
            set { _gameBoard = value; }
        }

        public string X
        {
            get { return _x; }
        }

        public string O
        {
            get { return _o; }
        }
    }
}
