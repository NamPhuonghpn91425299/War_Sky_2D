using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : NamMonoBehaviour
{
    [SerializeField] protected Transform holder;
    [SerializeField] protected int spawnerCount=0;
    public int SpawerCount => spawnerCount; 

    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected List<Transform> poolObjs;

    protected override void Reset()
    {
        this.LoadComponents();
    }
    protected override void LoadComponents()
    {
        this.LoadPrefab();
        this.LoadHolder();
    }
    protected virtual void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = transform.Find("Holder");
        Debug.Log(transform.name + ": LoadHolder", gameObject);
    }
    protected virtual void LoadPrefab()
    {
        if (this.prefabs.Count > 0) return; // nếu đã load list rồi thì không cần load lại nữa

        Transform prefabObj = transform.Find("Prefabs");
        foreach (Transform prefab in prefabObj)
        {
            this.prefabs.Add(prefab);
        }
        this.HidePrefabs();
        Debug.Log(transform.name + ": loadprefab", gameObject);
    }
    protected virtual void HidePrefabs()
    {
        foreach (Transform prefab in this.prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }
    public virtual Transform Spawn(string prefabName, Vector3 spawnPos, Quaternion rotation)
    {
        Transform prefab = this.GetPrefabByName(prefabName);
        if(prefabName == null)
        {
            Debug.Log("Prefab not found: " + prefabName);
            return null;
        }
        //Transform newPrefab = Instantiate(prefab, spawnPos, rotation);

        return this.Spawn(prefab,spawnPos,rotation);
    }   
    public virtual Transform Spawn(Transform prefab, Vector3 spawnPos, Quaternion rotation)
    {
        Transform newPrefab = this.GetObjectFromPool(prefab);
        newPrefab.SetPositionAndRotation(spawnPos, rotation); // chỉnh lại về vị trí ban đầu sau khi pool
        newPrefab.parent = this.holder; // instance bullet and get in parent of holder
        this.spawnerCount++;
        return newPrefab;
    }   
    protected virtual Transform GetObjectFromPool(Transform prefab) // tái sử dụng lại object đã dùng
    {
        foreach (Transform poolObj in this.poolObjs)
        {
            if (poolObj == null) continue;
            if (poolObj.name == prefab.name)
            {
                this.poolObjs.Remove(poolObj);
                return poolObj;
            }
        }
            Transform newPrefab = Instantiate(prefab);
            newPrefab.name = prefab.name;
            return newPrefab;
    }
    public virtual void Despawn(Transform obj)
    {
        this.poolObjs.Add(obj);
        obj.gameObject.SetActive(false);
        this.spawnerCount--;
    }
    public virtual Transform GetPrefabByName(string prefabName)
    {
        foreach (Transform prefab in this.prefabs)
        {
            if (prefab.name == prefabName) return prefab;
        }
        return null;
    }
    public virtual Transform RandomPrefab()
    {
        int rand = Random.Range(0,this.prefabs.Count);
        return this.prefabs[rand];
    }
}
