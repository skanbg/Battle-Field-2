namespace BattleFieldGameTests.DetonationStrategies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BattleFieldGame.DetonationStretegies;
    using BattleFieldGame.Helpers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SingleDetonationStrategyTests
    {
        [TestMethod]
        public void SingleDetonationStrategyExplosionCoordinatesMustMatchToExpected()
        {
            var expectedExplosionCoordinates = new List<Coords>()
            {
                new Coords(-1, -1),
                new Coords(+1, -1),
                new Coords(-1, +1),
                new Coords(+1, +1)
            };

            var singleDetonationStrategy = new SingleDetonationStrategy();
            var returnedExplosionCoordinates = singleDetonationStrategy.GetExplosionCoordinates();

            CollectionAssert.AreEqual(expectedExplosionCoordinates, returnedExplosionCoordinates);
        }

        [TestMethod]
        public void SingleDetonationStrategySettedMinorStrategyMustAlterTheExplosionCoordinates()
        {
            var singleDetonationStrategy = new SingleDetonationStrategy();
            var doubleDetonationStrategy = new DoubleDetonationStrategy();

            var expectedCoordinates = singleDetonationStrategy.GetExplosionCoordinates().Select(item => new Coords(item.X, item.Y)).ToList();
            var originalDoubleDetonationExplosionCoordinates = doubleDetonationStrategy.GetExplosionCoordinates().Select(item => new Coords(item.X, item.Y)).ToList();
            expectedCoordinates.AddRange(originalDoubleDetonationExplosionCoordinates);

            singleDetonationStrategy.MinorStrategy = doubleDetonationStrategy;
            var outputCoordinates = singleDetonationStrategy.GetExplosionCoordinates();

            CollectionAssert.AreEqual(expectedCoordinates, outputCoordinates);
        }
    }
}
