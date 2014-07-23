namespace BattleFieldGame.Interfaces
{
    using BattleFieldGame.Helpers;
    interface IFieldTile
    {

        FieldTileType Type { get; }

        FieldTileStatus Status { get; }

        void SetStatus(FieldTileStatus status);
    }
}
