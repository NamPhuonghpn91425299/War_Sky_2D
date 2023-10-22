using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkDespawn : DespawnByDistance
{
    //protected override void LoadComponents()
    //{
    //    //this.LoadCamera();
    //}
    protected override void DespawnObject()
    {
        //base.DespawnObject();
        JunkSpawner.Instance.Despawn(transform.parent);
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        this.disLimit = 20f;
    }
}
