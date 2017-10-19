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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button) sender;
            int row = Grid.GetRow(button);
            int col = Grid.GetColumn(button);
            if (row == 0) { 
                var number = col + row + 1;
                _gvm.Game.GameBoard.Board[number].Content = _gvm.Game.X;
                _gvm.Game.Turn = 1;
            } else if (row == 1)
            {
                var number = col + row + 3;
                _gvm.Game.GameBoard.Board[number].Content = _gvm.Game.X;
                _gvm.Game.Turn = 1;
            } else if (row == 2)
            {
                var number = col + row + 5;
                _gvm.Game.GameBoard.Board[number].Content = _gvm.Game.X;
                _gvm.Game.Turn = 1;
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _gvm.Game.StartGame();
            Button start = (Button)sender;
            start.IsEnabled = false;
        }
    }

    class ContentToImage : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int content = (int)value;
            if (content == 0)
            {
                return 100;
            }
            return 10;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
