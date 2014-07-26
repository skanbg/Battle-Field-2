namespace BattleFieldGame.Engine
{
    using System;
    using BattleFieldGame.Keyboard;
    using BattleFieldGame.Keyboard.ConsoleIO;

    public class GameEngineFactory
    {
        public IGameEngine GetGameEngine(GameEngineType gameEngineType = GameEngineType.Keyboard)
        {
            switch (gameEngineType)
            {
                case GameEngineType.Keyboard:
                    return new GameEngine(new CommandReader(new ConsoleReader()), new ConsoleWriter());
                case GameEngineType.Mouse:
                    throw new NotImplementedException();
                case GameEngineType.Touch:
                    throw new NotImplementedException();
                default:
                    throw new ArgumentException();
            }
        }
    }
}
