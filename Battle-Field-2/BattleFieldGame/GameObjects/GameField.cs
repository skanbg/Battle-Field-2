namespace BattleFieldGame.GameObjects
{
    using System;
    using BattleFieldGame.Interfaces;
    using BattleFieldGame.Helpers;
    using BattleFieldGame.Factories;
    public class GameField : IGameField
    {
        private int fieldSize;
        private readonly int initialMines;
        private int minesCount;
        private IFieldTile[,] field;
        private static Random rnd = new Random();

        public GameField(int fieldSize)
        {
            this.FieldSize = fieldSize;
            this.Field = new IFieldTile[this.FieldSize, this.FieldSize];
            this.GenerateField();
            this.initialMines = CalculateInitialMinesCount();
            this.MinesCount = this.initialMines;
            this.GenerateMines();
        }

        public int FieldSize
        {
            get { return this.fieldSize; }
            private set { this.fieldSize = value; }
        }

        public int DetonatedMines
        {
            get { return this.initialMines - this.MinesCount; }
        }

        public int MinesCount
        {
            get { return this.minesCount; }
            private set { this.minesCount = value; }
        }

        public IFieldTile[,] Field
        {
            get { return this.field; }
            set { this.field = value; }
        }

        private void GenerateField()
        {
            for (int i = 0; i < this.FieldSize; i++)
            {
                for (int j = 0; j < this.FieldSize; j++)
                {

                }
            }
        }

        private int CalculateInitialMinesCount()
        {
             int cellsCount = this.FieldSize * this.FieldSize;
            int minMinesCount = (int)Math.Floor(0.15 * cellsCount);
            int maxMinesCount = (int)Math.Floor(0.3 * cellsCount);
            int minesCount = rnd.Next(minMinesCount, maxMinesCount);

            return minesCount;
        }

        private void GenerateMines()
        {
            int bombsCount = this.CalculateInitialMinesCount();
            int placedBombsCount = 0;
            int mineTypesCount = Enum.GetNames(typeof(MineDetonationType)).Length;   // Gets the number of options in the enumeration
            int currentXCoordinate;
            int currentYCoordinate;
            MineDetonationType currentMineType;
            IMineTile currentMine;
            var tileFactory = new FieldTilesFactory();

            do
            {
                currentXCoordinate = rnd.Next(0, this.FieldSize);
                currentYCoordinate = rnd.Next(0, this.FieldSize);

                if (this.Field[currentXCoordinate,currentYCoordinate] == null)
                {
                    currentMineType = (MineDetonationType)rnd.Next(0,mineTypesCount);
                    currentMine = tileFactory.GetMineTile(currentMineType);

                    this.Field[currentXCoordinate, currentYCoordinate] = currentMine;
                    placedBombsCount++;
                    Console.WriteLine(currentXCoordinate + " " + currentYCoordinate + " type: " + currentMineType);
                }

            } while (placedBombsCount < bombsCount);
            Console.WriteLine();
        }

        public static int ReadFieldSize()
        {
            bool isFieldSizeCorrect = false;
            int fieldSize = 0;

            while (!isFieldSizeCorrect)
            {
                Console.Write("Enter legal size of board: ");
                string inputData = Console.ReadLine();
                isFieldSizeCorrect = int.TryParse(inputData, out fieldSize);
            }

            return fieldSize;
        }

        public void DetonateMine(int XCoord, int YCoord)
        {
            //switch (Convert.ToInt32(this.Field[XCoord, YCoord]))
            //{
            //    case 1:
            //        this.DetonateMine1(XCoord, YCoord);
            //        break;
            //    case 2:
            //        this.DetonateMine2(XCoord, YCoord);
            //        break;
            //    case 3:
            //        this.DetonateMine3(XCoord, YCoord);
            //        break;
            //    case 4:
            //        this.DetonateMine4(XCoord, YCoord);
            //        break;
            //    case 5:
            //        this.GrymniPetaBomba(XCoord, YCoord);
            //        break;
            //}

            this.minesCount--;
        }

        //public void DetonateMine1(int XCoord, int YCoord)
        //{
        //    if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
        //    {
        //        this.Field[XCoord - 1, YCoord - 1] = " X ";
        //    }

        //    if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
        //    {
        //        this.Field[XCoord - 1, YCoord + 1] = " X ";
        //    }

        //    if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
        //    {
        //        this.Field[XCoord + 1, YCoord - 1] = " X ";
        //    }

        //    if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
        //    {
        //        this.Field[XCoord + 1, YCoord + 1] = " X ";
        //    }

        //    if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
        //    {
        //        this.Field[XCoord, YCoord] = " X ";
        //    }
        //}

        //public void DetonateMine2(int XCoord, int YCoord)
        //{
        //    if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
        //    {
        //        this.Field[XCoord - 1, YCoord - 1] = " X ";
        //    }

        //    if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
        //    {
        //        this.Field[XCoord, YCoord - 1] = " X ";
        //    }

        //    if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
        //    {
        //        this.Field[XCoord + 1, YCoord - 1] = " X ";
        //    }

        //    if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
        //    {
        //        this.Field[XCoord - 1, YCoord] = " X ";
        //    }

        //    if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
        //    {
        //        this.Field[XCoord, YCoord] = " X ";
        //    }

        //    if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
        //    {
        //        this.Field[XCoord + 1, YCoord] = " X ";
        //    }

        //    if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
        //    {
        //        this.Field[XCoord - 1, YCoord + 1] = " X ";
        //    }

        //    if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
        //    {
        //        this.Field[XCoord, YCoord + 1] = " X ";
        //    }

        //    if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
        //    {
        //        this.Field[XCoord + 1, YCoord + 1] = " X ";
        //    }
        //}

        //public void DetonateMine3(int XCoord, int YCoord)
        //{
        //    if ((XCoord - 2 >= 0) && (XCoord - 2 < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
        //    {
        //        this.Field[XCoord - 2, YCoord] = " X ";
        //    }

        //    if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
        //    {
        //        this.Field[XCoord - 1, YCoord] = " X ";
        //    }

        //    if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
        //    {
        //        this.Field[XCoord, YCoord] = " X ";
        //    }

        //    if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
        //    {
        //        this.Field[XCoord + 1, YCoord] = " X ";
        //    }

        //    if ((XCoord + 2 >= 0) && (XCoord + 2 < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
        //    {
        //        this.Field[XCoord + 2, YCoord] = " X ";
        //    }

        //    if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
        //    {
        //        this.Field[XCoord - 1, YCoord - 1] = " X ";
        //    }

        //    if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
        //    {
        //        this.Field[XCoord, YCoord] = " X ";
        //    }

        //    if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
        //    {
        //        this.Field[XCoord + 1, YCoord + 1] = " X ";
        //    }

        //    if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
        //    {
        //        this.Field[XCoord - 1, YCoord + 1] = " X ";
        //    }

        //    if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
        //    {
        //        this.Field[XCoord, YCoord] = " X ";
        //    }

        //    if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
        //    {
        //        this.Field[XCoord + 1, YCoord - 1] = " X ";
        //    }

        //    if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord - 2 >= 0) && (YCoord - 2 < fieldSize))
        //    {
        //        this.Field[XCoord, YCoord - 2] = " X ";
        //    }

        //    if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
        //    {
        //        this.Field[XCoord, YCoord - 1] = " X ";
        //    }

        //    if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
        //    {
        //        this.Field[XCoord, YCoord] = " X ";
        //    }

        //    if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
        //    {
        //        this.Field[XCoord, YCoord + 1] = " X ";
        //    }

        //    if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord + 2 >= 0) && (YCoord + 2 < fieldSize))
        //    {
        //        this.Field[XCoord, YCoord + 2] = " X ";
        //    }
        //}

        //public void DetonateMine4(int XCoord, int YCoord)
        //{
        //    if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
        //    {
        //        this.Field[XCoord - 1, YCoord - 1] = " X ";
        //    }

        //    if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
        //    {
        //        this.Field[XCoord, YCoord - 1] = " X ";
        //    }

        //    if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
        //    {
        //        this.Field[XCoord + 1, YCoord - 1] = " X ";
        //    }

        //    if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
        //    {
        //        this.Field[XCoord - 1, YCoord] = " X ";
        //    }

        //    if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
        //    {
        //        this.Field[XCoord, YCoord] = " X ";
        //    }

        //    if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
        //    {
        //        this.Field[XCoord + 1, YCoord] = " X ";
        //    }

        //    if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
        //    {
        //        this.Field[XCoord - 1, YCoord + 1] = " X ";
        //    }

        //    if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
        //    {
        //        this.Field[XCoord, YCoord + 1] = " X ";
        //    }

        //    if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
        //    {
        //        this.Field[XCoord + 1, YCoord + 1] = " X ";
        //    }

        //    if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord + 2 >= 0) && (YCoord + 2 < fieldSize))
        //    {
        //        this.Field[XCoord - 1, YCoord + 2] = " X ";
        //    }

        //    if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord + 2 >= 0) && (YCoord + 2 < fieldSize))
        //    {
        //        this.Field[XCoord, YCoord + 2] = " X ";
        //    }

        //    if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord + 2 >= 0) && (YCoord + 2 < fieldSize))
        //    {
        //        this.Field[XCoord + 1, YCoord + 2] = " X ";
        //    }

        //    if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord - 2 >= 0) && (YCoord - 2 < fieldSize))
        //    {
        //        this.Field[XCoord - 1, YCoord - 2] = " X ";
        //    }

        //    if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord - 2 >= 0) && (YCoord - 2 < fieldSize))
        //    {
        //        this.Field[XCoord, YCoord - 2] = " X ";
        //    }

        //    if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord - 2 >= 0) && (YCoord - 2 < fieldSize))
        //    {
        //        this.Field[XCoord + 1, YCoord - 2] = " X ";
        //    }

        //    if ((XCoord - 2 >= 0) && (XCoord - 2 < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
        //    {
        //        this.Field[XCoord - 2, YCoord - 1] = " X ";
        //    }

        //    if ((XCoord - 2 >= 0) && (XCoord - 2 < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
        //    {
        //        this.Field[XCoord - 2, YCoord] = " X ";
        //    }

        //    if ((XCoord - 2 >= 0) && (XCoord - 2 < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
        //    {
        //        this.Field[XCoord - 2, YCoord + 1] = " X ";
        //    }

        //    if ((XCoord + 2 >= 0) && (XCoord + 2 < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
        //    {
        //        this.Field[XCoord + 2, YCoord - 1] = " X ";
        //    }

        //    if ((XCoord + 2 >= 0) && (XCoord + 2 < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
        //    {
        //        this.Field[XCoord + 2, YCoord] = " X ";
        //    }

        //    if ((XCoord + 2 >= 0) && (XCoord + 2 < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
        //    {
        //        this.Field[XCoord + 2, YCoord + 1] = " X ";
        //    }
        //}

        //public void GrymniPetaBomba(int XCoord, int YCoord)
        //{
        //    if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
        //    {
        //        this.Field[XCoord - 1, YCoord - 1] = " X ";
        //    }

        //    if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
        //    {
        //        this.Field[XCoord, YCoord - 1] = " X ";
        //    }

        //    if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
        //    {
        //        this.Field[XCoord + 1, YCoord - 1] = " X ";
        //    }

        //    if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
        //    {
        //        this.Field[XCoord - 1, YCoord] = " X ";
        //    }

        //    if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
        //    {
        //        this.Field[XCoord, YCoord] = " X ";
        //    }

        //    if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
        //    {
        //        this.Field[XCoord + 1, YCoord] = " X ";
        //    }

        //    if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
        //    {
        //        this.Field[XCoord - 1, YCoord + 1] = " X ";
        //    }

        //    if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
        //    {
        //        this.Field[XCoord, YCoord + 1] = " X ";
        //    }

        //    if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
        //    {
        //        this.Field[XCoord + 1, YCoord + 1] = " X ";
        //    }

        //    if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord + 2 >= 0) && (YCoord + 2 < fieldSize))
        //    {
        //        this.Field[XCoord - 1, YCoord + 2] = " X ";
        //    }

        //    if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord + 2 >= 0) && (YCoord + 2 < fieldSize))
        //    {
        //        this.Field[XCoord, YCoord + 2] = " X ";
        //    }

        //    if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord + 2 >= 0) && (YCoord + 2 < fieldSize))
        //    {
        //        this.Field[XCoord + 1, YCoord + 2] = " X ";
        //    }

        //    if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord - 2 >= 0) && (YCoord - 2 < fieldSize))
        //    {
        //        this.Field[XCoord - 1, YCoord - 2] = " X ";
        //    }

        //    if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord - 2 >= 0) && (YCoord - 2 < fieldSize))
        //    {
        //        this.Field[XCoord, YCoord - 2] = " X ";
        //    }

        //    if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord - 2 >= 0) && (YCoord - 2 < fieldSize))
        //    {
        //        this.Field[XCoord + 1, YCoord - 2] = " X ";
        //    }

        //    if ((XCoord - 2 >= 0) && (XCoord - 2 < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
        //    {
        //        this.Field[XCoord - 2, YCoord - 1] = " X ";
        //    }

        //    if ((XCoord - 2 >= 0) && (XCoord - 2 < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
        //    {
        //        this.Field[XCoord - 2, YCoord] = " X ";
        //    }

        //    if ((XCoord - 2 >= 0) && (XCoord - 2 < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
        //    {
        //        this.Field[XCoord - 2, YCoord + 1] = " X ";
        //    }

        //    if ((XCoord + 2 >= 0) && (XCoord + 2 < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
        //    {
        //        this.Field[XCoord + 2, YCoord - 1] = " X ";
        //    }

        //    if ((XCoord + 2 >= 0) && (XCoord + 2 < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
        //    {
        //        this.Field[XCoord + 2, YCoord] = " X ";
        //    }

        //    if ((XCoord + 2 >= 0) && (XCoord + 2 < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
        //    {
        //        this.Field[XCoord + 2, YCoord + 1] = " X ";
        //    }

        //    if ((XCoord - 2 >= 0) && (XCoord - 2 < fieldSize) && (YCoord - 2 >= 0) && (YCoord - 2 < fieldSize))
        //    {
        //        this.Field[XCoord - 2, YCoord - 2] = " X ";
        //    }

        //    if ((XCoord + 2 >= 0) && (XCoord + 2 < fieldSize) && (YCoord - 2 >= 0) && (YCoord - 2 < fieldSize))
        //    {
        //        this.Field[XCoord + 2, YCoord - 2] = " X ";
        //    }

        //    if ((XCoord - 2 >= 0) && (XCoord - 2 < fieldSize) && (YCoord + 2 >= 0) && (YCoord + 2 < fieldSize))
        //    {
        //        this.Field[XCoord - 2, YCoord + 2] = " X ";
        //    }

        //    if ((XCoord + 2 >= 0) && (XCoord + 2 < fieldSize) && (YCoord + 2 >= 0) && (YCoord + 2 < fieldSize))
        //    {
        //        this.Field[XCoord + 2, YCoord + 2] = " X ";
        //    }
        //}

        public void DisplayField()
        {
            ////top side numbers
            //Console.Write("   ");
            //for (int i = 0; i < fieldSize; i++)
            //{
            //    Console.Write(" " + i.ToString() + "  ");
            //}

            //Console.WriteLine(string.Empty);
            //Console.Write("    ");
            //for (int i = 0; i < (4 * fieldSize - 3); i++)
            //{
            //    Console.Write("-");
            //}

            //Console.WriteLine(string.Empty);
            ////top side numbers
            //Console.WriteLine(string.Empty);

            //for (int i = 0; i < fieldSize; i++)
            //{
            //    //left side numbers
            //    Console.Write(i.ToString() + "|");
            //    for (int j = 0; j < fieldSize; j++)
            //    {
            //        Console.Write(" " + this.Field[i, j].ToString());
            //    }

            //    Console.WriteLine(string.Empty);
            //    Console.WriteLine(string.Empty);
            //    Console.WriteLine(string.Empty);
            //}
        }
    }
}
