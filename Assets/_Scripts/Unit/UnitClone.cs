using System;
using UnityEditor.UI;
using UnityEngine;

public class UnitClone : BaseUnit
{
    public static EventHandler OnUnitCloneSpawn;

    protected override void Awake()
    {
        base.Awake();
        OnUnitCloneSpawn?.Invoke(this, null);     
    }
}
