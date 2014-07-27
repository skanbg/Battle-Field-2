namespace BattleFieldGame.GameObjects.GameField
{
    using System;

    public class GameFieldFactory : IGameFieldFactory
    {
        public IGameField GetGameField(int fieldSize, GameFieldType gameFieldType = GameFieldType.Matrix)
        {
            switch (gameFieldType)
            {
                case GameFieldType.Matrix:
                    return new GameField(fieldSize);
                case GameFieldType.Circle:
                    throw new NotImplementedException();
                case GameFieldType.Square:
                    throw new NotImplementedException();
                default:
                    throw new ArgumentException();
            }
        }
    }
}
