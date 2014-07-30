namespace BattleFieldGameTests
{
    using BattleFieldGame.DetonationStretegies;
    using BattleFieldGame.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DoubleDetonationStrategyTests
    {
        [TestMethod]
        public void DoubleDetonationStrategyExplosionCoordinatesMustMatchToExpected()
        {
            var expectedExplosionCoordinates = new List<Coords>()
            {
                new Coords(0, -1),
                new Coords(-1, 0),
                new Coords(+1, 0),
                new Coords(0, +1)
            };

            var doubleDetonationStrategy = new DoubleDetonationStrategy();
            var returnedExplosionCoordinates = doubleDetonationStrategy.GetExplosionCoordinates();

            CollectionAssert.AreEqual(expectedExplosionCoordinates, returnedExplosionCoordinates);
        }

        [TestMethod]
        public void DoubleDetonationStrategySettedMinorStrategyMustAlterTheExplosionCoordinates()
        {
            var singleDetonationStrategy = new SingleDetonationStrategy();
            var doubleDetonationStrategy = new DoubleDetonationStrategy();

            var expectedCoordinates = doubleDetonationStrategy.GetExplosionCoordinates().Select(item => new Coords(item.X, item.Y)).ToList();
            var originalDoubleDetonationExplosionCoordinates = singleDetonationStrategy.GetExplosionCoordinates().Select(item => new Coords(item.X, item.Y)).ToList();
            expectedCoordinates.AddRange(originalDoubleDetonationExplosionCoordinates);

            doubleDetonationStrategy.MinorStrategy = singleDetonationStrategy;
            var outputCoordinates = doubleDetonationStrategy.GetExplosionCoordinates();

            CollectionAssert.AreEqual(expectedCoordinates, outputCoordinates);
        }
    }
}
