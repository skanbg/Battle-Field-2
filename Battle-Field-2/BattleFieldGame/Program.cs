namespace BattleFieldGame
{
    using System;
    using BattleFieldGame.Factories;

    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Welcome to the Battle Field game");

            ObjectFactory factory = new GameFactory();

            var gameEngine = Factory.Get().CreateGameEngine();
            gameEngine.Start();
        }
    }
}
