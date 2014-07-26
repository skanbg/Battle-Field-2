namespace BattleFieldGame.Engine
{
    using System;
    using BattleFieldGame.DetonationStretegies;
    using BattleFieldGame.GameObjects;
    using BattleFieldGame.Keyboard.ConsoleIO;
    using BattleFieldGame.Keyboard;

    public class GameEngine : IGameEngine
    {
        private IGameField field;
        private ICommandReader commandReader;

        public GameEngine()
        {
            this.commandReader = new CommandReader(new ConsoleReader());
        }

        public IGameField Field
        {
            get { return this.field; }
            set { this.field = value; }
        }

        /// <summary>
        /// Starts the game and displays the final score.
        /// </summary>
        public void StartBattleFieldGame()
        {
            GameFieldFactory gameFieldFactory = new GameFieldFactory();
            int fieldSize = GetFieldSize();
            field = gameFieldFactory.GetGameField(fieldSize);
            var renderer = new ConsoleWriter();
            renderer.WriteField(field);

            RedrawField(field, fieldSize, renderer);

            Console.WriteLine("Game Over. Detonated Mines: " + field.DetonatedMines);
            Console.ReadKey();
        }

        /// <summary>
        /// Redraws the field after the user's entry 
        /// until all mines are detonated.
        /// </summary>
        /// <param name="field">the field with its coords</param>
        /// <param name="fieldSize">the specified field size</param>
        /// <param name="renderer">draws the field on the screen</param>
        public void RedrawField(IGameField field, int fieldSize, ConsoleWriter renderer)
        {
            do
            {
                int xCoord, yCoord;

                do
                {
                    xCoord = -1;
                    yCoord = -1;

                    Console.Write("Enter coordinates of a bomb: ");
                    string coordinates = Console.ReadLine();
                    string[] coords = coordinates.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    if (coords.Length != 2)
                    {
                        Console.WriteLine("Invalid coordinates!");
                        continue;
                    }

                    if (!Int32.TryParse(coords[0], out xCoord))
                    {
                        Console.WriteLine("Invalid first coordinate!");
                        continue;
                    }

                    if (!Int32.TryParse(coords[1], out yCoord))
                    {
                        Console.WriteLine("Invalid second coordinate!");
                        continue;
                    }

                    if ((xCoord < 0) || (yCoord > fieldSize - 1) || (field[xCoord, yCoord] is EmptyFieldTile))
                    {
                        Console.WriteLine("Invalid Move");
                    }
                }
                while ((xCoord < 0) || (yCoord > fieldSize - 1) || (field[xCoord, yCoord] is EmptyFieldTile));

                field.DetonateMine(xCoord, yCoord);
                renderer.WriteField(field);
            }
            while (this.Field.MinesCount > 0);
        }

        /// <summary>
        /// Checks if the size of the field, entered by the user, is between 1 and 10.
        /// </summary>
        /// <returns>Valid size of the field</returns>
        private int GetFieldSize()
        {
            int size = 0;
            
            while (true)
            {
                size = this.commandReader.GetFieldSize();

                if (1 <= size && size <= 10)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("The size of the field must be greater than 1 and less than 10 (including!)");
                }
            }

            return size;
        }
    }
}
