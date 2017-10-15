using System;
using System.Collections.Generic;
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
    }
}
