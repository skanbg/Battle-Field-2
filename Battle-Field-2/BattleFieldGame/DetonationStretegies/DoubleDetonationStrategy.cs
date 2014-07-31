namespace BattleFieldGame.DetonationStretegies
{
    using System.Collections.Generic;
    using BattleFieldGame.Helpers;
    using BattleFieldGame.Interfaces;

    public class DoubleDetonationStrategy : IMineDetonationStrategy
    {
        private static readonly List<Coords> ExplosionCoords;
        private static IMineDetonationStrategy minorStrategy = null;

        /// <summary>
        /// Sets the coords of a mine of type two.
        /// </summary>
        static DoubleDetonationStrategy()
        {
            ExplosionCoords = new List<Coords>()
            {
                new Coords(0, -1),
                new Coords(-1, 0),
                new Coords(+1, 0),
                new Coords(0, +1)
            };
        }

        public IMineDetonationStrategy MinorStrategy
        {
            get { return DoubleDetonationStrategy.minorStrategy; }
            set { DoubleDetonationStrategy.minorStrategy = value; }
        }

        /// <summary>
        /// Gets the explosion coords.
        /// </summary>
        /// <returns>Returns a list with coords for detonation.</returns>
        public List<Coords> GetExplosionCoordinates()
        {
            List<Coords> currentExplosionCoords = DoubleDetonationStrategy.ExplosionCoords;
            if (this.MinorStrategy != null)
            {
                List<Coords> minorExplosionCoords = this.MinorStrategy.GetExplosionCoordinates();
                currentExplosionCoords.AddRange(minorExplosionCoords);
            }

            return currentExplosionCoords;
        }
    }
}