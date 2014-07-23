namespace BattleFieldGame.GameObjects
{
    using System;
    using BattleFieldGame.Helpers;
    using BattleFieldGame.Interfaces;
    using System.Collections.Generic;

    class MineTile : FieldTile, IMineTile
    {
        private const FieldTileType MineTileType = FieldTileType.MineTile;

        private readonly MineDetonationType detonationType;
        public MineTile(MineDetonationType detonationType)
            : base(MineTile.MineTileType)
        {
            this.detonationType = detonationType;
        }

        public MineDetonationType DetonationType
        {
            get
            {
                return this.detonationType;
            }
        }

        public void Detonate(IMineDetonationStrategy strategy)
        {
            this.Status = FieldTileStatus.Detonated;
            List<Coords> explosionCoords = strategy.GetExplosionCoordinates();

           // Implement detonation strategy
        }
    }
}
