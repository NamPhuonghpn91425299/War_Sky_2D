using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class ItemPickupable : NamMonoBehaviour
{
    [SerializeField] protected SphereCollider _collider;
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

}
