using System;
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
    }
}
