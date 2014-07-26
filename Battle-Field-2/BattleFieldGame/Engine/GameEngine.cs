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

        public void Start()
        {
            GameFieldFactory gameFieldFactory = new GameFieldFactory();

            // initial game field
            int fieldSize = GetFieldSize();
            this.Field = gameFieldFactory.GetGameField(fieldSize);
            var renderer = new ConsoleWriter();
            renderer.WriteField(this.Field);

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


                    if ((xCoord < 0) || (yCoord > fieldSize - 1) || (this.Field[xCoord, yCoord] is EmptyFieldTile))
                    {
                        Console.WriteLine("Invalid Move");
                    }
                }
                while ((xCoord < 0) || (yCoord > fieldSize - 1) || (this.Field[xCoord, yCoord] is EmptyFieldTile));

                this.Field.DetonateMine(xCoord, yCoord);
                renderer.WriteField(this.Field);
            }
            while (this.Field.MinesCount > 0);

            Console.WriteLine("Game Over. Detonated Mines: " + this.Field.DetonatedMines);
            Console.ReadKey();
        }

        private int GetFieldSize()
        {
            int size = 0;
            
            while (true)
            {
                size = GetInputSize();

                // size is valid
                if (1 <= size && size <= 10)
                {
                    break;
                }
                else
                {
                    // TODO: Aletr user for invalid input and try again to input.
                }

            }

            return size;
        }

        private int GetInputSize()
        {
            int size = 0;

            try
            {
                size = this.commandReader.GetFieldSize();
            }
            catch (ArgumentException)
            {
                //TODO: Alert user
            }

            return size;
        }
    }
}
