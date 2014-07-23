namespace BattleFieldGame.GameObjects
{
    using System;
    using BattleFieldGame.Helpers;
    using BattleFieldGame.Interfaces;

    public abstract class FieldTile : IFieldTile
    {
        private readonly FieldTileType type;
        private FieldTileStatus status;
        protected FieldTile(FieldTileType type)
        {
            this.type = type;
        }
            
        public FieldTileType Type
        {
            get
            {
                return this.type;
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