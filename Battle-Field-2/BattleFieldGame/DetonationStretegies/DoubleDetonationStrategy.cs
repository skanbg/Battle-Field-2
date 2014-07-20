namespace BattleFieldGame.DetonationStretegies
{
    using System.Collections.Generic;
    using BattleFieldGame.Helpers;
    using BattleFieldGame.Interfaces;

    class DoubleDetonationStrategy : IMineDetonationStrategy
    {
        private static readonly List<Coords> explosionCoords;

        static DoubleDetonationStrategy()
        {
            explosionCoords = new List<Coords>()
            {
                new Coords(-1,-1),
                new Coords(-1,0),
                new Coords(-1,+1),
                new Coords(0,-1),
                new Coords(0,+1),
                new Coords(+1,-1),
                new Coords(+1,0),
                new Coords(+1,+1)

            };
        }
        public List<Coords> GetExplosionCoordinates()
        {
            return DoubleDetonationStrategy.explosionCoords;
        }
    }
}