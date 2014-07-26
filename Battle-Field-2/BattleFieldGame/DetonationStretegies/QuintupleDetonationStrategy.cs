namespace BattleFieldGame.DetonationStretegies
{
    using System.Collections.Generic;
    using BattleFieldGame.Helpers;
    using BattleFieldGame.Interfaces;

    class QuintupleDetonationStrategy : IMineDetonationStrategy
    {
        private static readonly List<Coords> explosionCoords;

        /// <summary>
        /// Sets the coords of a mine of type five.
        /// </summary>
        static QuintupleDetonationStrategy()
        {
            explosionCoords = new List<Coords>()
            {
                new Coords(-2,-2),
                new Coords(-2,-1),
                new Coords(-2,0),
                new Coords(-2,+1),
                new Coords(-2,+2),
                new Coords(-1,-2),
                new Coords(-1,-1),
                new Coords(-1,0),
                new Coords(-1,+1),
                new Coords(-1,+2),
                new Coords(0,-2),
                new Coords(0,-1),
                new Coords(0,+1),
                new Coords(0,+2),
                new Coords(+1,-2),
                new Coords(+1,-1),
                new Coords(+1,0),
                new Coords(+1,+1),
                new Coords(+1,+2),
                new Coords(+2,-2),
                new Coords(+2,-1),
                new Coords(+2,0),
                new Coords(+2,+1),
                new Coords(+2,+2)
               
            };
         }

        /// <summary>
        /// Gets the explosion coords.
        /// </summary>
        /// <returns>Returns a list with coords for detonation.</returns>
        public List<Coords> GetExplosionCoordinates()
        {
        return QuintupleDetonationStrategy.explosionCoords;
        }
    }
}