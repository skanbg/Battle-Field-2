namespace BattleFieldGame.Interfaces
{
    using BattleFieldGame.Helpers;
    interface IMineTile : IFieldTile
    {
        MineDetonationType Type { get; }

        void Detonate(IMineDetonationStrategy strategy);
    }
}
