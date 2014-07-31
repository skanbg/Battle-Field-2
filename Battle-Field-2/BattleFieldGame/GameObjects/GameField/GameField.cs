namespace BattleFieldGame.GameObjects.GameField
{
    using System;
    using BattleFieldGame.DetonationStretegies;
    using BattleFieldGame.GameObjects.FieldTiles;
    using BattleFieldGame.GameObjects.GameField.MinesCountStrategies;
    using BattleFieldGame.Helpers;
    using BattleFieldGame.Interfaces;

    public class GameField : IGameField
    {
        private static readonly Random RandomGenerator = new Random();
        private readonly int initialMines;
        private readonly IDetonationStrategyFactory detonationStrategyFactory;
        private readonly IFieldTilesFactory fieldTilesFactory;
        private readonly IMinesCountStrategy minesCountStrategy;
        private int detonatedMines;
        private int fieldSize;
        private IFieldTile[,] field;

        public GameField(int fieldSize)
            : this(fieldSize, new DetonationStrategyFactory(), new FieldTilesFactory(), new MinesCountStrategyFactory().GetHard())
        {
        }

        public GameField(int fieldSize, IDetonationStrategyFactory detonationStrategyFactory, IFieldTilesFactory fieldTilesFactory, IMinesCountStrategy minesCountStrategy)
        {
            this.FieldSize = fieldSize;
            this.Field = new IFieldTile[this.FieldSize, this.FieldSize];
            this.detonationStrategyFactory = detonationStrategyFactory;
            this.fieldTilesFactory = fieldTilesFactory;
            this.minesCountStrategy = minesCountStrategy;
            this.initialMines = this.CalculateInitialMinesCount();
            this.GenerateField();
            this.detonatedMines = 0;

            Console.WriteLine(this.FieldSize);
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

        /// <summary>
        /// Detonates a mine according to the given coords
        /// and increases the number of detonated mines 
        /// each time it succeeds.
        /// </summary>
        /// <param name="coordX">The coordX of the mine</param>
        /// <param name="coordY">The coordY of the mine</param>
        public void DetonateMine(int coordX, int coordY)
        {
            var currentMine = this.Field[coordX, coordY] as IMineTile;
            var explosionTrajectory = currentMine.ExecuteDetonation();
            /// count hte mine that exploded
            this.DetonatedMines++;

            for (int i = 0; i < explosionTrajectory.Count; i++)
            {
                int currentXPos = coordX + explosionTrajectory[i].X;
                int currentYPos = coordY + explosionTrajectory[i].Y;

                if (currentXPos >= 0 && currentXPos < this.FieldSize && currentYPos >= 0 && currentYPos < this.FieldSize)
                {
                    var currentFieldTile = this.Field[currentXPos, currentYPos];
                    currentFieldTile.Status = FieldTileStatus.Detonated;

                    if (currentFieldTile.TileType == FieldTileType.MineTile)
                    {
                        // count the mines that have been destroyed by the explosion trajectory
                        this.DetonatedMines++;
                    }
                }
            }
        }

        private void GenerateField()
        {
            this.PlaceMines();
            this.FillEmptyCells();
        }

        /// <summary>
        /// Places empty tiles on the field.
        /// </summary>
        private void FillEmptyCells()
        {
            for (int i = 0; i < this.FieldSize; i++)
            {
                for (int j = 0; j < this.FieldSize; j++)
                {
                    if (this.Field[i, j] == null)
                    {
                        this.Field[i, j] = this.fieldTilesFactory.GetEmptyTile();
                    }
                }
            }
        }

        /// <summary>
        /// Calculates the number of initial mines on the field.
        /// </summary>
        /// <returns>The number of initial mines.</returns>
        private int CalculateInitialMinesCount()
        {
            int minesCount = this.minesCountStrategy.GetMinesCount(this.FieldSize, GameField.RandomGenerator);

            return minesCount;
        }

        /// <summary>
        /// Places mines on the field.
        /// </summary>
        private void PlaceMines()
        {
            int bombsCount = this.initialMines;
            int placedBombsCount = 0;
            int currentXCoordinate;
            int currentYCoordinate;
            IMineTile currentMine;

            do
            {
                currentXCoordinate = RandomGenerator.Next(0, this.FieldSize);
                currentYCoordinate = RandomGenerator.Next(0, this.FieldSize);

                if (this.Field[currentXCoordinate, currentYCoordinate] == null)
                {
                    currentMine = this.GenerateMine();
                    this.Field[currentXCoordinate, currentYCoordinate] = currentMine;
                    placedBombsCount++;
                }
            }
            while (placedBombsCount < bombsCount);
        }

        /// <summary>
        /// Creates a single mine with detonation type and strategy.
        /// </summary>
        /// <returns>The mine tile</returns>
        private IMineTile GenerateMine() // To be replaced by prototype
        {
            int mineTypesCount = Enum.GetNames(typeof(MineDetonationType)).Length;   // Gets the number of options in the enumeration
            MineDetonationType currentMineType;
            IMineTile currentMine;
            IMineDetonationStrategy detonationStrategy;

            currentMineType = (MineDetonationType)RandomGenerator.Next(0, mineTypesCount);

            detonationStrategy = this.detonationStrategyFactory.GetDetonationStrategy(currentMineType);
            currentMine = this.fieldTilesFactory.GetMineTile(currentMineType, detonationStrategy);

            return currentMine;
        }
    }
}
