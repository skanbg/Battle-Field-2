namespace BattleFieldGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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
            ObjectFactory factory = Factory.Get();

			// initial game field
            int fieldSize = 5; //TODO: create beatter whey to read fiald size!  //GameField.ReadFieldSize();
            this.Field = factory.CreateGameField(fieldSize);

            do
            {
                int XCoord, YCoord;

                do
                {
                    Console.Write("Enter coordinates: ");
                    string coordinates = Console.ReadLine();
                    XCoord = Convert.ToInt32(coordinates.Substring(0, 1));
                    YCoord = Convert.ToInt32(coordinates.Substring(2));

                    if ((XCoord < 0) || (YCoord > fieldSize - 1) || (this.Field.Field[XCoord, YCoord] == " - "))
                    {
                        Console.WriteLine("Invalid Move");
                    }
                }
                while ((XCoord < 0) || (YCoord > fieldSize - 1) || (this.Field.Field[XCoord, YCoord] == " - "));

                this.Field.DetonateMine(XCoord, YCoord);
                this.Field.DisplayField();
            }
            while (this.Field.MinesCount > 0);

            Console.WriteLine("Game Over. Detonated Mines: " + this.Field.DetonatedMines);
            Console.ReadKey();
        }
    }
}
