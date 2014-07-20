namespace BattleFieldGame.DetonationStretegies
{
    using System;
    using System.Collections.Generic;
    using BattleFieldGame.Helpers;
    using BattleFieldGame.Interfaces;

    class SingleDetonationStrategy : IMineDetonationStrategy
    {
         private static readonly List<Coords> explosionCoords;

         static SingleDetonationStrategy()
         {
             explosionCoords =  new List<Coords>()
            {
                new Coords(-1,-1),
                new Coords(-1,+1),
                new Coords(+1,-1),
                new Coords(+1,+1)
            };
         }
        public List<Coords> GetExplosionCoordinates()
        {
            return SingleDetonationStrategy.explosionCoords;
        }
    }
}
