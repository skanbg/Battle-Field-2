﻿namespace BattleFieldGame.Interfaces
{
    using BattleFieldGame.Helpers;
    using System.Collections.Generic;
   public interface IMineTile : IFieldTile
    {
        MineDetonationType DetonationType { get; }

        List<Coords> ExecuteDetonation();
    }
}
