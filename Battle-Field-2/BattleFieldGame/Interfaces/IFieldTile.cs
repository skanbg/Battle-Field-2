namespace BattleFieldGame.Interfaces
{
    using BattleFieldGame.Helpers;
   public interface IFieldTile
    {

        FieldTileType TileType { get; }

        FieldTileStatus Status { get; }

        void SetStatus(FieldTileStatus status);
    }
}
