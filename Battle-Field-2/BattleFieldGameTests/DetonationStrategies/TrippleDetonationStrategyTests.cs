namespace BattleFieldGameTests.DetonationStrategies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BattleFieldGame.DetonationStretegies;
    using BattleFieldGame.Helpers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TrippleDetonationStrategyTests
    {
        [TestMethod]
        public void TrippleDetonationStrategyExplosionCoordinatesMustMatchToExpected()
        {
            var expectedExplosionCoordinates = new List<Coords>()
            {
                new Coords(0, -2),
                new Coords(-2, 0),
                new Coords(+2, 0),
                new Coords(0, +2)
            };

            var detonationStrategy = new TripleDetonationStretegy();
            var returnedExplosionCoordinates = detonationStrategy.GetExplosionCoordinates();

            CollectionAssert.AreEqual(expectedExplosionCoordinates, returnedExplosionCoordinates);
        }

        [TestMethod]
        public void TrippleDetonationStrategySettedMinorStrategyMustAlterTheExplosionCoordinates()
        {
            var singleDetonationStrategy = new SingleDetonationStrategy();
            var trippleDetonationStrategy = new TripleDetonationStretegy();

            var expectedCoordinates = trippleDetonationStrategy.GetExplosionCoordinates().Select(item => new Coords(item.X, item.Y)).ToList();
            var originalSingleDetonationExplosionCoordinates = singleDetonationStrategy.GetExplosionCoordinates().Select(item => new Coords(item.X, item.Y)).ToList();
            expectedCoordinates.AddRange(originalSingleDetonationExplosionCoordinates);

            trippleDetonationStrategy.MinorStrategy = singleDetonationStrategy;
            var outputCoordinates = trippleDetonationStrategy.GetExplosionCoordinates();

            CollectionAssert.AreEqual(expectedCoordinates, outputCoordinates);
        }
    }
}
