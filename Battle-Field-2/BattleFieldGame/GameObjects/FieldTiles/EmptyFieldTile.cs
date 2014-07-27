namespace BattleFieldGame.GameObjects.FieldTiles
{
    using BattleFieldGame.Helpers;

    public class EmptyFieldTile : FieldTile
    {
        private const FieldTileType EmptyTileType = FieldTileType.EmptyTile;

        public EmptyFieldTile()
            : base(EmptyFieldTile.EmptyTileType)
        {

        }
    }
}
