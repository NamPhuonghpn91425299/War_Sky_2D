using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkCtrl : NamMonoBehaviour
{
    [SerializeField] protected JunkSpawner junkSpawner;
    public JunkSpawner JunkSpawner { get => junkSpawner; }

    [SerializeField] protected JunkSpawnPoint spawnPoint;
    public JunkSpawnPoint SpawnPoint { get => spawnPoint; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkSpawner();
        this.LoadSpawnPoint();
    }
    protected virtual void LoadJunkSpawner()
    {
        if (this.junkSpawner != null) return;
        this.junkSpawner = GetComponent<JunkSpawner>();
        Debug.Log(transform.name + ": JunkSpawner", gameObject);
    }
    protected virtual void LoadSpawnPoint()
    {
        if (this.spawnPoint != null) return;
        this.spawnPoint = Transform.FindAnyObjectByType<JunkSpawnPoint>();
        Debug.Log(transform.name + ": spawnPoint", gameObject);
    }

}
