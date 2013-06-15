using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickAndPlay
{
    public class Piece
    {
        public string Name { get; set; }
        public Length Height { get; set; }
        public Length Diameter { get; set; }
        public Player Side {get; set;}
        public char NotationLetter { get; set; }
        public char NotationSymbol { get; set; }

        public Piece()
        {
            Name = "";
            Height = 0;
        
        }
        public Piece(Piece other)
        {
            Name = other.Name;
            Height = other.Height;
            Side = other.Side;
            NotationLetter = other.NotationLetter;
            NotationSymbol = other.NotationSymbol;
        }
    }
}
