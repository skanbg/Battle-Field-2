﻿namespace BattleFieldGame.GameObjects
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
        private static readonly Random rnd = new Random();

        public GameField(int fieldSize)
        {
            this.FieldSize = fieldSize;
            this.Field = new IFieldTile[this.FieldSize, this.FieldSize];
            this.initialMines = CalculateInitialMinesCount();
            this.GenerateField();
            this.MinesCount = this.initialMines;
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
            private set { this.field = value; }
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

            for (int i = 0; i < explosionTrajectory.Count; i++)
            {
                int currentXPos = xCoord + explosionTrajectory[i].X;
                int currentYPos = yCoord + explosionTrajectory[i].Y;

                if (currentXPos>= 0 && currentXPos < this.FieldSize && currentYPos >= 0 && currentYPos < this.FieldSize)
                {
                    Field[currentXPos, currentYPos].Status = FieldTileStatus.Detonated;
                }



            }

            //switch (Convert.ToInt32(this.Field[xCoord, yCoord]))
            //{
            //    case 1:
            //        this.DetonateMine1(xCoord, yCoord);
            //        break;
            //    case 2:
            //        this.DetonateMine2(xCoord, yCoord);
            //        break;
            //    case 3:
            //        this.DetonateMine3(xCoord, yCoord);
            //        break;
            //    case 4:
            //        this.DetonateMine4(xCoord, yCoord);
            //        break;
            //    case 5:
            //        this.GrymniPetaBomba(xCoord, yCoord);
            //        break;
            //}

            //this.minesCount--;
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

        //public void DisplayField()
        //{
        //    ////top side numbers
        //    //Console.Write("   ");
        //    //for (int i = 0; i < fieldSize; i++)
        //    //{
        //    //    Console.Write(" " + i.ToString() + "  ");
        //    //}

        //    //Console.WriteLine(string.Empty);
        //    //Console.Write("    ");
        //    //for (int i = 0; i < (4 * fieldSize - 3); i++)
        //    //{
        //    //    Console.Write("-");
        //    //}

        //    //Console.WriteLine(string.Empty);
        //    ////top side numbers
        //    //Console.WriteLine(string.Empty);

        //    //for (int i = 0; i < fieldSize; i++)
        //    //{
        //    //    //left side numbers
        //    //    Console.Write(i.ToString() + "|");
        //    //    for (int j = 0; j < fieldSize; j++)
        //    //    {
        //    //        Console.Write(" " + this.Field[i, j].ToString());
        //    //    }

        //    //    Console.WriteLine(string.Empty);
        //    //    Console.WriteLine(string.Empty);
        //    //    Console.WriteLine(string.Empty);
        //    //}
        //}
    }
}
