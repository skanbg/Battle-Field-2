namespace BattleFieldGame
{
    using System;
    using BattleFieldGame.Factories;
    using BattleFieldGame.Interfaces;

    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Welcome to the Battle Field game");

            GameEngineFactory gameEngineFactory = new GameEngineFactory();
            IGameEngine gameEngine = gameEngineFactory.GetGameEngine(GameEngineType.Keyboard);
            gameEngine.Start();
        }
    }
}
