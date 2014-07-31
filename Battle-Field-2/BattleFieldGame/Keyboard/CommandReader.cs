namespace BattleFieldGame.Keyboard
{
    using System;

    public class CommandReader : ICommandReader
    {
        private IReader reader;

        public CommandReader(IReader reader)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader can not be null");
            }

            this.reader = reader;
        }

        public int[] GetCordinates()
        {
            return this.ReadCommand();
        }

        public int GetFieldSize()
        {
            string input = this.reader.Read();
            int size = int.Parse(input);

            return size;
        }

        private int[] ReadCommand()
        {
            string input = this.reader.Read();
            int[] results = new int[2];

            string[] tokens = input.Split(' ');

            if (tokens.Length == 2)
            {
                results[0] = short.Parse(tokens[0]);
                results[1] = short.Parse(tokens[1]);
            }
            else if (tokens.Length == 1)
            {
                results[0] = short.Parse(tokens[0]);
                results[1] = results[0];
            }
            else
            {
                throw new FormatException("Invalid user input");
            }

            return results;
        }
    }
}
