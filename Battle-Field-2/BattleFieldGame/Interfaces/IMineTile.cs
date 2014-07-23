namespace BattleFieldGame.Interfaces
{
    using BattleFieldGame.Helpers;
    interface IMineTile : IFieldTile
    {
        MineDetonationType DetonationType { get; }

        void Detonate(IMineDetonationStrategy strategy);
    }
}
