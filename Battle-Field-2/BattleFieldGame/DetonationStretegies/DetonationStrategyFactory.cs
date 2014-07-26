namespace BattleFieldGame.DetonationStretegies
{
    using System;
    using System.Collections.Generic;
    using BattleFieldGame.Helpers;
    using BattleFieldGame.Interfaces;

    public class DetonationStrategyFactory : IDetonationStrategyFactory
    {
        private static IDictionary<MineDetonationType, IMineDetonationStrategy> generatedMines;

        /// <summary>
        /// Creates the generated mines by thier type and strategy of detonation.
        /// </summary>
        public DetonationStrategyFactory()
        {
            DetonationStrategyFactory.generatedMines = new Dictionary<MineDetonationType, IMineDetonationStrategy>();
        }

        /// <summary>
        /// Checks for a detonation strategy and generates mines according to its type.
        /// </summary>
        /// <param name="detonationType"></param>
        /// <returns>Returns the strategy of detonation.</returns>
        public IMineDetonationStrategy GetDetonationStrategy(MineDetonationType detonationType)
        {
            IMineDetonationStrategy strategy;

            if (DetonationStrategyFactory.generatedMines.ContainsKey(detonationType))
            {
                strategy = DetonationStrategyFactory.generatedMines[detonationType];
            }
            else
            {
                switch (detonationType)
                {
                    case MineDetonationType.Single:
                        strategy = new SingleDetonationStrategy();
                        break;
                    case MineDetonationType.Double:
                        strategy = new DoubleDetonationStrategy();
                        break;
                    case MineDetonationType.Triple:
                        strategy = new TripleDetonationStretegy();
                        break;
                    case MineDetonationType.Quadriple:
                        strategy = new QuadripleDetonationStrategy();
                        break;
                    case MineDetonationType.Quintuple:
                        strategy = new QuintupleDetonationStrategy();
                        break;
                    default:
                        throw new InvalidOperationException("Unsupported detonation type!");
                }
                
                DetonationStrategyFactory.generatedMines.Add(detonationType, strategy);
            }
            return strategy;
        }
    }
}
