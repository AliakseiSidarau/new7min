using Scenes.Inventory.Items;

public class InventoryGrid
{
    private readonly Item[,] _grid;

    public int Width { get; }
    public int Height { get; }

    public InventoryGrid(int width, int height)
    {
        Width = width;
        Height = height;
        _grid = new Item[width, height];
    }

    public Item Get(int x, int y) => _grid[x, y];

    public void Set(int x, int y, Item item)
    {
        _grid[x, y] = item;
    }

    public bool IsEmpty(int x, int y)
    {
        return _grid[x, y] == null;
    }

    public void Clear(int x, int y)
    {
        _grid[x, y] = null;
    }
}