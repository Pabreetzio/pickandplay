using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickAndPlay
{
    public class Square
    {
        public string Name { get; set; }
        public SquareBoard Board { get; set; }
        public Length Width { get; set; }
        public Length Length { get { return Width; } }
        public Point Center {get;set;}
        public Square(string name, SquareBoard board)
        {
            Name = name;
            Board = board;
            Length boardWidth = Board.Width;
            Width = boardWidth / Board.DivisionsPerSide;
        }
        public Square(string name, SquareBoard board, Point center) : this(name, board)
        {
            Center = center;
        }
    }
}
