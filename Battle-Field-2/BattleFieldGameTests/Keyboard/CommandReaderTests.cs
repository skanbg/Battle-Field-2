namespace BattleFieldGameTests.Keyboard
{
    using System;
    using System.IO;
    using BattleFieldGame.Keyboard;
    using BattleFieldGame.Keyboard.ConsoleIO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CommandReaderTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CommandReaderMustThrowNullException()
        {
            new CommandReader(null);
        }

        [TestMethod]
        public void GetCoordinatesMustReturnTheCorrectParsedCoordinates()
        {
            var expectedCoordinates = new int[2] { 9, 5 };
            var inputString = "9 5";

            var consoleReader = new ConsoleReader();
            var commandReader = new CommandReader(consoleReader);

            var insertedInput = new StringReader(inputString);
            Console.SetIn(insertedInput);
            var outputCoordinates = commandReader.GetCordinates();

            CollectionAssert.AreEqual(expectedCoordinates, outputCoordinates);
        }

        [TestMethod]
        public void GetFieldSizeMustReturnTheCorrectParsedCoordinates()
        {
            var inputString = "9";
            var expectedFieldSize = int.Parse(inputString);

            var consoleReader = new ConsoleReader();
            var commandReader = new CommandReader(consoleReader);

            var insertedInput = new StringReader(inputString);
            Console.SetIn(insertedInput);
            var outputSize = commandReader.GetFieldSize();

            Assert.AreEqual(expectedFieldSize, outputSize);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ReadCommandInvalidUserInput()
        {
            var inputString = "------------";
            var expectedFieldSize = int.Parse(inputString);

            var consoleReader = new ConsoleReader();
            var commandReader = new CommandReader(consoleReader);

            var insertedInput = new StringReader(inputString);
            Console.SetIn(insertedInput);
            var outputSize = commandReader.GetCordinates();
        }

        [TestMethod]
        public void GetCoordinatesMustdDuplicateCoordinates()
        {
            var expectedCoordinates = new int[2] { 9, 9 };
            var inputString = "9";

            var consoleReader = new ConsoleReader();
            var commandReader = new CommandReader(consoleReader);

            var insertedInput = new StringReader(inputString);
            Console.SetIn(insertedInput);
            var outputCoordinates = commandReader.GetCordinates();

            CollectionAssert.AreEqual(expectedCoordinates, outputCoordinates);
        }
    }
}
