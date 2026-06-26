using UnityEngine;
using Zenject;

public class InventoryWindow : MonoBehaviour
{
    public InventorySlotView[] Slots;

    private Inventory _inventory;

    [Inject]
    public void Construct(Inventory inventory)
    {
        _inventory = inventory;
    }

    private void OnEnable()
    {
        _inventory.OnChanged += Refresh;
        Refresh();
    }

    private void OnDisable()
    {
        _inventory.OnChanged -= Refresh;
    }

    public void Open()
    {
        Debug.Log("Window open method!");
        gameObject.SetActive(true);
        Debug.Log("Instance ID: " + GetInstanceID());
        Debug.Log("Name: " + gameObject.name);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    private void Refresh()
    {
        var grid = _inventory.GetGrid();

        int index = 0;

        for (int y = 0; y < grid.Height; y++)
        {
            for (int x = 0; x < grid.Width; x++)
            {
                Slots[index].SetItem(grid.Get(x, y));
                index++;
            }
        }
    }
}