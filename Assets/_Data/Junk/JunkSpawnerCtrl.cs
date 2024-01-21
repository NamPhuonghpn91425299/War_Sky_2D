using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawnerCtrl : NamMonoBehaviour
{
    [SerializeField] protected JunkSpawner junkSpawner;
    public JunkSpawner JunkSpawner { get => junkSpawner; }

    [SerializeField] protected JunkSpawnPoint spawnPoints;
    public JunkSpawnPoint SpawnPoints { get => spawnPoints; }

    //[SerializeField] protected SpawnerCtrl spawnerCtrl;
    //public SpawnerCtrl SpawnerCtrl => spawnerCtrl;
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
        if (this.spawnPoints != null) return;
        this.spawnPoints = Transform.FindAnyObjectByType<JunkSpawnPoint>();
        Debug.Log(transform.name + ": spawnPoint", gameObject);
    }

}
