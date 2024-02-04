using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXSpawner : Spawner
{
    private static FXSpawner instance;
    public static FXSpawner Instance { get => instance; }

    public static string smoke1 = "Smoke_1a";

    protected override void Awake()
    {
        base.Awake();
        if (FXSpawner.instance != null) Debug.LogError("Ch? ???c dùng 1 singleton FXSpawner ");
        FXSpawner.instance = this;
    }

}
