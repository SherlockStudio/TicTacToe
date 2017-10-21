using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.domain
{
    class GameBoard
    {
        private Dictionary<int, Tile> _board;

        public GameBoard()
        {
            _board = new Dictionary<int, Tile>();
            initBoard();
        }

        public void initBoard()
        {
            var one = new Tile();
            var two = new Tile();
            var three = new Tile();
            var four = new Tile();
            var five = new Tile();
            var six = new Tile();
            var seven = new Tile();
            var eight = new Tile();
            var nine = new Tile();
            _board.Add(1, one);
            _board.Add(2, two);
            _board.Add(3, three);
            _board.Add(4, four);
            _board.Add(5, five);
            _board.Add(6, six);
            _board.Add(7, seven);
            _board.Add(8, eight);
            _board.Add(9, nine);
        }

        public Dictionary<int, Tile> Board
        {
            get { return _board; }
        }

        public Tile GetTile(int pos)
        {
            return _board[pos];
        }

        public bool CheckForWin()
        {
            return RowOne();
        }

        private bool RowOne()
        {
            if (Board[1].Content.Equals(Board[2].Content) && Board[1].Content.Equals(Board[3].Content) && !Board[1].Content.Equals(""))
            {
                return true;
            }
            return false;
        }
    }
}
