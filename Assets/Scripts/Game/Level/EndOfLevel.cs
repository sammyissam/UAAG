using Game.Overworld.Shop;
using Utility.GameFlow;

namespace Game.Level
{
    public class EndOfLevel : TriggerParent
    {
        protected override void Command()
        {
            PlayerManager.instance.LevelComplete();
        }
    }
}