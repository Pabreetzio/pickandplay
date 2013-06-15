using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickAndPlay
{
    public class Move
    {
        public List<SimpleMove> SimpleMoves;
        public Move()
        { 
            SimpleMoves = new List<SimpleMove>();
        }
        public void addMove(Piece piece, Square startingSquare, Square endingSquare) 
        {
            SimpleMoves.Add
                (
                    new SimpleMove()
                    {
                        Piece = piece,
                        StartingSquare = startingSquare,
                        EndingSquare = endingSquare
                    }
                );
        }
        public void addMove(SimpleMove simpleMove)
        {
            SimpleMoves.Add(simpleMove);
        }

    }
}
