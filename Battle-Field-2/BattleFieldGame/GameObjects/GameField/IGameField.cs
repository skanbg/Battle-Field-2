namespace BattleFieldGame.GameObjects.GameField
{
    using BattleFieldGame.GameObjects;
    using BattleFieldGame.GameObjects.FieldTiles;

    public interface IGameField
    {
        int DetonatedMines
        {
            get;
        }

        int MinesCount
        {
            get;
        }

        int FieldSize
        {
            get;
        }

        IFieldTile this[int col, int row]
        {
            get;
        }

        int GetRowsCount();

        int GetColumnsCount();

        void DetonateMine(int xCoord, int yCoord);
    }
}
