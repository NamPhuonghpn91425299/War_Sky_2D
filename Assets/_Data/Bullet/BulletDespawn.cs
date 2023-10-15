using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawn : DespawnByDistance
{
    //protected override void LoadComponents()
    //{
    //    this.LoadCamera();
    //}
    protected override void DespawnObject()
    {
        //base.DespawnObject();
        BulletSpawner.Instance.Despawn(transform.parent);
    }
 
}
