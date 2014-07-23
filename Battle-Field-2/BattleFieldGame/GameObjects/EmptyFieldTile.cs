namespace BattleFieldGame.GameObjects
{
    using BattleFieldGame.Helpers;

    class EmptyFieldTile : FieldTile
    {
        private new const FieldTileType Type = FieldTileType.EmptyTile;
        public EmptyFieldTile()
            : base(EmptyFieldTile.Type)
        {

        }
    }
}
