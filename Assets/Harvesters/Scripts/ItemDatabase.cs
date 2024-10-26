using System.Collections.Generic;
using UnityEngine;

public class ItemDatabasee : MonoBehaviour
{
    [System.Serializable]
    public class Item
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
    public List<Item> items;
}
