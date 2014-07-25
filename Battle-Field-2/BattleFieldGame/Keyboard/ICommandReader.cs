namespace BattleFieldGame.Keyboard
{
    public interface ICommandReader
    {
        int[] GetCordinates();

        int GetFieldSize();
    }
}
