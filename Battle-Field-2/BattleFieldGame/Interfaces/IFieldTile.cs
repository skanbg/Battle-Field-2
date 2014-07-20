namespace BattleFieldGame.Interfaces
{
    using BattleFieldGame.Helpers;
    interface IFieldTile
    {
        int XCoord { get; }

        int YCoord { get; }

        FieldTileTypes Type { get; }

        FieldTileStatus Status { get; }

        void SetStatus(FieldTileStatus status);
    }
}
