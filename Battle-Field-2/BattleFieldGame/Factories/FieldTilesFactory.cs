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
        public IMineTile GetMineTile(MineDetonationType detonationType)
        {
            return new MineTile(detonationType);
        }
    }
}
