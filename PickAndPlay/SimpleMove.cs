using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickAndPlay
{
    public class SimpleMove
    {
        public Piece Piece { get; set; }
        public Square StartingSquare { get; set; }
        public Square EndingSquare { get; set; }
    }
}
