using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickAndPlay
{
    public class AlgebraicNotatator
    {
        public static ICollection<Square> GetStandardChessSquares(SquareBoard board)
        {
            ICollection<Square> Squares = new List<Square>();
            for (int i = 1; i <= 8; i++)
            {
                Squares.Add(new Square("a" + i, board, XCoordinate(board, 1, i)));
                Squares.Add(new Square("b" + i, board, XCoordinate(board, 2, i)));
                Squares.Add(new Square("c" + i, board, XCoordinate(board, 3, i)));
                Squares.Add(new Square("d" + i, board, XCoordinate(board, 4, i)));
                Squares.Add(new Square("e" + i, board, XCoordinate(board, 5, i)));
                Squares.Add(new Square("f" + i, board, XCoordinate(board, 6, i)));
                Squares.Add(new Square("g" + i, board, XCoordinate(board, 7, i)));
                Squares.Add(new Square("h" + i, board, XCoordinate(board, 8, i)));
            }
            return Squares;
        }
        private static Point XCoordinate(SquareBoard board, int placeFromLeft, int placeFromBottom)
        {
            return new Point(GetCoordinate(board, placeFromLeft),GetCoordinate(board, placeFromBottom));
        }
        private static double GetCoordinate(SquareBoard board, int placeFromOrigin)
        {
            Length CenterAtOriginToFarthestCenter = (board.Width * (board.DivisionsPerSide - 1) / board.DivisionsPerSide);
            return (((board.Width / board.DivisionsPerSide) * (placeFromOrigin-1)) - CenterAtOriginToFarthestCenter / 2).Millimeters;
        }
    }
}
