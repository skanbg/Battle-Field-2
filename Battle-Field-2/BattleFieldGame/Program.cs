namespace BattleFieldGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Welcome to the Battle Field game");

            var gameEngine = new GameEngine();
            gameEngine.Start();
        }
    }
}
