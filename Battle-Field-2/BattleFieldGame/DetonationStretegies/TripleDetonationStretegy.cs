namespace BattleFieldGame.DetonationStretegies
{
    using System.Collections.Generic;
    using BattleFieldGame.Helpers;
    using BattleFieldGame.Interfaces;

    public class TripleDetonationStretegy : IMineDetonationStrategy
    {
        private static readonly List<Coords> explosionCoords;
        private static IMineDetonationStrategy minorStrategy = null;

        /// <summary>
        /// Sets the coords of a mine of type three.
        /// </summary>
        static TripleDetonationStretegy()
        {
            explosionCoords = new List<Coords>()
            {
                new Coords(0, -2),
                new Coords(-2, 0),
                new Coords(+2, 0),
                new Coords(0, +2)
            };
        }

        public IMineDetonationStrategy MinorStrategy
        {
            get { return TripleDetonationStretegy.minorStrategy; }
            set { TripleDetonationStretegy.minorStrategy = value; }
        }

        /// <summary>
        /// Gets the explosion coords.
        /// </summary>
        /// <returns>Returns a list with coords for detonation.</returns>
        public List<Coords> GetExplosionCoordinates()
        {
            List<Coords> currentExplosionCoords = TripleDetonationStretegy.explosionCoords;
            if (this.MinorStrategy != null)
            {
                List<Coords> minorExplosionCoords = this.MinorStrategy.GetExplosionCoordinates();
                currentExplosionCoords.AddRange(minorExplosionCoords);
            }

            return currentExplosionCoords;
        }
    }
}