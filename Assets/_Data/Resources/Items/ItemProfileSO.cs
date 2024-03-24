using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemProfileSO", menuName = "SO/ItemProfile")]
public class ItemProfileSO : ScriptableObject
{
    public Itemcode itemCode = Itemcode.NoItem;
    public ItemType itemType = ItemType.NoType;
    public string itemName = "No-name";
    public int defaultMaxStack = 7;
}

