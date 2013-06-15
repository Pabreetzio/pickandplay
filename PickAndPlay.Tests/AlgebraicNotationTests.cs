using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace PickAndPlay.Tests
{
    [TestClass]
    public class AlgebraicNotationTests
    {
        [TestMethod]
        public void GetCoordsForA1()
        {
            SquareBoard myBoard = new SquareBoard(112);
            List<Square> squares = AlgebraicNotatator.GetStandardChessSquares(myBoard).ToList();
            Point A1SquareCenter = squares.Find(s => s.Name == "a1").Center;
            Assert.AreEqual(-49, A1SquareCenter.X);
            Assert.AreEqual(-49, A1SquareCenter.Y);
        }

        [TestMethod]
        public void GetCoordsForE6()
        {
            SquareBoard myBoard = new SquareBoard(112);
            List<Square> squares = AlgebraicNotatator.GetStandardChessSquares(myBoard).ToList();
            Point A1SquareCenter = squares.Find(s => s.Name == "e6").Center;
            Assert.AreEqual(7, A1SquareCenter.X);
            Assert.AreEqual(21, A1SquareCenter.Y);
        }
    }
}
