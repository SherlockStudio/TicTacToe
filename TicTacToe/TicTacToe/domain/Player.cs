using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.domain
{
    interface Player
    {
        string Name { get; set; }
        int TotalScore { get; set; }
    }
}
