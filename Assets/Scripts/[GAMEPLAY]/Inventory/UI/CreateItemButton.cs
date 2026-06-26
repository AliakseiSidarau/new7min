using UnityEngine;
using Zenject;

public class CreateItemButton : MonoBehaviour
{
    private ItemFactory _factory;

    [Inject]
    public void Construct(ItemFactory factory)
    {
        _factory = factory;
    }

    public void OnClick()
    {
        var pos = new Vector3(Random.Range(-5, 5), Random.Range(-3, 3), 0);
        _factory.CreateRandom(pos);
    }
}