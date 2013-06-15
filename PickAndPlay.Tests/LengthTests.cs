using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PickAndPlay.Tests
{
    [TestClass]
    public class LengthTests
    {
        [TestMethod]
        public void DivisionTests()
        {
            Length l1 = new Length(30);
            Length l2 = new Length(6);
            Length l3 = (l1 / l2);
            Assert.AreEqual(new Length(5), l3);
        }

        [TestMethod]
        public void DivisionAgainstDoubleTest()
        {
            Length l1 = new Length(35);
            double d1 = 7;
            Assert.AreEqual(new Length(5), l1 / d1);
        }
        [TestMethod]
        public void dobuleDivisionAgainstLength()
        {
            double d1 = 35;
            Length l1 = new Length(7);
            Assert.AreEqual(new Length(5), d1 / l1);
        }

    }
}
