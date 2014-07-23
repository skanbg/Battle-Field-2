namespace BattleFieldGame.GameObjects
{
    using System;
    using BattleFieldGame.Helpers;
    using BattleFieldGame.Interfaces;

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
            protected set
            {
                this.status = value;
            }
        }

        public virtual void SetStatus(FieldTileStatus status)
        {
            // Additional validation and actions
            this.Status = status;
        }
    }
}