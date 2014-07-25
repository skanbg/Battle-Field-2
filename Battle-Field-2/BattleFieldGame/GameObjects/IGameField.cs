namespace BattleFieldGame.Interfaces
{
    public interface IGameField
    {
        int FieldSize
        {
            get;
        }

        int DetonatedMines
        {
            get;
        }

        int MinesCount
        {
            get;
        }

        IFieldTile[,] Field
        {
            get;
        }

        void DetonateMine(int xCoord, int yCoord);
    }
}
