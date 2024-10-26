using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items;

    public Item GetItemByID(int id)
    {
        return items.Find(item => item.ID == id);
    }
}
