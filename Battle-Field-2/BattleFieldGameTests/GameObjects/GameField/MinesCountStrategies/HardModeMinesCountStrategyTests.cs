namespace BattleFieldGameTests.Keyboard
{
    using System;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BattleFieldGame.GameObjects.GameField.MinesCountStrategies;
    using BattleFieldGame.Keyboard;
    using BattleFieldGame.Keyboard.ConsoleIO;

    [TestClass]
    public class HardModeMinesCountStrategyTests
    {
        [TestMethod]
        public void HardModeMustReturnMineCountInRange()
        {
            var fieldSize = 9;

            var mineMode = new HardModeMinesCountStrategy();
            var outputCellsCount = mineMode.GetMinesCount(fieldSize, new Random());

            int cellsCount = fieldSize * fieldSize;
            int minRange = (int)Math.Floor(0.10 * cellsCount);
            int maxRange = (int)Math.Floor(0.20 * cellsCount);

            Assert.IsTrue(outputCellsCount >= minRange);
            Assert.IsTrue(outputCellsCount <= maxRange);
        }
    }
}
