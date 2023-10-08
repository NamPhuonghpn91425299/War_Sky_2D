using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawn : NamMonoBehaviour
{
   
    protected virtual void FixedUpdate()
    {
        this.Despwaning();
    }
   
    protected virtual void Despwaning()
    {
        if (!this.CanDespawn()) return;
        this.DespawnObject();
    }
    protected virtual void DespawnObject()
    {
        Destroy(transform.parent.gameObject);
    }
    protected abstract bool CanDespawn();
 
}
