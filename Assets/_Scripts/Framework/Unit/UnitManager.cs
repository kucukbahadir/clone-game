using System;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviourSingleton<UnitManager>
{
    [SerializeField] private BaseUnit currentUnit;

    private List<BaseUnit> units;

    public EventHandler OnSwitchToNewUnit;

    protected override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        units = new List<BaseUnit>{currentUnit};

        InputHandler.Instance.OnAnyActionInput += OnInput;
        InputHandler.Instance.OnSwitchUnitInput += OnSwitchUnitInput;
        UnitClone.OnUnitCloneSpawn += OnUnitCloneSpawn;
    }

    private void OnInput(object sender, ActionTypes actionType)
    {
        currentUnit.TryDoingAction(actionType);
    }

    private void OnUnitCloneSpawn(object sender, EventArgs args)
    {
        var cloneUnit = (BaseUnit)sender;
        units.Add(cloneUnit);
        currentUnit = cloneUnit;
    }

    private void OnSwitchUnitInput(object sender, EventArgs args)
    {
        if (units.Count <= 1) return;

        var currentUnitIndex = GetCurrentUnitIndex();
        var newCurrentUnit = GetNextUnit(currentUnitIndex);

        if (currentUnit.CurrentActionIsNull())
        {
            currentUnit = newCurrentUnit;
        }
        else if(currentUnit.CurrentActionIsInterruptible())
        {
            currentUnit.OnSwitchUnit();
            currentUnit = newCurrentUnit;
        }

        OnSwitchToNewUnit?.Invoke(this, null);
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

    private BaseUnit GetNextUnit(int currentIndex) => currentIndex + 1 == units.Count ? units[0]: units[currentIndex + 1];
    public BaseUnit GetCurrentUnit => currentUnit;
}
