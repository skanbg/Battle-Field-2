namespace BattleFieldGame
{
    using BattleFieldGame.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ConsoleReader : IConsoleReader
    {
        public string[] ReadLine()
        {
            string line = Console.ReadLine();
            return line.Split(' ');
        }

        public int[] ReadCoordinates()
        {
            string[] lineTokens = this.ReadLine();
            int[] parsedCoordinates = lineTokens.Select(x => int.Parse(x)).ToArray();
            return parsedCoordinates;
        }
    }
}
