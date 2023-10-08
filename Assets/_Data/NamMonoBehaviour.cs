using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NamMonoBehaviour : MonoBehaviour
{
    protected virtual void Awake()
    {
        this.LoadComponents();
    }
    protected virtual void Reset()
    {
        this.LoadComponents();
    }
    protected virtual void LoadComponents()
    {
    
    }

    //protected virtual void Update()
    //{

    //}
    protected virtual void Start()
    {
        
    }
}
