namespace BattleFieldGame
{
    using BattleFieldGame.Keyboard;
    using System;

    public class ConsoleReader : IReader
    {
        public string Read()
        {
            string line = Console.ReadLine();
            return line;
        }
    }
}
