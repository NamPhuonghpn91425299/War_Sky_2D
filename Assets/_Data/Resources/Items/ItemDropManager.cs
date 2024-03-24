using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropManager : Spawner
{
    private static ItemDropManager instance;
    public static ItemDropManager Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (ItemDropManager.instance != null) Debug.LogError("Ch? ???c dùng 1 singleton DropManager ");
        ItemDropManager.instance = this;
    }

    public virtual void Drop(List<DropRate> dropList, Vector3 pos, Quaternion rot)
    {
        Debug.Log(dropList[0].itemSO.itemName);
        Itemcode itemcode = dropList[0].itemSO.itemCode;
        Transform itemDrop = this.Spawn(itemcode.ToString(), pos, rot);
        if (itemDrop == null) return;
        itemDrop.gameObject.SetActive(true);
    }
}
