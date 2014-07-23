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
            var factory = Factory.Get();

            // initial game field
            int fieldSize = 10; //TODO: create better whey to read field size!  //GameField.ReadFieldSize();
            this.Field = factory.CreateGameField(fieldSize);
            var renderer = new GameFieldConsoleRenderer();
            do
            {
                int XCoord, YCoord;

                do
                {
                    XCoord = -1;
                    YCoord = -1;
                    Console.Write("Enter coordinates: ");
                    string coordinates = Console.ReadLine();
                    string[] coords = coordinates.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (coords.Length != 2)
                    {
                        Console.WriteLine("Invalid coordinates!");
                        continue;
                    }
                    if (!Int32.TryParse(coords[0], out XCoord))
                    {
                        Console.WriteLine("Invalid first coordinate!");
                        continue;
                    }
                    if (!Int32.TryParse(coords[1], out YCoord))
                    {
                        Console.WriteLine("Invalid second coordinate!");
                        continue;
                    }


                    if ((XCoord < 0) || (YCoord > fieldSize - 1) || (this.Field.Field[XCoord, YCoord] is EmptyFieldTile))
                    {
                        Console.WriteLine("Invalid Move");
                    }
                }
                while ((XCoord < 0) || (YCoord > fieldSize - 1) || (this.Field.Field[XCoord, YCoord] is EmptyFieldTile));

                //this.Field.DetonateMine(XCoord, YCoord);
                //this.Field.DisplayField();
                renderer.Render(this.Field);
            }
            while (this.Field.MinesCount > 0);

            Console.WriteLine("Game Over. Detonated Mines: " + this.Field.DetonatedMines);
            Console.ReadKey();
        }
    }
}
