using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickAndPlay
{
    public class PiecePlacer
    {
        public static ICollection<PiecePlacement> PlaceStandardChessPeices
            (SquareBoard board, Player player1, Player player2)
        {
            ICollection<PiecePlacement> placedPieces = new List<PiecePlacement>();
            ICollection<Square> squares = AlgebraicNotatator.GetStandardChessSquares(board);

            return placedPieces;
        }
    }
}
