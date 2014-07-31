namespace BattleFieldGameTests
{
    using System;
    using System.IO;
    using BattleFieldGame.Keyboard.ConsoleIO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ConsoleReaderTests
    {
        [TestMethod]
        public void ConsoleReaderMustReaderSameTextAsInput()
        {
            string expectedOutput = "Some string";

            var insertedInput = new StringReader(expectedOutput);
            Console.SetIn(insertedInput);

            var consoleReader = new ConsoleReader();
            var outputedResult = consoleReader.Read();

            Assert.AreEqual(expectedOutput, outputedResult);
        }
    }
}
