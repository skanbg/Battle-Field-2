namespace BattleFieldGame.GameObjects
{
    using BattleFieldGame.Helpers;
   public interface IFieldTile
    {

        FieldTileType TileType { get; }

        FieldTileStatus Status { get; set; }

    }
}
