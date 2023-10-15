using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawner : Spawner
{
    private static JunkSpawner instance;
    public static JunkSpawner Instance { get => instance; }

    public static string meteoriteOne = "Meteorite_1";

    protected override void Awake()
    {
        base.Awake();
        if (JunkSpawner.instance != null) Debug.LogError("Ch? ???c dùng 1 singleton JunkSpawner ");
        JunkSpawner.instance = this;
    }

}
