namespace Scenes.GamePlay.Upgrade
{
    public class ProgressService
    {
        private readonly IEventBus _eventBus;
        private readonly StatsService _stats;

        private int _diamondCollected;

        public ProgressService(IEventBus eventBus, StatsService stats)
        {
            _eventBus = eventBus;
            _stats = stats;
        }

        public void AddDiamond()
        {
            _diamondCollected++;

            if (_diamondCollected >= _stats.Stats.diamondForUpgrade)
            {
                _diamondCollected = 0;

                _eventBus.RaiseEvent(new ShowUpgradeSignal());
            }
        }
    }
}