namespace BattleFieldGameTests
{
    using System;
    using System.IO;
    using System.Text;
    using BattleFieldGame;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void MainTests()
        {
            var gameFieldSize = 4;
            StringBuilder outputCommands = new StringBuilder();
            /// Appending the fieldSize
            outputCommands.AppendLine(gameFieldSize.ToString());

            /// New command to blow bomb on every new line
            for (int i = 0; i < gameFieldSize; i++)
            {
                for (int j = 0; j < gameFieldSize; j++)
                {
                    outputCommands.AppendLine(i + " " + j);
                }
            }

            using (StringReader sr = new StringReader(outputCommands.ToString() + Environment.NewLine))
            {
                Console.SetIn(sr);
                Program.Main();
            }
        }
    }
}
