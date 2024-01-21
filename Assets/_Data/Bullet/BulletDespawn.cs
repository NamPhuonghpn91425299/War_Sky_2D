using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawn : DespawnByDistance
{
    //protected override void LoadComponents()
    //{
    //    this.LoadCamera();
    //}
    public override void DespawnObject()
    {
        BulletSpawner.Instance.Despawn(transform.parent);
    }
 
}
