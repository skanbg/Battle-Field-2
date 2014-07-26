namespace BattleFieldGame.Engine
{
    using BattleFieldGame.Keyboard;
    using BattleFieldGame.Keyboard.ConsoleIO;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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
