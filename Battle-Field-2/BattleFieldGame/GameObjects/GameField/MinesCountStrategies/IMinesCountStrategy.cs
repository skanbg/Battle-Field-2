namespace BattleFieldGame.GameObjects.GameField.MinesCountStrategies
{
    using System;

    public interface IMinesCountStrategy
    {
        int GetMinesCount(int fieldSize, Random rnd);
    }
}
