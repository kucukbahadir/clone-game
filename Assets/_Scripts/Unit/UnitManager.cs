using System;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    [SerializeField] private BaseUnit currentUnit;

    private List<BaseUnit> units;

    void Start()
    {
        units = new List<BaseUnit>{currentUnit};

        InputHandler.Instance.OnAnyActionInput += OnInput;
        InputHandler.Instance.OnSwitchUnitInput += OnSwitchUnitInput;
        UnitClone.OnUnitCloneSpawn += OnUnitCloneSpawn;
    }

    private void OnInput(object sender, ActionEventArgs actionEventArgs)
    {
        currentUnit.TryDoingAction(actionEventArgs);
    }

    private void OnUnitCloneSpawn(object sender, EventArgs args)
    {
        var cloneUnit = (BaseUnit)sender;
        units.Add(cloneUnit);
        currentUnit = cloneUnit;
    }

    private void OnSwitchUnitInput(object sender, EventArgs args)
    {
        var currentUnitIndex = GetCurrentUnitIndex();
        var newCurrentUnit = GetNextUnit(currentUnitIndex);

        if (currentUnit.CurrentActionIsNull())
        {
            currentUnit = newCurrentUnit;
        }
        else if(currentUnit.CurrentACtionIsInterruptible())
        {
            currentUnit.OnSwitchUnit();
            currentUnit = newCurrentUnit;
        }
    }

    private int GetCurrentUnitIndex()
    {
        var currentIndex = 0;
        for (var i = 0; i < units.Count; i++)
        {
            if (currentUnit != units[i]) continue;
            currentIndex = i;
            break;
        }

        return currentIndex;
    }

    private BaseUnit GetNextUnit(int currentIndex)
    {
        return currentIndex + 1 == units.Count ? units[0]: units[currentIndex + 1];
    }
}
