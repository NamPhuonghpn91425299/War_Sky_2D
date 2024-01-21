using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkDamageReceiver : DamageReceiver
{
    [SerializeField] protected JunkCtrl junkCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtrl();
    }
    protected virtual void LoadJunkCtrl()
    {
        if (this.junkCtrl != null) return;
        this.junkCtrl = transform.parent.GetComponent<JunkCtrl>();
    }

    protected override void OnDead()
    {
        base.OnDead();
        this.junkCtrl.JunkDespawn.DespawnObject();
    }
    public override void Reborn()
    {
        this.hpMax = this.junkCtrl.JunkSO.hpMax;
        //base.Reborn();
    }


}
