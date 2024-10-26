using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Scriptable Objects/Inventory/New Item")]
public class Item : ScriptableObject
{
    public int ID;
    public string itemName;
    public GameObject itemObject;
    public GameObject itemSprite;
    public ItemType itemType;
}

public enum ItemType
{
    Tool,
    Crop
}
