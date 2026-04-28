using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Scenes.GamePlay;

namespace Scenes.GamePlay.Upgrade
{
    public class UpgradeCardView : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private TextMeshProUGUI titleText;
        [SerializeField] private TextMeshProUGUI valueText;
        [SerializeField] private Button button;

        private UpgradeCardModel _model;
        private UpgradeService _service;
        private UpgradeView _view;

        [Inject]
        public void Construct(UpgradeService service)
        {
            _service = service;
        }

        public void Init(UpgradeCardModel model, UpgradeView view)
        {
            if (model == null)
            {
                Debug.LogError("UpgradeCardView: model is NULL in Init");
                return;
            }

            _model = model;

            if (_service == null)
            {
                Debug.LogError("UpgradeCardView: UpgradeService is NULL (DI not working)");
                if (button != null) button.interactable = false;
            }

            Debug.Log($"UpgradeCardView Init: model={_model}, type={_model.Type}, value={_model.Value}");
            _view = view;

            if (titleText != null)
                titleText.text = model.Type.ToString();

            if (valueText != null)
                valueText.text = $"+{model.Value:0.#}";

            if (button != null)
            {
                button.onClick.RemoveListener(OnClick);
                button.onClick.AddListener(OnClick);
            }
        }

        private void OnClick()
        {
            if (_service == null)
            {
                Debug.LogError("UpgradeCardView: UpgradeService is NULL (check Zenject binding)");
                return;
            }

            if (_model == null)
            {
                Debug.LogError("UpgradeCardView: model is NULL (check Init call)");
                return;
            }

            _service.Select(_model);
            _service.Confirm();

            if (_view != null)
            {
                _view.Hide();
            }
            else
            {
                Debug.LogWarning("UpgradeView is NULL");
            }
        }

        private void OnDestroy()
        {
            if (button != null)
            {
                button.onClick.RemoveListener(OnClick);
            }
        }
    }
}