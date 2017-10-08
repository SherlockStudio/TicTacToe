using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.domain
{
    class Tile
    {
        private Boolean _isFree;
        private int _content;

        public Tile(int content = 0)
        {
            _isFree = true;
        }

        public Boolean Free
        {
            get { return _content == 0; }
            set { _isFree = value; }
        }

        public int Content
        {
            get { return _content; }
            set
            {
                _content = value;
                _isFree = true;
            }
        }
    }
}
