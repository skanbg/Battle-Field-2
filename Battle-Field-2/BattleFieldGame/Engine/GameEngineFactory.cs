using BattleFieldGame.Engine;
using BattleFieldGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleFieldGame.Factories
{
    public class GameEngineFactory
    {
        public IGameEngine GetGameEngine(GameEngineType gameEngineType = GameEngineType.Keyboard)
        {
            switch (gameEngineType)
            {
                case GameEngineType.Keyboard:
                    return new GameEngine();
                    break;
                case GameEngineType.Mouse:
                    throw new NotImplementedException();
                    break;
                case GameEngineType.Touch:
                    throw new NotImplementedException();
                    break;
                default:
                    throw new ArgumentException();
                    break;
            }
        }
    }
}
