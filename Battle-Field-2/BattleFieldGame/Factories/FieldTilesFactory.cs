namespace BattleFieldGame.Factories
{
    using BattleFieldGame.Interfaces;
    using BattleFieldGame.GameObjects;
    using BattleFieldGame.Helpers;
    public class FieldTilesFactory
    {
        public IFieldTile GetEmptyTile()
        {
            return new EmptyFieldTile();
        }
        public IMineTile GetMineTile(MineDetonationType detonationType, IMineDetonationStrategy detonationStrategy)
        {
            return new MineTile(detonationType, detonationStrategy);
        }
    }
}
