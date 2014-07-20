namespace BattleFieldGame.Interfaces
{
    using BattleFieldGame.Helpers;

    public interface IDetonationStrategyFactory
    {
        IMineDetonationStrategy GetDetonationStrategy(MineDetonationType detonationType);
    }
}
