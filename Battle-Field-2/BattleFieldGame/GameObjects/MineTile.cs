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
        private readonly IMineDetonationStrategy detonationStrategy;

        public MineTile(MineDetonationType detonationType, IMineDetonationStrategy detonationStrategy) : base(MineTile.MineTileType)
        {
            this.detonationType = detonationType;
            this.detonationStrategy = detonationStrategy;
        }

        public MineDetonationType DetonationType
        {
            get
            {
                return this.detonationType;
            }
        }

        /// <summary>
        /// Detonates a mine according to its strategy 
        /// and sets it status on the field to detonated.
        /// </summary>
        /// <returns>The coords for detonation</returns>
        public List<Coords> ExecuteDetonation()
        {
            this.Status = FieldTileStatus.Detonated;
            return this.detonationStrategy.GetExplosionCoordinates();
        }
    }
}
