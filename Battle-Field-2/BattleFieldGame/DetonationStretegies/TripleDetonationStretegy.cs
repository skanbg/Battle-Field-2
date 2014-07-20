namespace BattleFieldGame.DetonationStretegies
{
    using System.Collections.Generic;
    using BattleFieldGame.Helpers;
    using BattleFieldGame.Interfaces;

    class TripleDetonationStretegy : IMineDetonationStrategy
    {
        private static readonly List<Coords> explosionCoords;

        static TripleDetonationStretegy()
        {
            explosionCoords = new List<Coords>()
            {
                new Coords(-2,0),
                new Coords(-1,-1),
                new Coords(-1,0),
                new Coords(-1,+1),
                new Coords(0,-2),
                new Coords(0,-1),
                new Coords(0,+1),
                new Coords(0,+2),
                new Coords(+1,-1),
                new Coords(+1,0),
                new Coords(+1,+1),
                new Coords(+2,0)
            };
        }
        public List<Coords> GetExplosionCoordinates()
        {
            return TripleDetonationStretegy.explosionCoords;
        }
    }
}