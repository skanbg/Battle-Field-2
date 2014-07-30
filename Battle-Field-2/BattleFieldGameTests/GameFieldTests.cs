using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BattleFieldGame.GameObjects.GameField;

namespace BattleFieldGameTests
{
    [TestClass]
    public class GameFieldTests
    {
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ZeroSizeTest()
        {
            GameField field = new GameField(0);
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void NegativeSizeTest()
        {
            GameField field = new GameField(-1);
        }

        [TestMethod]
        public void ValidSizeTest()
        {
            int size = 5;
            GameField field = new GameField(size);
            Assert.AreEqual(size, field.FieldSize);
        }

        [TestMethod]
        public void TestReadFieldSizeAsNumber()
        {
            bool isFieldSizeCorrect = false;
            int fieldSize = 0;
            string inputData = "6";
            isFieldSizeCorrect = int.TryParse(inputData, out fieldSize);

            Assert.IsTrue(true, "You haven't entered a number, try again!", isFieldSizeCorrect);
        }

        [TestMethod]
        public void TestReadFieldAsString()
        {
            bool isFieldSizeCorrect = false;
            int fieldSize = 0;
            string inputData = "string input";
            isFieldSizeCorrect = int.TryParse(inputData, out fieldSize);
            
            Assert.IsFalse(false, "You haven't entered a number, try again!", isFieldSizeCorrect);
        }
    }
}
