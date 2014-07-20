namespace BattleFieldGame.Interfaces
{
    using BattleFieldGame.Helpers;
    interface IMineTile : IFieldTile
    {
        MineDetonationType type { get; }

        void Detonate(IGameField field, IMineDetonationStrategy strategy);
    }
}
