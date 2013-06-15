using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickAndPlay
{
    public class GameState
    {
        public GameState()
        {
            PlyCount = 0;
            PiecesTaken = 0;
        }

        public int PlyCount { get; set; }
        public bool IsPlayer1Turn {get{return PlyCount % 2 == 0;}}
        public int PiecesTaken { get; set; }
        public Square getDiscardSquare(IEnumerable<Square> squares)
        {
            try {
                if((PiecesTaken/8)<1)
                {
                    return squares.First(square => square.Name == "i" + (1 + PiecesTaken % 8));
                }
                else if ((PiecesTaken / 8) < 2)
                {
                    return squares.First(square => square.Name == "j" + (1 + PiecesTaken % 8));
                }
                else if ((PiecesTaken / 8) < 3)
                {
                    return squares.First(square => square.Name == "k" + (1 + PiecesTaken % 8));
                }
                else
                {
                    return squares.First(square => square.Name == "l" + (1 + PiecesTaken % 8));
                }
            }
            catch { throw new Exception("Couldnt find expexted discard square location."); }
        }
        public void NotifyPieceWasTaken()
        {
            PiecesTaken++;
        }
    }
}
