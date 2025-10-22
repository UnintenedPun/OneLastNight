using UnityEngine;
using static UnityEditor.Progress;

public class PickUp : MonoBehaviour
{
    public ItemBaseClass item;

    public void Interact()
    {
        PlayerInventory.Instance.AddItem(item);
        Destroy(gameObject);
    }
}
