using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickAndPlay
{
    public class SquareBoard
    {
        public int        Width   { get; set; }
        public int        Length  { get { return Width; } }
        public Square[][] Squares { get; set; }
    }
}
