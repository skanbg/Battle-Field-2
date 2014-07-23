using BattleFieldGame.Helpers;
using System.Collections.Generic;
namespace BattleFieldGame.Interfaces
{
   public interface IMineDetonationStrategy
    {
        List<Coords> GetExplosionCoordinates();
    }
}
