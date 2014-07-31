namespace BattleFieldGameTests
{
    using BattleFieldGame.Keyboard.ConsoleIO;
    using BattleFieldGame.GameObjects.GameField;
    using System;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GameFieldFactoryTests
    {
        [TestMethod]
        public void GetGameFieldMustReturnMatrixIfTypeIsNotSet()
        {
            var gameFieldFactory = new GameFieldFactory();
            var gameField = gameFieldFactory.GetGameField(9);
            Assert.IsInstanceOfType(gameField, typeof(GameField));
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void GameFieldMustThrowExceptionForCircleType()
        {
            var gameFieldFactory = new GameFieldFactory();
            gameFieldFactory.GetGameField(9, GameFieldType.Circle);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void GameFieldMustThrowExceptionForSquareType()
        {
            var gameFieldFactory = new GameFieldFactory();
            gameFieldFactory.GetGameField(9, GameFieldType.Square);
        }
    }
}
