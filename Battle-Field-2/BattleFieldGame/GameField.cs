namespace BattleFieldGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class GameField
    {
        private int fieldSize;
        private readonly int initialMines;
        private int minesCount;
        private string[,] field;
        private static Random rnd = new Random();

        public int FieldSize
        {
            get { return this.fieldSize; }
            set { this.fieldSize = value; }
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

        public string[,] Field
        {
            get { return this.field; }
            set { this.field = value; }
        }

        public GameField(int fieldSize)
        {
            this.FieldSize = fieldSize;
            this.Field = new string[this.FieldSize, this.FieldSize];
            this.GenerateField();
            this.initialMines = CalculateInitialMinesCount();
            this.MinesCount = this.initialMines;
            this.GenerateMines();
        }

        private void GenerateField()
        {
            for (int i = 0; i < this.FieldSize; i++)
            {
                for (int j = 0; j < this.FieldSize; j++)
                {
                    this.Field[i, j] = " - ";
                }
            }
        }

        private int CalculateInitialMinesCount()
        {
            int minesDownLimit = Convert.ToInt32(0.15 * fieldSize * fieldSize);
            int minesUpperLimit = Convert.ToInt32(0.30 * fieldSize * fieldSize);
            int minesCount = Convert.ToInt32(rnd.Next(minesDownLimit, minesUpperLimit));

            return minesCount;
        }

        private void GenerateMines()
        {
            int tempMineXCoordinate;
            int tempMineYCoordinate;
            bool flag = true;

            int[,] minesPositions = new int[minesCount, minesCount];
            Console.WriteLine("mines count is: " + minesCount);

            for (int i = 0; i < minesCount; i++)
            {
                do
                {
                    //s do-while raboti po dobre
                    tempMineXCoordinate = Convert.ToInt32(rnd.Next(0, fieldSize - 1));
                    tempMineYCoordinate = Convert.ToInt32(rnd.Next(0, fieldSize - 1));
                    if (this.Field[tempMineXCoordinate, tempMineYCoordinate] == " - ")
                    {
                        this.Field[tempMineXCoordinate, tempMineYCoordinate] = " " + Convert.ToString(rnd.Next(1, 6) + " ");
                    }
                    else
                    {
                        flag = false;
                    }
                }
                while (flag);
            }
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
            switch (Convert.ToInt32(this.Field[XCoord, YCoord]))
            {
                case 1:
                    this.DetonateMine1(XCoord, YCoord);
                    break;
                case 2:
                    this.DetonateMine2(XCoord, YCoord);
                    break;
                case 3:
                    this.DetonateMine3(XCoord, YCoord);
                    break;
                case 4:
                    this.DetonateMine4(XCoord, YCoord);
                    break;
                case 5:
                    this.GrymniPetaBomba(XCoord, YCoord);
                    break;
            }

            this.minesCount--;
        }

        public void DetonateMine1(int XCoord, int YCoord)
        {
            if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
            {
                this.Field[XCoord - 1, YCoord - 1] = " X ";
            }

            if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
            {
                this.Field[XCoord - 1, YCoord + 1] = " X ";
            }

            if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
            {
                this.Field[XCoord + 1, YCoord - 1] = " X ";
            }

            if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
            {
                this.Field[XCoord + 1, YCoord + 1] = " X ";
            }

            if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
            {
                this.Field[XCoord, YCoord] = " X ";
            }
        }

        public void DetonateMine2(int XCoord, int YCoord)
        {
            if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
            {
                this.Field[XCoord - 1, YCoord - 1] = " X ";
            }

            if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
            {
                this.Field[XCoord, YCoord - 1] = " X ";
            }

            if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
            {
                this.Field[XCoord + 1, YCoord - 1] = " X ";
            }

            if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
            {
                this.Field[XCoord - 1, YCoord] = " X ";
            }

            if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
            {
                this.Field[XCoord, YCoord] = " X ";
            }

            if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
            {
                this.Field[XCoord + 1, YCoord] = " X ";
            }

            if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
            {
                this.Field[XCoord - 1, YCoord + 1] = " X ";
            }

            if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
            {
                this.Field[XCoord, YCoord + 1] = " X ";
            }

            if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
            {
                this.Field[XCoord + 1, YCoord + 1] = " X ";
            }
        }

        public void DetonateMine3(int XCoord, int YCoord)
        {
            if ((XCoord - 2 >= 0) && (XCoord - 2 < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
            {
                this.Field[XCoord - 2, YCoord] = " X ";
            }

            if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
            {
                this.Field[XCoord - 1, YCoord] = " X ";
            }

            if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
            {
                this.Field[XCoord, YCoord] = " X ";
            }

            if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
            {
                this.Field[XCoord + 1, YCoord] = " X ";
            }

            if ((XCoord + 2 >= 0) && (XCoord + 2 < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
            {
                this.Field[XCoord + 2, YCoord] = " X ";
            }

            if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
            {
                this.Field[XCoord - 1, YCoord - 1] = " X ";
            }

            if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
            {
                this.Field[XCoord, YCoord] = " X ";
            }

            if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
            {
                this.Field[XCoord + 1, YCoord + 1] = " X ";
            }

            if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
            {
                this.Field[XCoord - 1, YCoord + 1] = " X ";
            }

            if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
            {
                this.Field[XCoord, YCoord] = " X ";
            }

            if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
            {
                this.Field[XCoord + 1, YCoord - 1] = " X ";
            }

            if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord - 2 >= 0) && (YCoord - 2 < fieldSize))
            {
                this.Field[XCoord, YCoord - 2] = " X ";
            }

            if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
            {
                this.Field[XCoord, YCoord - 1] = " X ";
            }

            if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
            {
                this.Field[XCoord, YCoord] = " X ";
            }

            if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
            {
                this.Field[XCoord, YCoord + 1] = " X ";
            }

            if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord + 2 >= 0) && (YCoord + 2 < fieldSize))
            {
                this.Field[XCoord, YCoord + 2] = " X ";
            }
        }

        public void DetonateMine4(int XCoord, int YCoord)
        {
            if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
            {
                this.Field[XCoord - 1, YCoord - 1] = " X ";
            }

            if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
            {
                this.Field[XCoord, YCoord - 1] = " X ";
            }

            if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
            {
                this.Field[XCoord + 1, YCoord - 1] = " X ";
            }

            if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
            {
                this.Field[XCoord - 1, YCoord] = " X ";
            }

            if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
            {
                this.Field[XCoord, YCoord] = " X ";
            }

            if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
            {
                this.Field[XCoord + 1, YCoord] = " X ";
            }

            if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
            {
                this.Field[XCoord - 1, YCoord + 1] = " X ";
            }

            if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
            {
                this.Field[XCoord, YCoord + 1] = " X ";
            }

            if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
            {
                this.Field[XCoord + 1, YCoord + 1] = " X ";
            }

            if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord + 2 >= 0) && (YCoord + 2 < fieldSize))
            {
                this.Field[XCoord - 1, YCoord + 2] = " X ";
            }

            if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord + 2 >= 0) && (YCoord + 2 < fieldSize))
            {
                this.Field[XCoord, YCoord + 2] = " X ";
            }

            if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord + 2 >= 0) && (YCoord + 2 < fieldSize))
            {
                this.Field[XCoord + 1, YCoord + 2] = " X ";
            }

            if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord - 2 >= 0) && (YCoord - 2 < fieldSize))
            {
                this.Field[XCoord - 1, YCoord - 2] = " X ";
            }

            if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord - 2 >= 0) && (YCoord - 2 < fieldSize))
            {
                this.Field[XCoord, YCoord - 2] = " X ";
            }

            if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord - 2 >= 0) && (YCoord - 2 < fieldSize))
            {
                this.Field[XCoord + 1, YCoord - 2] = " X ";
            }

            if ((XCoord - 2 >= 0) && (XCoord - 2 < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
            {
                this.Field[XCoord - 2, YCoord - 1] = " X ";
            }

            if ((XCoord - 2 >= 0) && (XCoord - 2 < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
            {
                this.Field[XCoord - 2, YCoord] = " X ";
            }

            if ((XCoord - 2 >= 0) && (XCoord - 2 < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
            {
                this.Field[XCoord - 2, YCoord + 1] = " X ";
            }

            if ((XCoord + 2 >= 0) && (XCoord + 2 < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
            {
                this.Field[XCoord + 2, YCoord - 1] = " X ";
            }

            if ((XCoord + 2 >= 0) && (XCoord + 2 < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
            {
                this.Field[XCoord + 2, YCoord] = " X ";
            }

            if ((XCoord + 2 >= 0) && (XCoord + 2 < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
            {
                this.Field[XCoord + 2, YCoord + 1] = " X ";
            }
        }

        public void GrymniPetaBomba(int XCoord, int YCoord)
        {
            if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
            {
                this.Field[XCoord - 1, YCoord - 1] = " X ";
            }

            if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
            {
                this.Field[XCoord, YCoord - 1] = " X ";
            }

            if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
            {
                this.Field[XCoord + 1, YCoord - 1] = " X ";
            }

            if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
            {
                this.Field[XCoord - 1, YCoord] = " X ";
            }

            if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
            {
                this.Field[XCoord, YCoord] = " X ";
            }

            if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
            {
                this.Field[XCoord + 1, YCoord] = " X ";
            }

            if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
            {
                this.Field[XCoord - 1, YCoord + 1] = " X ";
            }

            if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
            {
                this.Field[XCoord, YCoord + 1] = " X ";
            }

            if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
            {
                this.Field[XCoord + 1, YCoord + 1] = " X ";
            }

            if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord + 2 >= 0) && (YCoord + 2 < fieldSize))
            {
                this.Field[XCoord - 1, YCoord + 2] = " X ";
            }

            if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord + 2 >= 0) && (YCoord + 2 < fieldSize))
            {
                this.Field[XCoord, YCoord + 2] = " X ";
            }

            if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord + 2 >= 0) && (YCoord + 2 < fieldSize))
            {
                this.Field[XCoord + 1, YCoord + 2] = " X ";
            }

            if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord - 2 >= 0) && (YCoord - 2 < fieldSize))
            {
                this.Field[XCoord - 1, YCoord - 2] = " X ";
            }

            if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord - 2 >= 0) && (YCoord - 2 < fieldSize))
            {
                this.Field[XCoord, YCoord - 2] = " X ";
            }

            if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord - 2 >= 0) && (YCoord - 2 < fieldSize))
            {
                this.Field[XCoord + 1, YCoord - 2] = " X ";
            }

            if ((XCoord - 2 >= 0) && (XCoord - 2 < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
            {
                this.Field[XCoord - 2, YCoord - 1] = " X ";
            }

            if ((XCoord - 2 >= 0) && (XCoord - 2 < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
            {
                this.Field[XCoord - 2, YCoord] = " X ";
            }

            if ((XCoord - 2 >= 0) && (XCoord - 2 < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
            {
                this.Field[XCoord - 2, YCoord + 1] = " X ";
            }

            if ((XCoord + 2 >= 0) && (XCoord + 2 < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
            {
                this.Field[XCoord + 2, YCoord - 1] = " X ";
            }

            if ((XCoord + 2 >= 0) && (XCoord + 2 < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
            {
                this.Field[XCoord + 2, YCoord] = " X ";
            }

            if ((XCoord + 2 >= 0) && (XCoord + 2 < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
            {
                this.Field[XCoord + 2, YCoord + 1] = " X ";
            }

            if ((XCoord - 2 >= 0) && (XCoord - 2 < fieldSize) && (YCoord - 2 >= 0) && (YCoord - 2 < fieldSize))
            {
                this.Field[XCoord - 2, YCoord - 2] = " X ";
            }

            if ((XCoord + 2 >= 0) && (XCoord + 2 < fieldSize) && (YCoord - 2 >= 0) && (YCoord - 2 < fieldSize))
            {
                this.Field[XCoord + 2, YCoord - 2] = " X ";
            }

            if ((XCoord - 2 >= 0) && (XCoord - 2 < fieldSize) && (YCoord + 2 >= 0) && (YCoord + 2 < fieldSize))
            {
                this.Field[XCoord - 2, YCoord + 2] = " X ";
            }

            if ((XCoord + 2 >= 0) && (XCoord + 2 < fieldSize) && (YCoord + 2 >= 0) && (YCoord + 2 < fieldSize))
            {
                this.Field[XCoord + 2, YCoord + 2] = " X ";
            }
        }

        public void DisplayField()
        {
            //top side numbers
            Console.Write("   ");
            for (int i = 0; i < fieldSize; i++)
            {
                Console.Write(" " + i.ToString() + "  ");
            }

            Console.WriteLine(string.Empty);
            Console.Write("    ");
            for (int i = 0; i < (4 * fieldSize - 3); i++)
            {
                Console.Write("-");
            }

            Console.WriteLine(string.Empty);
            //top side numbers
            Console.WriteLine(string.Empty);

            for (int i = 0; i < fieldSize; i++)
            {
                //left side numbers
                Console.Write(i.ToString() + "|");
                for (int j = 0; j < fieldSize; j++)
                {
                    Console.Write(" " + this.Field[i, j].ToString());
                }

                Console.WriteLine(string.Empty);
                Console.WriteLine(string.Empty);
                Console.WriteLine(string.Empty);
            }
        }
    }
}
