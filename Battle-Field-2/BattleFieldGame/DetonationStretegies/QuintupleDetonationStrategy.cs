namespace BattleFieldGame.DetonationStretegies
{
    using System.Collections.Generic;
    using BattleFieldGame.Helpers;
    using BattleFieldGame.Interfaces;

    public class QuintupleDetonationStrategy : IMineDetonationStrategy
    {
        private static readonly List<Coords> explosionCoords;
        private static IMineDetonationStrategy minorStrategy = null;

        /// <summary>
        /// Sets the coords of a mine of type five.
        /// </summary>
        static QuintupleDetonationStrategy()
        {
            explosionCoords = new List<Coords>()
            {
                new Coords(-2, -2),
                new Coords(+2, -2),
                new Coords(-2, +2),
                new Coords(+2, +2)
            };
        }

        /// <summary>
        /// Gets the explosion coords.
        /// </summary>
        /// <returns>Returns a list with coords for detonation.</returns>
        public IMineDetonationStrategy MinorStrategy
        {
            get { return QuintupleDetonationStrategy.minorStrategy; }
            set { QuintupleDetonationStrategy.minorStrategy = value; }
        }

        /// <summary>
        /// Gets the explosion coords.
        /// </summary>
        /// <returns>Returns a list with coords for detonation.</returns>
        public List<Coords> GetExplosionCoordinates()
        {
            List<Coords> currentExplosionCoords = QuintupleDetonationStrategy.explosionCoords;
            if (this.MinorStrategy != null)
            {
                List<Coords> minorExplosionCoords = this.MinorStrategy.GetExplosionCoordinates();
                currentExplosionCoords.AddRange(minorExplosionCoords);
            }

            return currentExplosionCoords;
        }
    }
}