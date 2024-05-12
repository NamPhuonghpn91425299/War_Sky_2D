using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : NamMonoBehaviour
{

    private static PlayerCtrl instance;
    public static PlayerCtrl Instance { get => instance; }

    [SerializeField] protected ShipCtrl currentShip;
    public ShipCtrl CurrentShip => currentShip;

    [SerializeField] protected PlayerPickUp playerPickUp;
    public PlayerPickUp PlayerPickUp => playerPickUp;

    protected override void Awake()
    {
        base.Awake();
        if (PlayerCtrl.instance != null) Debug.LogError("Ch? ???c dùng 1 singleton JunkSpawner ");
        PlayerCtrl.instance = this;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerPickUp();

    }
    protected virtual void LoadPlayerPickUp()
    {
        if (this.playerPickUp != null) return;
        this.playerPickUp = transform.GetComponentInChildren<PlayerPickUp>();
        Debug.Log(transform.name + ": playerPickUp", gameObject);
    }



}
