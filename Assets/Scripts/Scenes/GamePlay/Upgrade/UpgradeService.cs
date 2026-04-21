using System.Collections.Generic;
using UnityEngine;

namespace Scenes.GamePlay.Upgrade
{
    public class UpgradeService
    {
        private readonly IEventBus _eventBus;
        private readonly ShipModel _ship;

        private CardsModel _selected;

        public UpgradeService(IEventBus eventBus, ShipModel ship)
        {
            _eventBus = eventBus;
            _ship = ship;
        }

        public List<CardsModel> GenerateCards()
        {
            var result = new List<CardsModel>();
            var usedTypes = new HashSet<UpgradeType>();

            while (result.Count < 3)
            {
                var card = RandomCard();

                if (usedTypes.Contains(card.Type))
                    continue;

                usedTypes.Add(card.Type);
                result.Add(card);
            }

            return result;
        }

        private CardsModel RandomCard()
        {
            var values = System.Enum.GetValues(typeof(UpgradeType));
            var type = (UpgradeType)values.GetValue(Random.Range(0, values.Length));
            float value = type switch
            {
                UpgradeType.MaxEnergy => 10f,
                UpgradeType.Speed => 1.5f,
                UpgradeType.MaxEnergyPerMove => 2f,
                UpgradeType.RotationSpeed => 20f,
                UpgradeType.Maneuverability => 0.5f,
                _ => 1f
            };

            return new CardsModel(type, value);
        }
        public void Select(CardsModel card)
        {
            _selected = card;
        }

        public void Confirm()
        {
            if (_selected == null)
                return;

            _selected.Apply(_ship);

            _eventBus.RaiseEvent(new UpgradeAppliedSignal());

            _selected = null;
        }
    }
}