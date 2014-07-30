namespace BattleFieldGame.GameObjects.GameField.MinesCountStrategies
{
    using System;

    public class HardModeMinesCountStrategy : IMinesCountStrategy
    {
        public int GetMinesCount(int fieldSize, Random rnd)
        {
            int cellsCount = fieldSize * fieldSize;
            int minMinesCount = (int)Math.Floor(0.10 * cellsCount);
            int maxMinesCount = (int)Math.Floor(0.20 * cellsCount);
            return rnd.Next(minMinesCount, maxMinesCount);
        }
    }
}
