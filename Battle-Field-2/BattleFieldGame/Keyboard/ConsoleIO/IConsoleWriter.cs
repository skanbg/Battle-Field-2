namespace BattleFieldGame.Keyboard.ConsoleIO
{
    using BattleFieldGame.GameObjects.GameField;
 
    public interface IConsoleWriter
    {
        void WriteField(IGameField field);

        void WriteMessage(string message);
    }
}
