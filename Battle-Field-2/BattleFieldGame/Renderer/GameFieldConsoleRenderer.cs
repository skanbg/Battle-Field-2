namespace BattleFieldGame.Renderer
{
    using System;
    using BattleFieldGame.GameObjects;
    using BattleFieldGame.Interfaces;

    public class GameFieldConsoleRenderer : IGameFieldRenderer
    {
        public void Render(IGameField field)
        {
            var tiles = field.Field;
            var counter = 0;
            foreach (var item in tiles)
            {
                if (item is MineTile)
                {
                    Console.Write(" M ");
                }
                else
                {
                    Console.Write(" E ");
                }
                if (counter % field.FieldSize == 0)
                {
                    Console.WriteLine();
                }
                counter++;
            }

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
