using System;
using Scenes.Inventory;
using Scenes.Inventory.Items;

public class Inventory
{
    private readonly InventoryGrid _grid;

    public event Action OnChanged;

    public Inventory(int width, int height)
    {
        _grid = new InventoryGrid(width, height);
    }

    public bool TryAddItem(ItemConfig config)
    {
        for (int x = 0; x < _grid.Width; x++)
        {
            for (int y = 0; y < _grid.Height; y++)
            {
                if (_grid.IsEmpty(x, y))
                {
                    _grid.Set(x, y, new Item(config));
                    OnChanged?.Invoke();
                    return true;
                }
            }
        }

        return false;
    }

    public void RemoveAt(int x, int y)
    {
        if (!_grid.IsEmpty(x, y))
        {
            _grid.Clear(x, y);
            OnChanged?.Invoke();
        }
    }

    public InventoryGrid GetGrid() => _grid;
}