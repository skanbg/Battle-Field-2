namespace BattleFieldGameTests.DetonationStrategies
{
    using BattleFieldGame.DetonationStretegies;
    using BattleFieldGame.Helpers;
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DetonationStrategyFactoryTests
    {
        [TestMethod]
        public void DetonationStrategyFactoryMustReturnSingleDestionationStrategy()
        {
            var detonationStrategyFactory = new DetonationStrategyFactory();
            var singleStrategy = detonationStrategyFactory.GetDetonationStrategy(MineDetonationType.Single);

            Assert.IsInstanceOfType(singleStrategy, typeof(SingleDetonationStrategy));
        }

        [TestMethod]
        public void DetonationStrategyFactoryMustReturnDoubleDestionationStrategy()
        {
            var detonationStrategyFactory = new DetonationStrategyFactory();
            var doubleStrategy = detonationStrategyFactory.GetDetonationStrategy(MineDetonationType.Double);

            Assert.IsInstanceOfType(doubleStrategy, typeof(DoubleDetonationStrategy));
        }

        [TestMethod]
        public void DetonationStrategyFactoryMustReturnTrippleDestionationStrategy()
        {
            var detonationStrategyFactory = new DetonationStrategyFactory();
            var trippleStrategy = detonationStrategyFactory.GetDetonationStrategy(MineDetonationType.Triple);

            Assert.IsInstanceOfType(trippleStrategy, typeof(TripleDetonationStretegy));
        }

        [TestMethod]
        public void DetonationStrategyFactoryMustReturnQuadripleDestionationStrategy()
        {
            var detonationStrategyFactory = new DetonationStrategyFactory();
            var quadrippleStrategy = detonationStrategyFactory.GetDetonationStrategy(MineDetonationType.Quadriple);

            Assert.IsInstanceOfType(quadrippleStrategy, typeof(QuadripleDetonationStrategy));
        }

        [TestMethod]
        public void DetonationStrategyFactoryMustReturnQuintupleDestionationStrategy()
        {
            var detonationStrategyFactory = new DetonationStrategyFactory();
            var quintupleStrategy = detonationStrategyFactory.GetDetonationStrategy(MineDetonationType.Quintuple);

            Assert.IsInstanceOfType(quintupleStrategy, typeof(QuintupleDetonationStrategy));
        }

        //[TestMethod]
        //public void DetonationStrategyFactoryMustThrowErrorWithNullParameter()
        //{
        //    var detonationStrategyFactory = new DetonationStrategyFactory();
        //    dynamic something;
        //    detonationStrategyFactory.GetDetonationStrategy(something);
        //}
    }
}
