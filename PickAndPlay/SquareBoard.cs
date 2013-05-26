using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickAndPlay
{
    public class SquareBoard
    {
        public Length Width   { get; set; }
        public Length Length {
            get
            {
                return Width;
            }
            set
            {
                Width = value;
            }
        }
        public SquareBoard()
        {

        }
        public SquareBoard(Length width)
        {
            Width = width;
        }
        public int DivisionsPerSide { get; set; }
    }
}
