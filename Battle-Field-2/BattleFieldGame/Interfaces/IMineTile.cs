namespace BattleFieldGame.Interfaces
{
    using BattleFieldGame.Helpers;
   public interface IMineTile : IFieldTile
    {
        MineDetonationType DetonationType { get; }

        void Detonate(IMineDetonationStrategy strategy);
    }
}
