using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.domain
{
    class Tile : INotifyPropertyChanged
    {
        private Boolean _isFree;
        private string _content;

        public Tile()
        {
            _isFree = true;
            _content = "";
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

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
