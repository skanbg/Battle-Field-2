namespace BattleFieldGame.DetonationStretegies
{
    using System;
    using System.Collections.Generic;
    using BattleFieldGame.Helpers;
    using BattleFieldGame.Interfaces;

    class SingleDetonationStrategy : IMineDetonationStrategy
    {
        private static readonly List<Coords> explosionCoords;
        private static IMineDetonationStrategy minorStrategy = null;

        /// <summary>
        /// Sets the coords of a mine of type one.
        /// </summary>
        static SingleDetonationStrategy()
        {
            explosionCoords = new List<Coords>()
            {
                new Coords(-1, -1),
                new Coords(+1, -1),
                new Coords(-1, +1),
                new Coords(+1, +1)
            };
        }

        public IMineDetonationStrategy MinorStrategy
        {
            get { return SingleDetonationStrategy.minorStrategy; }
            set { SingleDetonationStrategy.minorStrategy = value; }
        }

        /// <summary>
        /// Gets the explosion coords.
        /// </summary>
        /// <returns>Returns a list with coords for detonation.</returns>
        public List<Coords> GetExplosionCoordinates()
        {
            List<Coords> currentExplosionCoords = SingleDetonationStrategy.explosionCoords;
            if (this.MinorStrategy != null)
            {
                List<Coords> minorExplosionCoords = this.MinorStrategy.GetExplosionCoordinates();
                currentExplosionCoords.AddRange(minorExplosionCoords);
            }

            return currentExplosionCoords;
        }
    }
}
