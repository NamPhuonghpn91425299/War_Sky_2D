using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByDistance : Despawn
{
    [SerializeField] protected float disLimit = 70f;
    [SerializeField] protected float distance = 0f;
    [SerializeField] protected Camera maincam;

    protected override void LoadComponents()
    {
        this.LoadCamera();
    }
    protected virtual void LoadCamera()
    {
        if (this.maincam != null) return;
        this.maincam = Transform.FindObjectOfType<Camera>();
        Debug.Log(transform.parent.name + "Camera", gameObject);
    }
  
    protected override bool CanDespawn()
    {
        this.distance = Vector3.Distance(transform.position, this.maincam.transform.position);
        if (this.distance >= this.disLimit) return true;
        return false;
    }
}
