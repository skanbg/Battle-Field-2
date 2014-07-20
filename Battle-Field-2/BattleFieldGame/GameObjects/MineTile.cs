namespace BattleFieldGame.GameObjects
{
    using System;
    using BattleFieldGame.Helpers;
    using BattleFieldGame.Interfaces;

    class MineTile : FieldTile, IMineTile
    {
        public MineTile(Coords coords, FieldTileType type) : base(coords, type)
        {
        }

        public MineDetonationType type
        {
            get
            {
                // TODO: Implement this property getter
                throw new NotImplementedException();
            }
        }

        public void Detonate(IGameField field, IMineDetonationStrategy strategy)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }
    }
}
