namespace BattleFieldGame.GameObjects.FieldTiles
{
    using System;
    using BattleFieldGame.Helpers;

    public abstract class FieldTile : IFieldTile
    {
        private readonly FieldTileType tileType;
        private FieldTileStatus status;

        protected FieldTile(FieldTileType type)
        {
            this.tileType = type;
        }
            
        public FieldTileType TileType
        {
            get
            {
                return this.tileType;
            }
        }

        public FieldTileStatus Status
        {
            get
            {
                return this.status;
            }
             set
            {
                this.status = value;
            }
        }     
    }
}