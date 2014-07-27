namespace BattleFieldGame.Interfaces
{
    using BattleFieldGame.Helpers;
    using System.Collections.Generic;

    public interface IMineDetonationStrategy
    {
        List<Coords> GetExplosionCoordinates();

        IMineDetonationStrategy MinorStrategy { get; set; }
    }
}
