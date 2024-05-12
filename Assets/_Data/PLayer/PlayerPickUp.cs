using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : PlayerAbstract
{
    public virtual void ItemPickUp (ItemPickupable itemPickupable)
    {
        Itemcode itemcode = itemPickupable.GetItemCode();
        if (this.playerCtrl.CurrentShip.Inventory.AddItem(itemcode, 1))
        {
            itemPickupable.Picked();
        }
    }    
}
