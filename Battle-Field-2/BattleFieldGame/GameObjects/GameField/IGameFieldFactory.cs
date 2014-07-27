namespace BattleFieldGame.GameObjects.GameField
{
    using System;

    public interface IGameFieldFactory
    {
        IGameField GetGameField(int fieldSize, GameFieldType gameFieldType);
    }
}