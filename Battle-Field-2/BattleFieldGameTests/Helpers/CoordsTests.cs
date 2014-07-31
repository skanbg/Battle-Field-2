using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BattleFieldGame.Helpers;

namespace BattleFieldGameTests
{
    [TestClass]
    public class CoordsTests
    {
        [TestMethod]
        public void TestCoordinatesClassPropertyAssignment()
        {
            int xCoord = 5;
            int yCoord = 10;
            var coords = new Coords(xCoord, yCoord);
            Assert.AreEqual(coords.X, xCoord);
            Assert.AreEqual(coords.Y, yCoord);
        }
    }
}
