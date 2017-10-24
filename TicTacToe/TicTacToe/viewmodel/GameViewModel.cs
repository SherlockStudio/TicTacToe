using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using TicTacToe.domain;

namespace TicTacToe.viewmodel
{
    class GameViewModel
    {
        private Game _game;
        private ICommand startGame;
        private ICommand placeTile;
        public event PropertyChangedEventHandler PropertyChanged;

        public GameViewModel()
        {
            _game = new Game();
            startGame = new StartGameCommand(this);
            placeTile = new TileCommand(this);
        }

        public Game Game
        {
            get { return _game; }
        }

        public ICommand StartGame
        {
            get { return startGame; }
        }

        public ICommand PlaceTile
        {
            get { return placeTile; }
        }

        public bool GameHasStarted {
            get { return _game.GameHasStarted; }
            set
            {
                _game.GameHasStarted = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(GameHasStarted)));
            }
        }

        private class StartGameCommand : ICommand
        {
            public event EventHandler CanExecuteChanged;
            private GameViewModel _gvm;
            private bool _canExecute;

            public StartGameCommand(GameViewModel gvm)
            {
                _gvm = gvm;
                _gvm.PropertyChanged += Start_PropertyChanged;
                _canExecute = true;
            }

            private void Start_PropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                bool newCanExecute = !_gvm.GameHasStarted;
                if (newCanExecute != _canExecute)
                {
                    _canExecute = newCanExecute;
                    CanExecuteChanged?.Invoke(this, new EventArgs());
                }
            }

            public bool CanExecute(object parameter)
            {
                return _canExecute;
            }

            public void Execute(object parameter)
            {
                _gvm.GameHasStarted = true;
                Trace.WriteLine("The game has started.");
            }
        }

        private class TileCommand : ICommand
        {
            public event EventHandler CanExecuteChanged;
            private GameViewModel _gvm;
            private bool _canExecute;

            public TileCommand(GameViewModel gvm)
            {
                _gvm = gvm;
                _gvm.PropertyChanged += Tile_PropertyChanged;
                _canExecute = false;
            }

            private void Tile_PropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                bool newCanExecute = _gvm.GameHasStarted;
                if (newCanExecute != _canExecute)
                {
                    _canExecute = newCanExecute;
                    CanExecuteChanged?.Invoke(this, new EventArgs());
                }
            }

            public bool CanExecute(object parameter)
            {
                return _canExecute;
            }

            public void Execute(object parameter)
            {
                Trace.WriteLine("You clicked tile " + (string)parameter);
            }
        }
    }
}
