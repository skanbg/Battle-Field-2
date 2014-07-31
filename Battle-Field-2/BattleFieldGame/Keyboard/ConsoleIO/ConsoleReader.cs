namespace BattleFieldGame.Keyboard.ConsoleIO
{
    using System;
    using BattleFieldGame.Keyboard;

    public class ConsoleReader : IReader
    {
        public string Read()
        {
            string line = Console.ReadLine();
            return line;
        }
    }
}
