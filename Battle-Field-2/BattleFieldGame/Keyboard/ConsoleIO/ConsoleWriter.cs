namespace BattleFieldGame.Keyboard.ConsoleIO
{
    using System;
    using System.Text;
    using BattleFieldGame.GameObjects;
    using BattleFieldGame.Helpers;

    public class ConsoleWriter : IConsoleWriter
    {
        private const char DetonatedTileSymbol = '*';
        private const char EmptyTileSymbol = '-';

        public void WriteField(IGameField field) // Refactor -> StringBuilder
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < field.GetRowsCount(); i++)
            {
                if (i == 0)
                {
                    result.AppendFormat(String.Format("   {0} ", i));
                    continue;
                }

                result.AppendFormat(String.Format(" {0} ", i));
            }

            result.AppendLine();
            result.AppendLine();

            for (int i = 0; i < field.GetRowsCount(); i++)
            {
                result.AppendFormat(string.Format("{0} ", i));

                for (int j = 0; j < field.GetColumnsCount(); j++)
                {
                    var item = field[i, j];
                    result.AppendFormat(string.Format(" {0} ", GetTileSymbol(item)));
                }

                result.AppendLine();
            }

            Console.WriteLine(result.ToString());

            //for (int i = 0; i < field.GetRowsCount(); i++)
            //{
            //    if (i == 0)
            //    {
            //        Console.Write("   " + i + " ");
            //        continue;
            //    }
            //    Console.Write(" " + i + " ");
            //}
            //Console.WriteLine();
            //Console.WriteLine();

            //for (int i = 0; i < field.GetRowsCount(); i++)
            //{
            //    Console.Write(i + " ");
            //    for (int j = 0; j < field.GetColumnsCount(); j++)
            //    {
            //        var item = field[i, j];
            //        Console.Write(" " + GetTileSymbol(item) + " ");
            //    }
            //    Console.WriteLine();
            //}
        }

        public void WriteMessage(string message)
        {
            Console.Write(message);
        }

        private char GetTileSymbol(IFieldTile tile)
        {
            if (tile.Status == FieldTileStatus.Detonated)
            {
                return ConsoleWriter.DetonatedTileSymbol;
            }

            switch (tile.TileType)
            {
                case FieldTileType.EmptyTile:
                    return GetEmptyTileSymbol(tile);
                case FieldTileType.MineTile:
                    return GetMineSymbol(tile as IMineTile);
                default:
                    throw new ArgumentException("Invalid tile type!");
            }
        }

        private char GetMineSymbol(IMineTile mine)
        {
            switch (mine.DetonationType)
            {
                case MineDetonationType.Single:
                    return '1';
                case MineDetonationType.Double:
                    return '2';
                case MineDetonationType.Triple:
                    return '3';
                case MineDetonationType.Quadriple:
                    return '4';
                case MineDetonationType.Quintuple:
                    return '5';
                default:
                    throw new ArgumentException("Invalid mine detonation type!");
            }
        }

        private char GetEmptyTileSymbol(IFieldTile tile)
        {
            return ConsoleWriter.EmptyTileSymbol;
        }

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
