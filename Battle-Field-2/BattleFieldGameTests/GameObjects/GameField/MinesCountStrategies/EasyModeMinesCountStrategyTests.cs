namespace BattleFieldGameTests.Keyboard
{
    using System;
    using System.IO;
    using BattleFieldGame.GameObjects.GameField.MinesCountStrategies;
    using BattleFieldGame.Keyboard;
    using BattleFieldGame.Keyboard.ConsoleIO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class EasyModeMinesCountStrategyTests
    {
        [TestMethod]
        public void EasyModeMinesMustReturnMineCountInRange()
        {
            var fieldSize = 9;

            var mineMode = new EasyModeMinesCountStrategy();
            var outputCellsCount = mineMode.GetMinesCount(fieldSize, new Random());

            int cellsCount = fieldSize * fieldSize;
            int minRange = (int)Math.Floor(0.30 * cellsCount);
            int maxRange = (int)Math.Floor(0.45 * cellsCount);

            Assert.IsTrue(outputCellsCount >= minRange);
            Assert.IsTrue(outputCellsCount <= maxRange);
        }
    }
}
