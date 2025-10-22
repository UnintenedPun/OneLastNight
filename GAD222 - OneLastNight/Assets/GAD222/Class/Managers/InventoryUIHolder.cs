using UnityEngine;

public class InventoryUIHolder : MonoBehaviour
{
    public static InventoryUIHolder instance;

    public Transform slotHolder;
    public GameObject slotPrefab;
    public InventorySlot[] slots;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of InventoryUI found!");
            return;
        }
        instance = this;
    }

    public void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < PlayerInventory.Instance.items.Count)
            {
                slots[i].AddItem(PlayerInventory.Instance.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
