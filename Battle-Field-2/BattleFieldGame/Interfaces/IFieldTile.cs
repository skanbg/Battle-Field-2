namespace BattleFieldGame.Interfaces
{
    using BattleFieldGame.Helpers;
    interface IFieldTile
    {

        FieldTileType TileType { get; }

        FieldTileStatus Status { get; }

        void SetStatus(FieldTileStatus status);
    }
}
