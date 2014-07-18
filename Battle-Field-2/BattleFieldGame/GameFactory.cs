namespace BattleFieldGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class GameFactory : ObjectFactory
    {
        public override IGameEngine CreateGameEngine()
        {
            return new GameEngine();
        }

        public override IGameField CreateGameField(int fieldSize)
        {
            return new GameField(fieldSize);
        }
    }
}
