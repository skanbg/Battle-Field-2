namespace BattleFieldGame.Factories
{
    using BattleFieldGame.Interfaces;
    using BattleFieldGame.Engine;
    using BattleFieldGame.GameObjects;

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
