using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    [System.Serializable]
    public class ItemData
    {
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
    public List<ItemData> items;
}
