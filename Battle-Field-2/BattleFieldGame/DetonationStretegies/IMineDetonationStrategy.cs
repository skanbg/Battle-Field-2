namespace BattleFieldGame.Interfaces
{
    using System.Collections.Generic;
    using BattleFieldGame.Helpers;

    public interface IMineDetonationStrategy
    {
        IMineDetonationStrategy MinorStrategy { get; set; }

        List<Coords> GetExplosionCoordinates();
    }
}
