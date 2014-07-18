namespace BattleFieldGame
{
    public abstract class ObjectFactory
    {
        public abstract IGameEngine CreateGameEngine();

        public abstract IGameField CreateGameField(int fieldSize);

    }
}