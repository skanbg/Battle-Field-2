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
        public MineTile(Coords coords, MineDetonationType detonationType)
            : base(coords, MineTile.MineTileType)
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
                var xCoord = coord.X + this.Coordinates.X;
                var yCoord = coord.Y + this.Coordinates.Y;
                if (xCoord >= 0 && xCoord < field.FieldSize && yCoord >= 0 && yCoord < field.FieldSize)
                {
                    //detonate the mine at the position
                }
            }
        }
    }
}
