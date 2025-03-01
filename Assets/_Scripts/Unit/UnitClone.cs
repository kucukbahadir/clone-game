using System;
using UnityEditor.UI;
using UnityEngine;

public class UnitClone : BaseUnit
{
    public static EventHandler OnUnitCloneSpawn;

    void Start()
    {
        OnUnitCloneSpawn?.Invoke(this, null);
    }
}
