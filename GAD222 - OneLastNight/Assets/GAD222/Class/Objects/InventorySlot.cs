using TMPro;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI text;

    public void AddItem(ItemBaseClass newItem)
    {
        icon.sprite = newItem.icon;
        text.text = newItem.name;
        gameObject.SetActive(true);
    }

    public void ClearSlot()
    {
        icon.sprite = null;
        text.text = null;
        gameObject.SetActive(false);
    }
}