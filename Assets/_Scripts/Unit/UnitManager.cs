using System;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    [SerializeField] private BaseUnit currentUnit;

    [SerializeField]private List<BaseUnit> units;

    void Start()
    {
        units = new List<BaseUnit>{currentUnit};

        InputHandler.Instance.OnAnyInput += OnInput;
        UnitClone.OnUnitCloneSpawn += OnUnitCloneSpawn;
    }

    public void OnInput(object sender, ActionEventArgs actionEventArgs)
    {
        currentUnit.TryDoingAction(actionEventArgs);
    }

    public void OnUnitCloneSpawn(object sender, EventArgs actionEventArgs)
    {
        var cloneUnit = (BaseUnit)sender;
        units.Add(cloneUnit);
        currentUnit = cloneUnit;
    }
}
