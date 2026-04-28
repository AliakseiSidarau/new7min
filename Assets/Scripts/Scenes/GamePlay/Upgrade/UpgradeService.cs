using System.Collections.Generic;
using UnityEngine;

namespace Scenes.GamePlay.Upgrade
{
    public class UpgradeService
    {
        private readonly ShipModel _ship;

        private UpgradeCardModel _selected;

        public UpgradeService(ShipModel ship)
        {
            _ship = ship;
        }

        public List<UpgradeCardModel> GenerateCards()
        {
            var result = new List<UpgradeCardModel>();
            var usedTypes = new HashSet<UpgradeType>();

            int maxIterations = 10;
            int iterations = 0;

            while (result.Count < 3 && iterations < maxIterations)
            {
                iterations++;
                var card = RandomCard();

                if (usedTypes.Contains(card.Type))
                    continue;

                usedTypes.Add(card.Type);
                result.Add(card);
            }

            return result;
        }

        private UpgradeCardModel RandomCard()
        {
            var values = (UpgradeType[])System.Enum.GetValues(typeof(UpgradeType));
            var type = values[Random.Range(0, values.Length)];
            float value = type switch
            {
                UpgradeType.MaxEnergy => 10f,
                UpgradeType.Speed => 1.5f,
                UpgradeType.MaxEnergyPerMove => 2f,
                UpgradeType.RotationSpeed => 20f,
                UpgradeType.Maneuverability => 0.5f,
                _ => 1f
            };

            return new UpgradeCardModel(type, value);
        }
        public void Select(UpgradeCardModel upgradeCard)
        {
            _selected = upgradeCard;
        }

        public void Confirm()
        {
            if (_selected == null)
                return;

            _selected.Apply(_ship);

            _selected = null;
        }
    }
}