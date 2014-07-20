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
        public MineTile(Coords coords, MineDetonationType detonationType) : base(coords, MineTile.MineTileType)
        {
            this.detonationType = detonationType;
        }

        public MineDetonationType Type
        {
            get
            {
                return this.detonationType;
            }
        }

        public void Detonate(IGameField field, IMineDetonationStrategy strategy)
        {
            this.SetStatus(FieldTileStatus.Detonated);
            List<Coords> explosionCoords = strategy.GetExplosionCoordinates();
            foreach (var coord in explosionCoords)
            {
                if (coord.X >=0 && coord.X < field.FieldSize && coord.Y >=0 && coord.Y < field.FieldSize)
                {
                    //detonate the mine at the position
                }
            }
        }
    }
}
