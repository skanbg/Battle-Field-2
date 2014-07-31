namespace BattleFieldGameTests
{
    using System;
    using System.IO;
    using BattleFieldGame.DetonationStretegies;
    using BattleFieldGame.GameObjects.FieldTiles;
    using BattleFieldGame.Helpers;
    using BattleFieldGame.Keyboard.ConsoleIO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ConsoleWriterTests
    {
        [TestMethod]
        public void GetMineSymbolMustReturnOne()
        {
            var consoleWriter = new ConsoleWriter();
            var detonationType = MineDetonationType.Single;
            var detonationStrategy = new DetonationStrategyFactory().GetDetonationStrategy(detonationType);
            var mine = new MineTile(detonationType, detonationStrategy);
            Assert.AreEqual(consoleWriter.GetMineSymbol(mine), '1');
        }

        [TestMethod]
        public void GetMineSymbolMustReturnTwo()
        {
            var consoleWriter = new ConsoleWriter();
            var detonationType = MineDetonationType.Double;
            var detonationStrategy = new DetonationStrategyFactory().GetDetonationStrategy(detonationType);
            var mine = new MineTile(detonationType, detonationStrategy);
            Assert.AreEqual(consoleWriter.GetMineSymbol(mine), '2');
        }

        [TestMethod]
        public void GetMineSymbolMustReturnTriple()
        {
            var consoleWriter = new ConsoleWriter();
            var detonationType = MineDetonationType.Triple;
            var detonationStrategy = new DetonationStrategyFactory().GetDetonationStrategy(detonationType);
            var mine = new MineTile(detonationType, detonationStrategy);
            Assert.AreEqual(consoleWriter.GetMineSymbol(mine), '3');
        }

        [TestMethod]
        public void GetMineSymbolMustReturnQuadriple()
        {
            var consoleWriter = new ConsoleWriter();
            var detonationType = MineDetonationType.Quadriple;
            var detonationStrategy = new DetonationStrategyFactory().GetDetonationStrategy(detonationType);
            var mine = new MineTile(detonationType, detonationStrategy);
            Assert.AreEqual(consoleWriter.GetMineSymbol(mine), '4');
        }

        [TestMethod]
        public void GetMineSymbolMustReturnQuintuple()
        {
            var consoleWriter = new ConsoleWriter();
            var detonationType = MineDetonationType.Quintuple;
            var detonationStrategy = new DetonationStrategyFactory().GetDetonationStrategy(detonationType);
            var mine = new MineTile(detonationType, detonationStrategy);
            Assert.AreEqual(consoleWriter.GetMineSymbol(mine), '5');
        }
    }
}
