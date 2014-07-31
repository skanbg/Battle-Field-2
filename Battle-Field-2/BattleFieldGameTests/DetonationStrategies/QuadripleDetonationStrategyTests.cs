namespace BattleFieldGameTests.DetonationStrategies
{
    using BattleFieldGame.DetonationStretegies;
    using BattleFieldGame.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class QuadripleDetonationStrategyTests
    {
        [TestMethod]
        public void QuadripleDetonationStrategyExplosionCoordinatesMustMatchToExpected()
        {
            var expectedExplosionCoordinates = new List<Coords>()
            {
                new Coords(-1, -2),
                new Coords(+1, -2),
                new Coords(-2, -1),
                new Coords(+2, -1),
                new Coords(-2, +1),
                new Coords(+2, +1),
                new Coords(-1, +2),
                new Coords(+1, +2),
            };

            var detonationStrategy = new QuadripleDetonationStrategy();
            var returnedExplosionCoordinates = detonationStrategy.GetExplosionCoordinates();

            CollectionAssert.AreEqual(expectedExplosionCoordinates, returnedExplosionCoordinates);
        }

        [TestMethod]
        public void QuadripleDetonationStrategySettedMinorStrategyMustAlterTheExplosionCoordinates()
        {
            var singleDetonationStrategy = new SingleDetonationStrategy();
            var quadripleDetonationStrategy = new QuadripleDetonationStrategy();

            var expectedCoordinates = quadripleDetonationStrategy.GetExplosionCoordinates().Select(item => new Coords(item.X, item.Y)).ToList();
            var originalSingleDetonationExplosionCoordinates = singleDetonationStrategy.GetExplosionCoordinates().Select(item => new Coords(item.X, item.Y)).ToList();
            expectedCoordinates.AddRange(originalSingleDetonationExplosionCoordinates);

            quadripleDetonationStrategy.MinorStrategy = singleDetonationStrategy;
            var outputCoordinates = quadripleDetonationStrategy.GetExplosionCoordinates();

            CollectionAssert.AreEqual(expectedCoordinates, outputCoordinates);
        }
    }
}
