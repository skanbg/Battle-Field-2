namespace BattleFieldGame.Engine
{
    using System;

    using BattleFieldGame.GameObjects;
    using BattleFieldGame.Keyboard;
    using BattleFieldGame.Keyboard.ConsoleIO;

    public class GameEngine : IGameEngine
    {
        private IGameField field;
        private ICommandReader commandReader;
        private ConsoleWriter render;

        public GameEngine()
        {
            this.commandReader = new CommandReader(new ConsoleReader());
            GameFieldFactory gameFieldFactory = new GameFieldFactory();

            int fieldSize = this.GetFieldSize();
            this.field = gameFieldFactory.GetGameField(fieldSize);
            this.render = new ConsoleWriter();
        }

        /// <summary>
        /// Starts the game and displays the final score.
        /// </summary>
        public void StartBattleFieldGame()
        {
            this.render.WriteField(this.field);

            this.RedrawField();

            Console.WriteLine("Game Over. Detonated Mines: " + this.field.DetonatedMines);
            Console.ReadKey();
        }

        /// <summary>
        /// Redraws the field after the user's entry 
        /// until all mines are detonated.
        /// </summary>
        /// <param name="field">the field with its coords</param>
        /// <param name="fieldSize">the specified field size</param>
        /// <param name="renderer">draws the field on the screen</param>
        public void RedrawField()
        {
            do
            {
                int[] coords = this.GetMoveCoordinates();

                this.field.DetonateMine(coords[0], coords[1]);
                this.render.WriteField(this.field);
            }
            while (this.field.MinesCount > 0);
        }

        /// <summary>
        /// Get player next move.
        /// </summary>
        /// <returns>Array of two numbers arr[0] is ROW coord arr[1] is COL coord</returns>
        private int[] GetMoveCoordinates()
        {
            int[] coords;
            bool isXValid;
            bool isYValid;
            bool isEmptyFieldTile;

            while (true)
            {
                Console.Write("Enter coordinates of a bomb: ");
                try
                {
                    coords = this.commandReader.GetCordinates();
                }
                catch (Exception)
                {
                    // set invalid coords.
                    coords = new int[] { -1, -1 };
                }

                isXValid = this.IsValueInRange(coords[0], 0, this.field.FieldSize - 1);
                isYValid = this.IsValueInRange(coords[1], 0, this.field.FieldSize - 1);

                if (isXValid && isYValid)
                {
                    isEmptyFieldTile = !(this.field[coords[0], coords[1]] is EmptyFieldTile);

                    if (isEmptyFieldTile)
                    {
                        break;
                    }
                }

                Console.WriteLine("Invalid bomb coordinates!");
            }

            return coords;
        }

        /// <summary>
        /// Check value is in ramge min max.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns>true if value is in range</returns>
        private bool IsValueInRange(int value, int min, int max)
        {
            if (min <= value && value <= max)
            {
                return true;
            }

            return false;
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
                Console.Write("Enter field size: ");

                try
                {
                    size = this.commandReader.GetFieldSize();
                }
                catch (Exception)
                {
                    // set invalid size bocouse size is invalid.
                    size = -1;
                }

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
