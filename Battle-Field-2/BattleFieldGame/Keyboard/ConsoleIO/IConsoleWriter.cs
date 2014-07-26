namespace BattleFieldGame.Keyboard.ConsoleIO
{
    using BattleFieldGame.GameObjects;

    public interface IConsoleWriter
    {
        void WriteField(IGameField field);
    }
}
