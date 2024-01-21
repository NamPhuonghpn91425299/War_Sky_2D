using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Ship", menuName = "ScriptableObjects/Ship")]
public class ShipSO : ScriptableObject
{
    public string junkName = "Ship";
    public int hpMax = 20;
}
