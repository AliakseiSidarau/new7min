using UnityEngine;
using Zenject;

public class InventoryButton : MonoBehaviour
{
    private InventoryWindow _window;

    [Inject]
    public void Construct(InventoryWindow window)
    {
        _window = window;
    }

    public void OnClick()
    {
        Debug.Log("Inventory button clicked");
        _window.Open();
    }
}