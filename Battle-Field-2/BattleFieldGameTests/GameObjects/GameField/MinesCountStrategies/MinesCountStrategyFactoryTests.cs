namespace BattleFieldGameTests.Keyboard
{
    using System;
    using System.IO;
    using BattleFieldGame.GameObjects.GameField.MinesCountStrategies;
    using BattleFieldGame.Keyboard;
    using BattleFieldGame.Keyboard.ConsoleIO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MinesCountStrategyFactoryTests
    {
        [TestMethod]
        public void MinesCountFactoryMustReturnEasyModeMines()
        {
            var minesCountStrategyFactory = new MinesCountStrategyFactory();
            Assert.IsInstanceOfType(minesCountStrategyFactory.GetEasy(), typeof(EasyModeMinesCountStrategy));
        }

        [TestMethod]
        public void MinesCountFactoryMustReturnNormalModeMines()
        {
            var minesCountStrategyFactory = new MinesCountStrategyFactory();
            Assert.IsInstanceOfType(minesCountStrategyFactory.GetNormal(), typeof(NormalModeMinesCountStrategy));
        }

        [TestMethod]
        public void MinesCountFactoryMustReturnHardModeMines()
        {
            var minesCountStrategyFactory = new MinesCountStrategyFactory();
            Assert.IsInstanceOfType(minesCountStrategyFactory.GetHard(), typeof(HardModeMinesCountStrategy));
        }
    }
}
