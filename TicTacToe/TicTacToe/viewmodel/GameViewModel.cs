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
    class GameViewModel : INotifyPropertyChanged
    {
        private Game _game;
        private ICommand startGame;
        private ICommand placeTile;
        private ICommand resetGame;
        private string _labelText;
        public event PropertyChangedEventHandler PropertyChanged;

        public GameViewModel()
        {
            _game = new Game();
            startGame = new StartGameCommand(this);
            placeTile = new TileCommand(this);
            resetGame = new ResetCommand(this);
            _labelText = "Who's gonna win?";
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

        public ICommand ResetGame
        {
            get { return resetGame; }
        }

        public bool GameHasStarted {
            get { return _game.GameHasStarted; }
            set
            {
                _game.GameHasStarted = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(GameHasStarted)));
            }
        }

        public string LabelText
        {
            get { return _labelText; }
            set
            {
                _labelText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LabelText)));
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
                // HUMAN PLAYER
                if (!_gvm.Game.CheckForWin())
                {
                    var tile = int.Parse((string)parameter);
                    if (!_gvm.Game.GameBoard.Board[tile].Free)
                    {
                        Trace.WriteLine("You can't place your tile here.");
                    }
                    else
                    {
                        _gvm.Game.GameBoard.Board[tile].Content = _gvm.Game.X;
                        Trace.WriteLine("You clicked tile " + tile);
                        if (_gvm.Game.CheckForWin())
                        {
                            Trace.WriteLine("You won!");
                            _gvm.LabelText = _gvm.Game.HumanPlayer.Name + " wins!";
                            _canExecute = false;
                        }

                        // AI PLAYER
                        if (!_gvm.Game.CheckForWin())
                        {
                            if (!_gvm.Game.IsBoardFull())
                            {
                                Random rnd = new Random();
                                var randomTile = rnd.Next(9) + 1;
                                while (!_gvm.Game.GameBoard.Board[randomTile].Free)
                                {
                                    randomTile = rnd.Next(9) + 1;
                                }
                                _gvm.Game.GameBoard.Board[randomTile].Content = _gvm.Game.O;
                                Trace.WriteLine("AI clicked tile " + randomTile);
                                if (_gvm.Game.CheckForWin())
                                {
                                    Trace.WriteLine("The computer won!");
                                    _gvm.LabelText = _gvm.Game.AIPlayer.Name + " wins!";
                                    _canExecute = false;
                                }
                            }
                            else
                            {
                                Trace.WriteLine("The Game ended in a draw.");
                            }
                        }
                    }
                }
            }
        }

        private class ResetCommand : ICommand
        {
            private GameViewModel _gvm;
            private bool _canExecute;
            public event EventHandler CanExecuteChanged;

            public ResetCommand(GameViewModel gvm)
            {
                _gvm = gvm;
                _gvm.PropertyChanged += Reset_PropertyChanged;
                _canExecute = false;
            }

            private void Reset_PropertyChanged(object sender, PropertyChangedEventArgs e)
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
                _gvm.GameHasStarted = false;
                _gvm.Game.ResetBoard();
                _gvm.LabelText = "Who's gonna win?";
                Trace.WriteLine("You have resetted the game.");
            }
        }
    }
}
