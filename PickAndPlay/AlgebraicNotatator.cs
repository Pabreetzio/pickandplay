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
            List<Square> Squares = new List<Square>();
            for (int i = 1; i <= 8; i++)
            {
                Squares.AddRange(StandardSquaresForRow(i, board));
                Squares.AddRange(DiscardSquares(i, board));
            }
            return Squares;
        }

        private static IEnumerable<Square> StandardSquaresForRow(int i, SquareBoard board)
        {
            List<Square> squares = new List<Square>();
            squares.Add(new Square("a" + i, board, GetCenterPoint(board, 1, i)));
            squares.Add(new Square("b" + i, board, GetCenterPoint(board, 2, i)));
            squares.Add(new Square("c" + i, board, GetCenterPoint(board, 3, i)));
            squares.Add(new Square("d" + i, board, GetCenterPoint(board, 4, i)));
            squares.Add(new Square("e" + i, board, GetCenterPoint(board, 5, i)));
            squares.Add(new Square("f" + i, board, GetCenterPoint(board, 6, i)));
            squares.Add(new Square("g" + i, board, GetCenterPoint(board, 7, i)));
            squares.Add(new Square("h" + i, board, GetCenterPoint(board, 8, i)));
            return squares;
        }
        
        private static Point GetCenterPoint(SquareBoard board, int placeFromLeft, int placeFromBottom)
        {
            return new Point(GetCoordinate(board, placeFromLeft),GetCoordinate(board, placeFromBottom));
        }
        private static double GetCoordinate(SquareBoard board, int placeFromOrigin)
        {
            Length CenterAtOriginToFarthestCenter = (board.Width * (board.DivisionsPerSide - 1) / board.DivisionsPerSide);
            return (((board.Width / board.DivisionsPerSide) * (placeFromOrigin-1)) - CenterAtOriginToFarthestCenter / 2).Millimeters;
        }

        private static IEnumerable<Square> DiscardSquares(int i, SquareBoard board)
        {
            List<Square> squares = new List<Square>();
            squares.Add(GetLeftDiscardSquare(i, board));
            squares.Add(GetRightDiscardSquare(i, board));
            squares.Add(GetTopDiscardSquare(i, board));
            squares.Add(GetBottomDiscardSquare(i, board));
            return squares;
        }

        private static Square GetLeftDiscardSquare(int i, SquareBoard board)
        {
                Point centerPoint =  new Point(GetCoordinate(board, 0), GetCoordinate(board, i));
                return (new Square("i" + i, board, centerPoint));
        }

        private static Square GetRightDiscardSquare(int i, SquareBoard board)
        {
            Point centerPoint = new Point(GetCoordinate(board, 9), GetCoordinate(board, i));
            return (new Square("j" + i, board, centerPoint));
        }

        private static Square GetTopDiscardSquare(int i, SquareBoard board)
        {
            Point centerPoint = new Point(GetCoordinate(board, i), GetCoordinate(board, 9));
            return (new Square("k" + i, board, centerPoint));
        }

        private static Square GetBottomDiscardSquare(int i, SquareBoard board)
        {
            Point centerPoint = new Point(GetCoordinate(board, i), GetCoordinate(board, 0));
            return (new Square("l" + i, board, centerPoint));
        }

    }
}
