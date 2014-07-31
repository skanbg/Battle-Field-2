namespace BattleFieldGameTests
{
    using System;
    using BattleFieldGame.Helpers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CoordsTests
    {
        [TestMethod]
        public void TestCoordinatesClassPropertyAssignment()
        {
            int coordX = 5;
            int coordY = 10;
            var coords = new Coords(coordX, coordY);
            Assert.AreEqual(coords.X, coordX);
            Assert.AreEqual(coords.Y, coordY);
        }
    }
}
