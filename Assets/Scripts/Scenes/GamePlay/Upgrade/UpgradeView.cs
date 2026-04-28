using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Scenes.GamePlay.Upgrade
{
    public class UpgradeView : MonoBehaviour
    {
        [SerializeField] private UpgradeCardView cardPrefab;
        [SerializeField] private Transform container;
        [Inject] private DiContainer _container;

        private readonly List<UpgradeCardView> _cards = new();

        public void Show(List<UpgradeCardModel> models)
        {
            if (cardPrefab == null || container == null)
            {
                Debug.LogError("UpgradeView: prefab or container not set");
                return;
            }

            gameObject.SetActive(true);

            foreach (var model in models)
            {
                var card = _container.InstantiatePrefabForComponent<UpgradeCardView>(cardPrefab, container);
                card.Init(model, this);
                _cards.Add(card);
            }
        }

        public void Hide()
        {
            foreach (var card in _cards)
            {
                if (card != null)
                    Destroy(card.gameObject);
            }

            _cards.Clear();
            gameObject.SetActive(false);
        }
    }
}