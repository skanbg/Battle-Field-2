namespace BattleFieldGame.GameObjects.FieldTiles
{
    using System.Collections.Generic;
    using BattleFieldGame.Helpers;

    public interface IMineTile : IFieldTile
    {
        MineDetonationType DetonationType { get; }

        List<Coords> ExecuteDetonation();
    }
}
