namespace BattleFieldGameTests.Keyboard
{
    using System;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BattleFieldGame.GameObjects.GameField.MinesCountStrategies;
    using BattleFieldGame.Keyboard;
    using BattleFieldGame.Keyboard.ConsoleIO;

    [TestClass]
    public class NormalModeMinesCountStrategyTests
    {
        [TestMethod]
        public void NormalModeMustReturnMineCountInRange()
        {
            var fieldSize = 9;

            var mineMode = new NormalModeMinesCountStrategy();
            var outputCellsCount = mineMode.GetMinesCount(fieldSize, new Random());

            int cellsCount = fieldSize * fieldSize;
            int minRange = (int)Math.Floor(0.15 * cellsCount);
            int maxRange = (int)Math.Floor(0.30 * cellsCount);

            Assert.IsTrue(outputCellsCount >= minRange);
            Assert.IsTrue(outputCellsCount <= maxRange);
        }
    }
}
