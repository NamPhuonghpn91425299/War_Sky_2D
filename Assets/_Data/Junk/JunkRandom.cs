using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkRandom : NamMonoBehaviour
{
    [SerializeField] protected JunkSpawnerCtrl junkCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtrl();

    }
    protected virtual void LoadJunkCtrl()
    {
        if (this.junkCtrl != null) return;
        this.junkCtrl = GetComponent<JunkSpawnerCtrl>();
        Debug.Log(transform.name + ": JunkCtrl", gameObject);
    }

    protected override void Start()
    {
        this.JunkSpawning();  
    }
    protected virtual void JunkSpawning()
    {
        Transform ranPoint = this.junkCtrl.SpawnPoints.GetRandom();
        // random positions from list points (Spawnpoint)
        
        Vector3 pos = ranPoint.position;
        pos.z = 0;
        Quaternion rot = transform.rotation;
        Transform prefab = this.junkCtrl.JunkSpawner.RandomPrefab();
        Transform obj = this.junkCtrl.JunkSpawner.Spawn(prefab, pos, rot);
        obj.gameObject.SetActive(true);
        Invoke(nameof(this.JunkSpawning), 2f);
    }
}
