using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TicTacToe.domain
{
    class Tile : INotifyPropertyChanged
    {
        private Boolean _isFree;
        private string _content;
        private Brush _color;

        public Tile()
        {
            _isFree = true;
            _content = "";
            _color = Brushes.AliceBlue;
        }

        public Boolean Free
        {
            get { return _content.Equals(""); }
            set { _isFree = value; }
        }

        public string Content
        {
            get { return _content; }
            set
            {
                _content = value;
                _isFree = true;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Content)));
            }
        }

        public Brush Color
        {
            get { return _color; }
            set
            {
                _color = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Color)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
