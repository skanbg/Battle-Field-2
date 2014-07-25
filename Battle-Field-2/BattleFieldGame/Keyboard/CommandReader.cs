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

        public int[] GetFieldDimentions()
        {
            return this.ReadCommand();
        }

        private int[] ReadCommand()
        {
            string input = this.reader.Read();
            int[] resulrs = new int[2];

            string[] tokens = input.Split(' ');

            if (tokens.Length == 2)
            {
                resulrs[0] = Int16.Parse(tokens[0]);
                resulrs[1] = Int16.Parse(tokens[1]);
            }
            else if (tokens.Length == 1)
            {
                resulrs[0] = Int16.Parse(tokens[0]);
                resulrs[1] = resulrs[0];
            }
            else
            {
                throw new ArgumentOutOfRangeException("Invalid user input");
            }

            return resulrs;
        }
    }
}
