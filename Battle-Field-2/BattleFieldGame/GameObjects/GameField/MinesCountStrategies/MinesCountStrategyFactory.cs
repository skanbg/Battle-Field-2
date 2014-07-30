namespace BattleFieldGame.GameObjects.GameField.MinesCountStrategies
{
   public class MinesCountStrategyFactory : IMinesCountStrategyFactory
    {
        public IMinesCountStrategy GetEasy()
        {
            return new EasyModeMinesCountStrategy();
        }

        public IMinesCountStrategy GetNormal()
        {
            return new NormalModeMinesCountStrategy();
        }

        public IMinesCountStrategy GetHard()
        {
            return new HardModeMinesCountStrategy();
        }
    }
}
