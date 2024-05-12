using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : NamMonoBehaviour
{
    [SerializeField] protected int maxSlot = 70;
    [SerializeField] protected List<ItemInventory> items;

    protected override void Start()
    {
        base.Start();
        this.AddItem(Itemcode.IronOre, 0);
    }
    public virtual bool AddItem(Itemcode itemcode, int addCount)
    {
        ItemInventory itemInventory = this.GetItemByCode(itemcode);
        int newCount = itemInventory.itemCount + addCount;
        if (newCount > itemInventory.maxStack) return false;
        itemInventory.itemCount = newCount;
        return true;
    }
    public virtual ItemInventory GetItemByCode(Itemcode itemcode)
    {
        ItemInventory itemInventory = this.items.Find((item) => item.itemProfile.itemCode == itemcode);
        if (itemInventory == null) itemInventory = this.AddEmptyProfile(itemcode);
        return itemInventory;
    }
    protected virtual ItemInventory AddEmptyProfile(Itemcode itemcode)
    {
        var profiles = Resources.LoadAll("ItemProfiles", typeof(ItemProfileSO));
        foreach (ItemProfileSO profile in profiles)
        {
            if (profile.itemCode != itemcode) continue;
            ItemInventory itemInventory = new ItemInventory
            {
                itemProfile = profile,
                maxStack = profile.defaultMaxStack
            };
            this.items.Add(itemInventory);
            return itemInventory;
        }
        return null;
    }
}
