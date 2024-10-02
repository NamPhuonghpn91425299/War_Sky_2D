using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(SphereCollider))]
public class ItemPickupable : ItemAbstract
{
    [Header("ItemPickupable")]
    [SerializeField] protected SphereCollider _collider;

    public static Itemcode String2ItemCode(string itemname) // chuyển chuỗi string thành dạng enum
    {
        try
        {
            return (Itemcode)System.Enum.Parse(typeof(Itemcode), itemname);
        }
        catch (AggregateException e)
        {
            Debug.LogError(e.ToString());
            return Itemcode.NoItem;
        }

    }
    public virtual void OnMouseDown()
    {
        Debug.Log(transform.parent.name + "On Click");
        PlayerCtrl.Instance.PlayerPickUp.ItemPickUp(this);
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpherecollider();
    }
    protected virtual void LoadSpherecollider()
    {
        if (this._collider != null) return;
        this._collider = transform.GetComponent<SphereCollider>();
        this._collider.isTrigger = true;
        this._collider.radius = 0.25f;
        this._collider.center = new Vector3(0f, 0.25f, 0f);
        Debug.Log(transform.name + ": _collider", gameObject);
    }
    public virtual Itemcode GetItemCode()
    {
        return ItemPickupable.String2ItemCode(transform.parent.name);
    }
    public virtual void Picked()
    {
        this.ItemCtrl.ItemDespawn.DespawnObject();
    }

}
