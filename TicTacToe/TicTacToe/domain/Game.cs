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
        private int _turn = 0;

        public Game()
        {
            _humanPlayer = new HumanPlayer("Cedric");
            _aiPlayer = new AIPlayer();
            _gameBoard = new GameBoard();
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
