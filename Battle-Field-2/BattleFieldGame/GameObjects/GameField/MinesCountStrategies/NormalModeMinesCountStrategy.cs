namespace BattleFieldGame.GameObjects.GameField.MinesCountStrategies
{
    using System;

   public class NormalModeMinesCountStrategy : IMinesCountStrategy
    {
        public int GetMinesCount(int fieldSize, Random rnd)
        {
            int cellsCount = fieldSize * fieldSize;
            int minMinesCount = (int)Math.Floor(0.15 * cellsCount);
            int maxMinesCount = (int)Math.Floor(0.30 * cellsCount);
            return rnd.Next(minMinesCount, maxMinesCount);
        }
    }
}
