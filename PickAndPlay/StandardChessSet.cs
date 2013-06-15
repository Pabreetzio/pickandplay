using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickAndPlay
{
    class StandardChessSet
    {
        
        public static Piece WhiteKing = new Piece(StandardChessPiece.King) { Side = StandardSide.White, NotationSymbol = '♔' };
        public static Piece WhiteQueen = new Piece(StandardChessPiece.Queen) { Side = StandardSide.White, NotationSymbol = '♕' };
        public static Piece WhiteRook = new Piece(StandardChessPiece.Rook) { Side = StandardSide.White, NotationSymbol = '♖' };
        public static Piece WhiteBishop = new Piece(StandardChessPiece.Bishop) { Side = StandardSide.White, NotationSymbol = '♗' };
        public static Piece WhiteKnight = new Piece(StandardChessPiece.Knight) { Side = StandardSide.White, NotationSymbol = '♘' };
        public static Piece WhitePawn = new Piece(StandardChessPiece.Pawn) { Side = StandardSide.White, NotationSymbol = '♙' };

        public static Piece BlackKing = new Piece(StandardChessPiece.King) { Side = StandardSide.Black, NotationSymbol = '♚' };
        public static Piece BlackQueen = new Piece(StandardChessPiece.Queen) { Side = StandardSide.Black, NotationSymbol = '♛' };
        public static Piece BlackRook = new Piece(StandardChessPiece.Rook) { Side = StandardSide.Black, NotationSymbol = '♜' };
        public static Piece BlackBishop = new Piece(StandardChessPiece.Bishop) { Side = StandardSide.Black, NotationSymbol = '♝' };
        public static Piece BlackKnight = new Piece(StandardChessPiece.Knight) { Side = StandardSide.Black, NotationSymbol = '♞' };
        public static Piece BlackPawn = new Piece(StandardChessPiece.Pawn) { Side = StandardSide.Black, NotationSymbol = '♟' };

        public static List<Piece> Set = new List<Piece>() { WhiteKing, WhiteQueen, WhiteRook, WhiteBishop, WhiteKnight, WhitePawn,
            BlackKing, BlackQueen, BlackRook, BlackBishop, BlackKnight,BlackPawn };
    }

}
