namespace BattleFieldGame.Interfaces
{
    using BattleFieldGame.Helpers;
    interface IFieldTile
    {
        Coords Coordinates { get; }
        
        FieldTileType Type { get; }

        FieldTileStatus Status { get; }

        void SetStatus(FieldTileStatus status);
    }
}
