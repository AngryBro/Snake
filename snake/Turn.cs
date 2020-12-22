using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    class Turn
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Direction { get; set; }
        public Turn(int x, int y, Direction direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }
    }
}
