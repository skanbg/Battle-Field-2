namespace BattleFieldGame.Renderer
{
    using System;
    using BattleFieldGame.GameObjects;
    using BattleFieldGame.Interfaces;
    using BattleFieldGame.Helpers;

    public class GameFieldConsoleRenderer : IGameFieldRenderer
    {
        private const char DetonatedTileSymbol = '*';
        private const char EmptyTileSymbol = '-';
        
        public void Render(IGameField field) // Refactor -> StringBuilder
        {
            var tiles = field.Field;

            for (int i = 0; i < tiles.GetLength(0); i++)
            {
                if (i == 0)
                {
                    Console.Write("   " + i + " ");
                    continue;
                }
                Console.Write(" " + i + " ");
            }
            Console.WriteLine();
            Console.WriteLine();

            for (int i = 0; i < tiles.GetLength(0); i++)
            {
                Console.Write(i + " ");
                for (int j = 0; j < tiles.GetLength(1); j++)
                {
                    var item = tiles[i, j];
                    Console.Write(" " + GetTileSymbol(item) + " ");
                }
                Console.WriteLine();
            }
        }


        private char GetTileSymbol(IFieldTile tile)
        {
            if (tile.Status == FieldTileStatus.Detonated)
            {
                return GameFieldConsoleRenderer.DetonatedTileSymbol;
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
            return GameFieldConsoleRenderer.EmptyTileSymbol;
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
