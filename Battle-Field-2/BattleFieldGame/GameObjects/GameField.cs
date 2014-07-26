namespace BattleFieldGame.GameObjects
{
    using System;
    using BattleFieldGame.Interfaces;
    using BattleFieldGame.Helpers;
    using BattleFieldGame.Factories;
    public class GameField : IGameField
    {
        private int detonatedMines;
        private int fieldSize;
        private readonly int initialMines;
        //private int minesCount;
        private IFieldTile[,] field;
        private static readonly Random rnd = new Random();

        public GameField(int fieldSize)
        {
            this.FieldSize = fieldSize;
            this.Field = new IFieldTile[this.FieldSize, this.FieldSize];
            this.initialMines = CalculateInitialMinesCount();
            this.GenerateField();
            //this.MinesCount = this.initialMines;
            this.detonatedMines = 0;
        }

        public IFieldTile this[int row, int col]    // Indexer declaration
        {
            get
            {
                return this.Field[row, col];
            }
            private set
            {
                this.Field[row, col] = value;
            }
        }

        public int GetColumnsCount()
        {
            return this.Field.GetLength(1);
        }

        public int GetRowsCount()
        {
            return this.Field.GetLength(0);
        }

        public int FieldSize
        {
            get { return this.fieldSize; }
            private set { this.fieldSize = value; }
        }

        public int DetonatedMines
        {
            get { return this.detonatedMines; }
            private set { this.detonatedMines = value; }
        }

        public int MinesCount
        {
            get { return this.initialMines - this.DetonatedMines; }
        }

        private IFieldTile[,] Field
        {
            get { return this.field; }
            set { this.field = value; }
        }

        private void GenerateField()
        {
            PlaceMines();
            FillEmptyCells();
        }
        private void FillEmptyCells()
        {
            var tileFactory = new FieldTilesFactory();

            for (int i = 0; i < this.FieldSize; i++)
            {
                for (int j = 0; j < this.FieldSize; j++)
                {
                    if (this.Field[i, j] == null)
                    {
                        this.Field[i, j] = tileFactory.GetEmptyTile();
                    }
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

        private void PlaceMines()
        {
            int bombsCount = this.initialMines;
            int placedBombsCount = 0;
            int currentXCoordinate;
            int currentYCoordinate;
            IMineTile currentMine;

            do
            {
                currentXCoordinate = rnd.Next(0, this.FieldSize);
                currentYCoordinate = rnd.Next(0, this.FieldSize);

                if (this.Field[currentXCoordinate, currentYCoordinate] == null)
                {
                    currentMine = GameField.GenerateMine();
                    this.Field[currentXCoordinate, currentYCoordinate] = currentMine;
                    placedBombsCount++;
                }

            } while (placedBombsCount < bombsCount);
        }

        private static IMineTile GenerateMine() // To be replaced by prototype
        {
            int mineTypesCount = Enum.GetNames(typeof(MineDetonationType)).Length;   // Gets the number of options in the enumeration
            MineDetonationType currentMineType;
            IMineTile currentMine;
            var tileFactory = new FieldTilesFactory(); // Add interface
            IDetonationStrategyFactory detonationStrategyFactory = new DetonationStrategyFactory();
            IMineDetonationStrategy detonationStrategy;
            currentMineType = (MineDetonationType)rnd.Next(0, mineTypesCount);
            detonationStrategy = detonationStrategyFactory.GetDetonationStrategy(currentMineType);
            currentMine = tileFactory.GetMineTile(currentMineType, detonationStrategy);
            return currentMine;
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

        public void DetonateMine(int xCoord, int yCoord)
        {
            var currentMine = this.Field[xCoord,yCoord] as IMineTile;
            var explosionTrajectory = currentMine.ExecuteDetonation();
            // count hte mine that exploded
            this.DetonatedMines++;

            for (int i = 0; i < explosionTrajectory.Count; i++)
            {
                int currentXPos = xCoord + explosionTrajectory[i].X;
                int currentYPos = yCoord + explosionTrajectory[i].Y;

                if (currentXPos>= 0 && currentXPos < this.FieldSize && currentYPos >= 0 && currentYPos < this.FieldSize)
                {
                    var currentFieldTile = Field[currentXPos, currentYPos];
                    currentFieldTile.Status = FieldTileStatus.Detonated;

                    if (currentFieldTile.TileType == FieldTileType.MineTile)
                    {
                        // count the mines that have been destroyed by the explosion trajectory
                        this.DetonatedMines++;
                    }
                }
            }       
        }
    }
}
