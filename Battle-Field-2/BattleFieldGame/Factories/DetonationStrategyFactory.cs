namespace BattleFieldGame.Factories
{
    using System;
    using BattleFieldGame.Helpers;
    using BattleFieldGame.Interfaces;
    using BattleFieldGame.DetonationStretegies;

    public class DetonationStrategyFactory : IDetonationStrategyFactory
    {
        public IMineDetonationStrategy GetDetonationStrategy(MineDetonationType detonationType)
        {
            switch (detonationType)
            {
                case MineDetonationType.Single:
                    return new SingleDetonationStrategy();
                case MineDetonationType.Double:
                    return new DoubleDetonationStrategy();
                case MineDetonationType.Triple:
                    return new TripleDetonationStretegy();
                case MineDetonationType.Quadriple:
                    return new QuadripleDetonationStrategy();
                case MineDetonationType.Quintuple:
                    return new QuintupleDetonationStrategy();
                default:
                    throw new InvalidOperationException("Unsupported detonation type!");
            }
        }
    }
}
