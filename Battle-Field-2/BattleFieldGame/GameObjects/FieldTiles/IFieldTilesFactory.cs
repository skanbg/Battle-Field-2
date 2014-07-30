namespace BattleFieldGame.GameObjects.FieldTiles
{
    using BattleFieldGame.Helpers;
    using BattleFieldGame.Interfaces;

    public interface IFieldTilesFactory
    {
        /// <summary>
        /// Creates an empty tile
        /// </summary>
        /// <returns>An empty tile</returns>
        IFieldTile GetEmptyTile();

        /// <summary>
        /// Creates a mine tile with detonation type and strategy.
        /// </summary>
        /// <param name="detonationType">The specified detonation type</param>
        /// <param name="detonationStrategy">The specified strategy if detonation</param>
        /// <returns>A new mine tile with the specified params</returns>
        IMineTile GetMineTile(MineDetonationType detonationType, IMineDetonationStrategy detonationStrategy);
    }
}