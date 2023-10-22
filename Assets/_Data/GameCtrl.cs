using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : NamMonoBehaviour
{
    protected static GameCtrl instance;
    public static GameCtrl Instance { get => instance; }

    [SerializeField] protected Camera mainCamera;
    public Camera MainCamera { get => mainCamera; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMainCamera();

    }
    protected override void Awake()
    {
        base.Awake();
        if (GameCtrl.instance != null) Debug.Log("Only one GameCtrl");
        GameCtrl.instance = this;
    }
    protected virtual void LoadMainCamera()
    {
        if (this.mainCamera != null) return;
        this.mainCamera = Transform.FindObjectOfType<Camera>();
        Debug.Log(transform.name + ": mainCamera", gameObject);
    }
}
