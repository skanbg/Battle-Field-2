namespace BattleFieldGame.Factories
{
    public static class Factory
    {
        private static ObjectFactory factory;

        static Factory()
        {
            factory = new GameFactory();
        }

        public static ObjectFactory Get()
        {
            return factory;
        }
    }
}
