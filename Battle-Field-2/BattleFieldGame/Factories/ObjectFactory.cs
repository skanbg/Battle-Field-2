namespace BattleFieldGame.Factories
{
    using BattleFieldGame.Interfaces;
    public abstract class ObjectFactory
    {
        public abstract IGameEngine CreateGameEngine();

        public abstract IGameField CreateGameField(int fieldSize);

    }
}