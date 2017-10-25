using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

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
        private bool _gameHasStarted;

        public Game()
        {
            _humanPlayer = new HumanPlayer("Cedric");
            _aiPlayer = new AIPlayer();
            _gameBoard = new GameBoard();
            _gameHasStarted = false;
        }

        public bool GameHasStarted
        {
            get { return _gameHasStarted; }
            set { _gameHasStarted = value; }
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

        public bool CheckForWin()
        {
            return RowOne() || RowTwo() || RowThree() || ColumnOne() || ColumnTwo() || ColumnThree() || DiagonalDown() || DiagonalUp();
        }

        private bool RowOne()
        {
            if (GameBoard.Board[1].Content.Equals(GameBoard.Board[2].Content) && GameBoard.Board[1].Content.Equals(GameBoard.Board[3].Content) && !GameBoard.Board[1].Content.Equals(""))
            {
                if (GameBoard.Board[1].Content.Equals(X)) {
                    GameBoard.Board[1].Color = Brushes.Green;
                    GameBoard.Board[2].Color = Brushes.Green;
                    GameBoard.Board[3].Color = Brushes.Green;
                } else
                {
                    GameBoard.Board[1].Color = Brushes.Red;
                    GameBoard.Board[2].Color = Brushes.Red;
                    GameBoard.Board[3].Color = Brushes.Red;
                }
                return true;
            }
            return false;
        }
        
        private bool RowTwo()
        {
            if (GameBoard.Board[4].Content.Equals(GameBoard.Board[5].Content) && GameBoard.Board[4].Content.Equals(GameBoard.Board[6].Content) && !GameBoard.Board[4].Content.Equals(""))
            {
                if (GameBoard.Board[4].Content.Equals(X))
                {
                    GameBoard.Board[4].Color = Brushes.Green;
                    GameBoard.Board[5].Color = Brushes.Green;
                    GameBoard.Board[6].Color = Brushes.Green;
                }
                else
                {
                    GameBoard.Board[4].Color = Brushes.Red;
                    GameBoard.Board[5].Color = Brushes.Red;
                    GameBoard.Board[6].Color = Brushes.Red;
                }
                return true;
            }
            return false;
        }

        private bool RowThree()
        {
            if (GameBoard.Board[7].Content.Equals(GameBoard.Board[8].Content) && GameBoard.Board[7].Content.Equals(GameBoard.Board[9].Content) && !GameBoard.Board[7].Content.Equals(""))
            {
                if (GameBoard.Board[7].Content.Equals(X))
                {
                    GameBoard.Board[7].Color = Brushes.Green;
                    GameBoard.Board[8].Color = Brushes.Green;
                    GameBoard.Board[9].Color = Brushes.Green;
                }
                else
                {
                    GameBoard.Board[7].Color = Brushes.Red;
                    GameBoard.Board[8].Color = Brushes.Red;
                    GameBoard.Board[9].Color = Brushes.Red;
                }
                return true;
            }
            return false;
        }

        private bool ColumnOne()
        {
            if (GameBoard.Board[1].Content.Equals(GameBoard.Board[4].Content) && GameBoard.Board[1].Content.Equals(GameBoard.Board[7].Content) && !GameBoard.Board[1].Content.Equals(""))
            {
                if (GameBoard.Board[1].Content.Equals(X))
                {
                    GameBoard.Board[1].Color = Brushes.Green;
                    GameBoard.Board[4].Color = Brushes.Green;
                    GameBoard.Board[7].Color = Brushes.Green;
                }
                else
                {
                    GameBoard.Board[1].Color = Brushes.Red;
                    GameBoard.Board[4].Color = Brushes.Red;
                    GameBoard.Board[7].Color = Brushes.Red;
                }
                return true;
            }
            return false;
        }

        private bool ColumnTwo()
        {
            if (GameBoard.Board[2].Content.Equals(GameBoard.Board[5].Content) && GameBoard.Board[2].Content.Equals(GameBoard.Board[8].Content) && !GameBoard.Board[2].Content.Equals(""))
            {
                if (GameBoard.Board[2].Content.Equals(X))
                {
                    GameBoard.Board[2].Color = Brushes.Green;
                    GameBoard.Board[5].Color = Brushes.Green;
                    GameBoard.Board[8].Color = Brushes.Green;
                }
                else
                {
                    GameBoard.Board[2].Color = Brushes.Red;
                    GameBoard.Board[5].Color = Brushes.Red;
                    GameBoard.Board[8].Color = Brushes.Red;
                }
                return true;
            }
            return false;
        }

        private bool ColumnThree()
        {
            if (GameBoard.Board[3].Content.Equals(GameBoard.Board[6].Content) && GameBoard.Board[3].Content.Equals(GameBoard.Board[9].Content) && !GameBoard.Board[3].Content.Equals(""))
            {
                return true;
                if (GameBoard.Board[3].Content.Equals(X))
                {
                    GameBoard.Board[3].Color = Brushes.Green;
                    GameBoard.Board[6].Color = Brushes.Green;
                    GameBoard.Board[9].Color = Brushes.Green;
                }
                else
                {
                    GameBoard.Board[3].Color = Brushes.Red;
                    GameBoard.Board[6].Color = Brushes.Red;
                    GameBoard.Board[9].Color = Brushes.Red;
                }
            }
            return false;
        }

        private bool DiagonalDown()
        {
            if (GameBoard.Board[1].Content.Equals(GameBoard.Board[5].Content) && GameBoard.Board[1].Content.Equals(GameBoard.Board[9].Content) && !GameBoard.Board[1].Content.Equals(""))
            {
                if (GameBoard.Board[1].Content.Equals(X))
                {
                    GameBoard.Board[1].Color = Brushes.Green;
                    GameBoard.Board[5].Color = Brushes.Green;
                    GameBoard.Board[9].Color = Brushes.Green;
                }
                else
                {
                    GameBoard.Board[1].Color = Brushes.Red;
                    GameBoard.Board[5].Color = Brushes.Red;
                    GameBoard.Board[9].Color = Brushes.Red;
                }
                return true;
            }
            return false;
        }

        private bool DiagonalUp()
        {
            if (GameBoard.Board[7].Content.Equals(GameBoard.Board[5].Content) && GameBoard.Board[7].Content.Equals(GameBoard.Board[3].Content) && !GameBoard.Board[7].Content.Equals(""))
            {
                if (GameBoard.Board[7].Content.Equals(X))
                {
                    GameBoard.Board[7].Color = Brushes.Green;
                    GameBoard.Board[5].Color = Brushes.Green;
                    GameBoard.Board[3].Color = Brushes.Green;
                }
                else
                {
                    GameBoard.Board[7].Color = Brushes.Red;
                    GameBoard.Board[5].Color = Brushes.Red;
                    GameBoard.Board[3].Color = Brushes.Red;
                }
                return true;
            }
            return false;
        }

        public bool IsBoardFull()
        {
            for (int i = 1; i <= GameBoard.Board.Count; i++)
            {
                if (GameBoard.Board[i].Free)
                {
                    return false;
                }
            }
            return true;
        }

        public void ResetBoard()
        {
            for (int i = 1; i <= GameBoard.Board.Count; i++)
            {
                GameBoard.Board[i].Content = "";
                GameBoard.Board[i].Color = Brushes.AliceBlue;
            }
        }
    }
}
