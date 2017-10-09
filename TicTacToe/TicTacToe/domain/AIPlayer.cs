using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.domain
{
    class AIPlayer : Player
    {
        private string _name;
        private int _totalScore;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int TotalScore
        {
            get { return _totalScore; }
            set { _totalScore = value; }
        }
    }
}
