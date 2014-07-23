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

        //void DetonateMine(int XCoord, int YCoord);

        //void DetonateMine1(int XCoord, int YCoord);

        //void DetonateMine2(int XCoord, int YCoord);

        //void DetonateMine3(int XCoord, int YCoord);

        //void DetonateMine4(int XCoord, int YCoord);

        //void GrymniPetaBomba(int XCoord, int YCoord);

        //void DisplayField();
    }
}
