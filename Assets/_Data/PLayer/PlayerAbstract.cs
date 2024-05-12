using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAbstract : NamMonoBehaviour
{
    [Header("Playeyr Abstract")]
    [SerializeField] protected PlayerCtrl playerCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerCtrl();
    }
    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        //this.playerCtrl = GetComponentInParent<PlayerCtrl>();
        this.playerCtrl = transform.parent.GetComponent<PlayerCtrl>(); // trên dưới giống nhau nha má
        Debug.Log(transform.name + ": playerCtrl", gameObject);
    }


}
