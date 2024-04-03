using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : NamMonoBehaviour
{
    [SerializeField] protected float damage = 1f;
    public virtual void Send(Transform obj)
    {
        DamageReceiver damageReceiver = obj.GetComponentInChildren<DamageReceiver>();
        if (damageReceiver == null) return;
        this.Send(damageReceiver);
        this.CreateImpactFX();
    }
    public virtual void Send(DamageReceiver damageReceiver)
    {
        damageReceiver.Deduct(this.damage);
    }
    protected virtual void CreateImpactFX()
    {
        string fxName = this.GetImpactFX();
        Vector3 hitPos = transform.position;
        Quaternion hitRos = transform.rotation;
        Transform fxImpact = FXSpawner.Instance.Spawn(fxName, hitPos, hitRos);
        fxImpact.gameObject.SetActive(true);
    }
    protected virtual string GetImpactFX()
    {
        return FXSpawner.impact1;
    }


}
