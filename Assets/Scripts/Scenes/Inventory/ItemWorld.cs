using Scenes.Inventory;
using UnityEngine;
using Zenject;

public class ItemWorld : MonoBehaviour
{
    private ItemConfig _config;
    private IItemService _itemService;
    private SpriteRenderer _renderer;

    [Inject]
    public void Construct(IItemService itemService)
    {
        _itemService = itemService;
    }

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    public void Init(ItemConfig config)
    {
        _config = config;

        if (_renderer == null)
        {
            Debug.LogError("SpriteRenderer missing!");
            return;
        }

        _renderer.sprite = config.Icon;
        _renderer.name = config.Name;
    }

    private void OnMouseDown()
    {
        _itemService.AddItem(_config.Id);
        Destroy(gameObject);
    }
}