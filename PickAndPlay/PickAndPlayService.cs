using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickAndPlay
{
    public class PickAndPlayService
    {
        #region private fields
        PickAndPlaySettings Settings;
        SquareBoard Board;
        IEnumerable<Square> Squares;
        GameState State;
        #endregion

        public GCoderSender Sender {get;set;}

        public PickAndPlayService(PickAndPlaySettings settings)
        {
            Settings = settings;
            Board = new SquareBoard(settings.BoardSize);
            Squares = AlgebraicNotatator.GetStandardChessSquares(Board);
            Sender = new GCoderSender();
            Sender.Start();
            Sender.SendHome();
            Sender.SetSepeed(Settings.Speed);
            State = new GameState();
        }

        public void IssueMove(string move){
            IssueGCodeCommands(GetMove(move));
            State.PlyCount++;
        }

        public Move GetMove(string moveString)
        {
            Move move = new Move();
            ////Nc1-Nd3
            if (isCapture(moveString))
            {
                List<string> captureMoveString = moveString.Split(new Char[] { 'x' }).ToList();
                Piece capturingPiece = getPiece(captureMoveString[0]);
                Square capturingPieceStartingSquare = getSquare(captureMoveString[0]);
                Piece capturedPiece = getPiece(captureMoveString[1]);
                Square capturedOnSquare = getSquare(captureMoveString[1]);
                SimpleMove removeCapturedPiece = new SimpleMove() 
                    {Piece = capturedPiece, StartingSquare = capturedOnSquare, EndingSquare = State.getDiscardSquare(Squares)};
                SimpleMove moveToCapturedSquare = new SimpleMove()
                    { Piece = capturingPiece, StartingSquare = capturingPieceStartingSquare, EndingSquare = capturedOnSquare };
                move.addMove(removeCapturedPiece);
                State.NotifyPieceWasTaken();
                move.addMove(moveToCapturedSquare);
            }
            else if (isCastle(moveString))
            {
                    move = GetCastleMove(moveString);
            }
            else
            {
                Piece piece = getPiece(moveString);
                List<Square> squares = getSquares(moveString);
                 move.addMove(piece, squares[0], squares[1] );
            }
              
            return move;
        }

        private Move GetCastleMove(string moveString)
        {
            string castleRowForPlayer = State.IsPlayer1Turn ? "1" : "8";
            SimpleMove castleToKing;
            SimpleMove kingThroughCastle;
            if (IsQueenSideCastle(moveString))
            {
                castleToKing = new SimpleMove() { Piece = getPiece("R"), StartingSquare = getSquare("a" + castleRowForPlayer), EndingSquare = getSquare("d" + castleRowForPlayer) };
                kingThroughCastle = new SimpleMove() { Piece = getPiece("K"), StartingSquare = getSquare("e" + castleRowForPlayer), EndingSquare = getSquare("c" + castleRowForPlayer) };
            }
            else
            {
                castleToKing = new SimpleMove() { Piece = getPiece("R"), StartingSquare = getSquare("h" + castleRowForPlayer), EndingSquare = getSquare("f" + castleRowForPlayer) };
                kingThroughCastle = new SimpleMove() { Piece = getPiece("K"), StartingSquare = getSquare("e" + castleRowForPlayer), EndingSquare = getSquare("g" + castleRowForPlayer) };
            }
            return new Move() { SimpleMoves = new List<SimpleMove> { castleToKing, kingThroughCastle } };
        }

        private bool IsQueenSideCastle(string moveString)
        {
            return (moveString == "0-0-0" || moveString == "O-O-O");
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
            Sender.GoTo(move.StartingSquare.Center.X, move.StartingSquare.Center.Y, Settings.LiftHeight);
            System.Threading.Thread.Sleep(Settings.MoveWait);
            Sender.GoTo(move.StartingSquare.Center.X, move.StartingSquare.Center.Y, Settings.PieceHeight);
            System.Threading.Thread.Sleep(Settings.DropWait);
            Sender.Pick();
            System.Threading.Thread.Sleep(Settings.MoveWait);
            Sender.GoTo(move.StartingSquare.Center.X, move.StartingSquare.Center.Y, Settings.LiftHeight);
            System.Threading.Thread.Sleep(Settings.MoveWait);
            Sender.GoTo(move.EndingSquare.Center.X, move.EndingSquare.Center.Y, Settings.LiftHeight);
            System.Threading.Thread.Sleep(Settings.MoveWait);
            Sender.GoTo(move.EndingSquare.Center.X, move.EndingSquare.Center.Y, Settings.PieceHeight);
            System.Threading.Thread.Sleep(Settings.MoveWait);
            Sender.Play();
            System.Threading.Thread.Sleep(Settings.DropWait);
            Sender.GoTo(move.EndingSquare.Center.X, move.EndingSquare.Center.Y, Settings.LiftHeight);
            System.Threading.Thread.Sleep(Settings.MoveWait);
            
        }

        public void TestPosition(string squareString)
        {
            Square squareToMoveTo = null;
            foreach (Square square in Squares)
            {
                if (square.Name == squareString)
                {
                    squareToMoveTo = square;
                }
            }
            if (squareToMoveTo != null)
            {
                Sender.GoTo(squareToMoveTo.Center.X, squareToMoveTo.Center.Y, Settings.PieceHeight);
            }
            else
            {
                throw new Exception("Could not find square.");
            }
        }

        #region GetMove helpers

        private bool isCapture(string move)
        {
            return move.Contains('x');
        }

        private bool isCastle(string move)
        {
            return (move.Contains('0') || move.Contains('O'));
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

        ~PickAndPlayService()
        {
            Sender.SendHome();
            Sender.MotorsOff();
            Sender.Disconnect();
        }

    }
}
