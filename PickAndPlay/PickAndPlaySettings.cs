using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PickAndPlay
{
    public class PickAndPlaySettings
    {
        public double BoardSize { get; set; }
        public double PieceHeight { get; set; }
        public double Speed { get; set; }
        public double LiftHeight { get; set; }
        public int DropWait { get; set; }
    }
}
