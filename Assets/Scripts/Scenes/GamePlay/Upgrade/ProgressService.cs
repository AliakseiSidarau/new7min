using UnityEngine;

namespace Scenes.GamePlay.Upgrade
{
    public class ProgressService
    {
        private readonly StatsService _stats;
        private readonly UpgradeService _upgradeService;
        private readonly UpgradeView _upgradeView;

        private int _diamondsCollected;

        public ProgressService(StatsService stats, UpgradeService upgradeService, UpgradeView upgradeView)
        {
            _stats = stats;
            _upgradeService = upgradeService;
            _upgradeView = upgradeView;
        }

        public void AddDiamond()
        {
            _diamondsCollected++;

            if (_diamondsCollected >= _stats.Stats.diamondForUpgrade)
            {
                _diamondsCollected = 0;

                var cards = _upgradeService.GenerateCards();
                _upgradeView.Show(cards);
                Time.timeScale = 0f;
            }
        }
    }
}