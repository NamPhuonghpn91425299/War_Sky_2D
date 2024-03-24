using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [CreateAssetMenu(fileName = "Item", menuName = "SO/Item")]
public class ItemSO : ScriptableObject
{
    public Itemcode itemCode = Itemcode.NoItem;
    public string itemName = "Item";
}
