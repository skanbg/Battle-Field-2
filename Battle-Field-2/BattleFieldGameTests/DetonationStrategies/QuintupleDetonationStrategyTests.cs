namespace BattleFieldGameTests.DetonationStrategies
{
    using BattleFieldGame.DetonationStretegies;
    using BattleFieldGame.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class QuintupleDetonationStrategyTests
    {
        [TestMethod]
        public void QuintupleDetonationStrategyExplosionCoordinatesMustMatchToExpected()
        {
            var expectedExplosionCoordinates = new List<Coords>()
            {
                new Coords(-2, -2),
                new Coords(+2, -2),
                new Coords(-2, +2),
                new Coords(+2, +2)
            };

            var detonationStrategy = new QuintupleDetonationStrategy();
            var returnedExplosionCoordinates = detonationStrategy.GetExplosionCoordinates();

            CollectionAssert.AreEqual(expectedExplosionCoordinates, returnedExplosionCoordinates);
        }

        [TestMethod]
        public void QuintupleDetonationStrategySettedMinorStrategyMustAlterTheExplosionCoordinates()
        {
            var singleDetonationStrategy = new SingleDetonationStrategy();
            var quintupleDetonationStrategy = new QuintupleDetonationStrategy();

            var expectedCoordinates = quintupleDetonationStrategy.GetExplosionCoordinates().Select(item => new Coords(item.X, item.Y)).ToList();
            var originalSingleDetonationExplosionCoordinates = singleDetonationStrategy.GetExplosionCoordinates().Select(item => new Coords(item.X, item.Y)).ToList();
            expectedCoordinates.AddRange(originalSingleDetonationExplosionCoordinates);

            quintupleDetonationStrategy.MinorStrategy = singleDetonationStrategy;
            var outputCoordinates = quintupleDetonationStrategy.GetExplosionCoordinates();

            CollectionAssert.AreEqual(expectedCoordinates, outputCoordinates);
        }
    }
}
