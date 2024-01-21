using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class DamageReceiver : NamMonoBehaviour
{
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected float hp = 1f;
    [SerializeField] protected float hpMax = 2f;
    [SerializeField] protected bool isDead = false;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
    }
    protected virtual void LoadSphereCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.3f;
        Debug.Log(transform.name + ": LoadCollider", gameObject);
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        this.Reborn();
    }
  
    public virtual void Reborn()
    {
        this.hp = this.hpMax;
        this.isDead = false;
    }
    public virtual void Add(float add)
    {
        if (this.isDead) return;
        this.hp += add;
        if (this.hp >= this.hpMax) this.hp = this.hpMax;
    } 
    public virtual void Deduct(float deduct)
    {
        if (this.isDead) return;
        this.hp -= deduct;
        if (this.hp < 0) this.hp = 0;
        this.CheckIsDead();
    }
    protected virtual bool IsDead()
    {
        return this.hp <= 0;
    }
    protected virtual void CheckIsDead()
    {
        if (!IsDead()) return;
        this.isDead = true;
        this.OnDead();
    }
    protected virtual void OnDead()
    {

    }
}
