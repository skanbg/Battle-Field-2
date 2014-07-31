namespace BattleFieldGame
{
    using System;
    using BattleFieldGame.Engine;

    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Welcome to the Battle Field game");

            GameEngineFactory gameEngineFactory = new GameEngineFactory();
            IGameEngine gameEngine = gameEngineFactory.GetGameEngine(GameEngineType.Keyboard);
            gameEngine.StartBattleFieldGame();
        }
    }
}