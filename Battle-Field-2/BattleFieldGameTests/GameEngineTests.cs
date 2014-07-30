namespace BattleFieldGameTests
{
    using System;
    using BattleFieldGame;
    using BattleFieldGame.Engine;
    using BattleFieldGame.Keyboard;
    using BattleFieldGame.Keyboard.ConsoleIO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BattleFieldGame.GameObjects.GameField;

    [TestClass]
    public class GameEngineTests
    {
        [TestMethod]
        public void GameEnginMastBeCreatedWhitNullIGameFieldObject()
        {
            var commandReader = new FakeCommandReader();

            var engine = new GameEngine(commandReader, new ConsoleWriter(), null);

            Assert.IsNotNull(engine, "Engine mast not be null");
        }

        [TestMethod]
        public void GameEnginMastBeCreatedWithNullCommandReader()
        {
            var engine = new GameEngine(new CommandReader(new ConsoleReader()), new ConsoleWriter(), new GameField(5));

            Assert.IsNotNull(engine, "Engine mast not be null");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GameEngineWhitNullIConsoleWriterSholdThrowAnException()
        {
            var engine = new GameEngine(new CommandReader(new ConsoleReader()), null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GameEngineWhitNullICommandReaderSholdThrowAnException()
        {
            var engine = new GameEngine(null, new ConsoleWriter());
        }

        [TestMethod]
        public void MethodStartBattleFieldGameMastHaveEnd()
        {
            var commandReader = new FakeCommandReader();

            var engine = new GameEngine(commandReader, new ConsoleWriter(), null);

            engine.StartBattleFieldGame();

            //Assert.IsTrue(true, "Engine mast not be null");
        }

        class FakeCommandReader : ICommandReader
        {
            private int row = -2;
            private int col = -2;
            private int size = -2;

            public int[] GetCordinates()
            {
                if (this.row < 1 && this.col < 1)
                {
                    this.row++;
                    this.col++;
                }

                return new int[] { this.row, this.col };
            }

            public int GetFieldSize()
            {
                this.size++;

                if (this.size < 0)
                {
                    throw new ArgumentException();
                }

                return this.size;
            }
        }

    }
}
