namespace BattleFieldGame.DetonationStretegies
{
    using System.Collections.Generic;
    using BattleFieldGame.Helpers;
    using BattleFieldGame.Interfaces;

    public class QuadripleDetonationStrategy : IMineDetonationStrategy
    {
        private static readonly List<Coords> ExplosionCoords;
        private static IMineDetonationStrategy minorStrategy = null;

        /// <summary>
        /// Sets the coords of a mine of type four.
        /// </summary>
        static QuadripleDetonationStrategy()
        {
            ExplosionCoords = new List<Coords>()
            {
                new Coords(-1, -2),
                new Coords(+1, -2),
                new Coords(-2, -1),
                new Coords(+2, -1),
                new Coords(-2, +1),
                new Coords(+2, +1),
                new Coords(-1, +2),
                new Coords(+1, +2),
            };
        }

        public IMineDetonationStrategy MinorStrategy
        {
            get { return QuadripleDetonationStrategy.minorStrategy; }
            set { QuadripleDetonationStrategy.minorStrategy = value; }
        }

        /// <summary>
        /// Gets the explosion coords.
        /// </summary>
        /// <returns>Returns a list with coords for detonation.</returns>
        public List<Coords> GetExplosionCoordinates()
        {
            List<Coords> currentExplosionCoords = QuadripleDetonationStrategy.ExplosionCoords;
            if (this.MinorStrategy != null)
            {
                List<Coords> minorExplosionCoords = this.MinorStrategy.GetExplosionCoordinates();
                currentExplosionCoords.AddRange(minorExplosionCoords);
            }

            return currentExplosionCoords;
        }
    }
}