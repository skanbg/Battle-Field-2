namespace BattleFieldGame.GameObjects.GameField.MinesCountStrategies
{
    public interface IMinesCountStrategyFactory
    {
        IMinesCountStrategy GetEasy();

        IMinesCountStrategy GetNormal();

        IMinesCountStrategy GetHard();
    }
}