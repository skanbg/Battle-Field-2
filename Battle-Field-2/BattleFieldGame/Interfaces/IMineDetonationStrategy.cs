using BattleFieldGame.Helpers;
using System.Collections.Generic;
namespace BattleFieldGame.Interfaces
{
    interface IMineDetonationStrategy
    {
        List<Coords> GetExplosionCoordinates();
    }
}
