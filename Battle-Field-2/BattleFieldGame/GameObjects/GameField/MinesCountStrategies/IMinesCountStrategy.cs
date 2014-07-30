namespace BattleFieldGame.GameObjects.GameField.MinesCountStrategies
{
    using System;
    interface IMinesCountStrategy
    {
        int GetMinesCount(int fieldSize,  Random rnd);
    }
}
