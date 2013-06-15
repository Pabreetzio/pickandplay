using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickAndPlay
{
    public class ReversibleNotationToGCodeService
    {
        #region private fields
        PickAndPlaySettings Settings;
        SquareBoard Board;
        IEnumerable<Square> Squares;
        GCoderSender Sender;
        #endregion

        public ReversibleNotationToGCodeService(PickAndPlaySettings settings)
        {
            Settings = settings;
            Board = new SquareBoard(settings.BoardSize);
            Squares = AlgebraicNotatator.GetStandardChessSquares(Board);
            Sender = new GCoderSender();
            Sender.Start();
            Sender.SendHome();
            Sender.SetSepeed(Settings.Speed);
        }

        public void IssueMove(string move){
            IssueGCodeCommands(GetMove(move));
        }

        public Move GetMove(string moveString)
        {
            Move move = new Move();
            ////Nc1-Nd3
            if (isCapture(moveString))
            {

            }
            else if (isCastle(moveString))
            {
            }
            else
            {
                Piece piece = getPiece(moveString);
                List<Square> squares = getSquares(moveString);
                 move.addMove(piece, squares[0], squares[1] );
            }
              
            return move;
        }

        public void IssueGCodeCommands(Move move)
        {
            foreach (SimpleMove simpleMove in move.SimpleMoves)
            {
               IssueGCodeCommands(simpleMove);
            }
        }

        public void IssueGCodeCommands(SimpleMove move)
        {
            int sleepLength = 2000;
            Sender.GoTo(move.StartingSquare.Center.X, move.StartingSquare.Center.Y, Settings.LiftHeight);
            System.Threading.Thread.Sleep(sleepLength);
            Sender.GoTo(move.StartingSquare.Center.X, move.StartingSquare.Center.Y, Settings.PieceHeight);
            System.Threading.Thread.Sleep(sleepLength);
            Sender.Pick();
            System.Threading.Thread.Sleep(sleepLength);
            Sender.GoTo(move.StartingSquare.Center.X, move.StartingSquare.Center.Y, Settings.LiftHeight);
            System.Threading.Thread.Sleep(sleepLength);
            Sender.GoTo(move.EndingSquare.Center.X, move.EndingSquare.Center.Y, Settings.PieceHeight);
            System.Threading.Thread.Sleep(sleepLength);
            Sender.Play();
            System.Threading.Thread.Sleep(sleepLength);
            Sender.GoTo(move.EndingSquare.Center.X, move.EndingSquare.Center.Y, Settings.LiftHeight);
            System.Threading.Thread.Sleep(sleepLength);
            Sender.SendHome();
            System.Threading.Thread.Sleep(sleepLength);
        }

        #region GetMove helpers

        private bool isCapture(string move)
        {
            return move.Contains('x');
        }

        private bool isCastle(string move)
        {
            return move.Contains('0');
        }

        private Piece getPiece(string move)
        {
            foreach (Piece piece in StandardChessSet.Set)
            {
                if (move.Contains(piece.NotationLetter) || move.Contains(piece.NotationSymbol))
                {
                    return piece;
                }
            }
            return StandardChessPiece.Pawn;
        }

        private char getPieceCharacter(string move)
        {
            foreach (Piece piece in StandardChessSet.Set)
            {
                if (move.Contains(piece.NotationLetter) )
                {
                    return piece.NotationLetter;
                }
                else if (move.Contains(piece.NotationSymbol))
                {
                    return piece.NotationSymbol;
                }
            }
            throw new Exception("Could not determine piece character.");
        }

        private List<Square> getSquares(string move)
        {
            List<Square> squares = new List<Square>();
            IEnumerable<string> squareStrings = move.Split(new Char[] { '-' });
            foreach (string squareString in squareStrings)
            {
                squares.Add(getSquare(squareString));
            }
            return squares;
        }

        private Square getSquare(string squareString)
        {
            foreach (Square square in Squares)
            {
                if(squareString.Contains(square.Name))
                {
                    return square;
                }
            }
            throw new Exception("Could not find the square specified in your move");
        }

        #endregion

    }
}
