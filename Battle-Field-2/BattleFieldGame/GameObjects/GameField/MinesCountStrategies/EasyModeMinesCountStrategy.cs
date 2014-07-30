namespace BattleFieldGame.GameObjects.GameField.MinesCountStrategies
{
    using System;

   public class EasyModeMinesCountStrategy : IMinesCountStrategy
    {
        public int GetMinesCount(int fieldSize, Random rnd)
        {
            int cellsCount = fieldSize * fieldSize;
            int minMinesCount = (int)Math.Floor(0.30 * cellsCount);
            int maxMinesCount = (int)Math.Floor(0.45 * cellsCount);
            return rnd.Next(minMinesCount, maxMinesCount);
        }
    }
}
