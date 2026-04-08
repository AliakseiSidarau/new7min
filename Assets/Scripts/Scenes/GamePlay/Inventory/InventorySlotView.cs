using Scenes.Inventory.Items;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotView : MonoBehaviour
{
    public Image Icon;

    public void SetItem(Item item)
    {
        if (item == null)
        {
            Icon.enabled = false;
        }
        else
        {
            Icon.enabled = true;
            Icon.sprite = item.Config.Icon;
        }
    }
}