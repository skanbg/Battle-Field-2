namespace BattleFieldGame.GameObjects
{
    using BattleFieldGame.Helpers;

    class EmptyFieldTile : FieldTile
    {
        private const FieldTileType EmptyTileType = FieldTileType.EmptyTile;
        public EmptyFieldTile()
            : base(EmptyFieldTile.EmptyTileType)
        {

        }
    }
}
