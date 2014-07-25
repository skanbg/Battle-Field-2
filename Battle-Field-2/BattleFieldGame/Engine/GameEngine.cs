namespace BattleFieldGame.Engine
{
    using System;
    using BattleFieldGame.Interfaces;
    using BattleFieldGame.Factories;
    using BattleFieldGame.GameObjects;
    using BattleFieldGame.Renderer;
    public class GameEngine : IGameEngine
    {
        private IGameField field;

        public GameEngine()
        {
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
            int fieldSize = 10; //TODO: create better whey to read field size!  //GameField.ReadFieldSize();
            this.Field = gameFieldFactory.GetGameField(fieldSize);
            var renderer = new GameFieldConsoleRenderer();
            renderer.Render(this.Field);
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


                    if ((xCoord < 0) || (yCoord > fieldSize - 1) || (this.Field.Field[xCoord, yCoord] is EmptyFieldTile))
                    {
                        Console.WriteLine("Invalid Move");
                    }
                }
                while ((xCoord < 0) || (yCoord > fieldSize - 1) || (this.Field.Field[xCoord, yCoord] is EmptyFieldTile));

                this.Field.DetonateMine(xCoord, yCoord);
                renderer.Render(this.Field);
            }
            while (this.Field.MinesCount > 0);

            Console.WriteLine("Game Over. Detonated Mines: " + this.Field.DetonatedMines);
            Console.ReadKey();
        }
    }
}
