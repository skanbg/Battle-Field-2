namespace BattleFieldGameTests.Keyboard
{
    using System;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BattleFieldGame.Engine;
    using BattleFieldGame.Keyboard;
    using BattleFieldGame.Keyboard.ConsoleIO;

    [TestClass]
    public class GameEngineFactoryTests
    {
        [TestMethod]
        public void GameEngineFactoryMustReturnKeyboardTypeIfNothingIsChosen()
        {
            var fieldSize = "9";
            var gameEngineFactory = new GameEngineFactory();
            var fieldSizeReader = new StringReader(fieldSize);
            Console.SetIn(fieldSizeReader);
            var instance = gameEngineFactory.GetGameEngine();

            Assert.IsInstanceOfType(instance, typeof(GameEngine));
        }

        [TestMethod]
        public void GameEngineFactoryMustReturnKeyboardType()
        {
            var fieldSize = "9";
            var gameEngineFactory = new GameEngineFactory();
            var fieldSizeReader = new StringReader(fieldSize);
            Console.SetIn(fieldSizeReader);
            var instance = gameEngineFactory.GetGameEngine(GameEngineType.Keyboard);

            Assert.IsInstanceOfType(instance, typeof(GameEngine));
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void GameEngineFactoryMustThrowExceptionForMouserType()
        {
            var gameEngineFactory = new GameEngineFactory();
            gameEngineFactory.GetGameEngine(GameEngineType.Mouse);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void GameEngineFactoryMustThrowExceptionForTouchType()
        {
            var gameEngineFactory = new GameEngineFactory();
            gameEngineFactory.GetGameEngine(GameEngineType.Touch);
        }
    }
}
