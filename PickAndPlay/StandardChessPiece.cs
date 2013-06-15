using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickAndPlay
{
    public static class StandardChessPiece
    {
        public static Piece King = new Piece() { Name = "King", NotationLetter = 'K' };
        public static Piece Queen = new Piece() { Name = "Queen", NotationLetter = 'Q' };
        public static Piece Rook = new Piece() { Name = "Rook", NotationLetter = 'R' };
        public static Piece Bishop = new Piece() { Name = "Bishop", NotationLetter = 'B' };
        public static Piece Knight = new Piece() { Name = "Knight", NotationLetter = 'N' };
        public static Piece Pawn = new Piece() { Name = "Pawn", NotationLetter = 'P' };
    }
}
