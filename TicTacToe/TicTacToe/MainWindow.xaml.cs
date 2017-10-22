using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TicTacToe.domain;
using TicTacToe.viewmodel;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameViewModel _gvm;
        public MainWindow()
        {
            InitializeComponent();
            _gvm = new GameViewModel();
            this.DataContext = _gvm;
        }

        /*private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!_gvm.IsBoardFull() || !_gvm.Game.GameBoard.CheckForWin())
            {
                Button button = (Button)sender;
                int row = Grid.GetRow(button);
                int col = Grid.GetColumn(button);
                if (row == 0)
                {
                    var number = col + row + 1;
                    if (_gvm.Game.GameBoard.Board[number].Free)
                    {
                        _gvm.Game.GameBoard.Board[number].Content = _gvm.Game.X;
                        _gvm.Game.Turn = 1;
                    }
                }
                else if (row == 1)
                {
                    var number = col + row + 3;
                    if (_gvm.Game.GameBoard.Board[number].Free)
                    {
                        _gvm.Game.GameBoard.Board[number].Content = _gvm.Game.X;
                        _gvm.Game.Turn = 1;
                    }
                }
                else if (row == 2)
                {
                    var number = col + row + 5;
                    if (_gvm.Game.GameBoard.Board[number].Free)
                    {
                        _gvm.Game.GameBoard.Board[number].Content = _gvm.Game.X;
                        _gvm.Game.Turn = 1;
                    }
                }
            }
        }*/

        /*private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            startButton.IsEnabled = false;
            resetButton.IsEnabled = true;
            _gvm.StartGame();
        }*/

        /*private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            resetButton.IsEnabled = false;
            startButton.IsEnabled = true;
        }*/
    }
}
