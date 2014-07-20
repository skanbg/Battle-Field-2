namespace BattleFieldGame.GameObjects
{
    using BattleFieldGame.Helpers;

    class EmptyFieldTile : FieldTile
    {
        private const FieldTileType Type = FieldTileType.EmptyTile;
        public EmptyFieldTile(Coords coords)
            : base(coords, EmptyFieldTile.Type)
        {

        }
    }
}
