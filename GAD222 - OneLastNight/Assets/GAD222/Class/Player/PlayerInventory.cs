using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance;

    public List<ItemBaseClass> items = new List<ItemBaseClass>();

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogWarning(" MORE THEN ONE INVENTORY DELETING");
            Destroy(Instance);
        }
        Instance = this;
    }

    public void AddItem(ItemBaseClass item)
    {
        items.Add(item);
        Debug.Log(item.itemName + " added to inventory.");
        InventoryUIHolder.instance.UpdateUI(); // Call the UI update method
    }
}
