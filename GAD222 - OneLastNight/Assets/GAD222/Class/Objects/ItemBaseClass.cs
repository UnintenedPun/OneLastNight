using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class ItemBaseClass : ScriptableObject
{
    public string itemName;
    public Sprite icon;
}
