namespace BattleFieldGame.GameObjects
{
    using BattleFieldGame.Interfaces;
    using BattleFieldGame.GameObjects;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class GameFieldFactory
    {
        public IGameField GetGameField(int fieldSize, GameFieldType gameFieldType = GameFieldType.Matrix)
        {
            switch (gameFieldType)
            {
                case GameFieldType.Matrix:
                    return new GameField(fieldSize);
                    break;
                case GameFieldType.Circle:
                    throw new NotImplementedException();
                    break;
                case GameFieldType.Square:
                    throw new NotImplementedException();
                    break;
                default:
                    throw new ArgumentException();
                    break;
            }
        }
    }
}
