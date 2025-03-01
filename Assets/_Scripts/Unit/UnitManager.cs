using System;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    [SerializeField] private BaseUnit currentUnit;

    void Start()
    {
        InputHandler.Instance.OnAnyInput += OnInput;
        UnitClone.OnUnitCloneSpawn += OnUnitCloneSpawn;
    }

    public void OnInput(object sender, ActionEventArgs actionEventArgs)
    {
        currentUnit.TryDoingAction(actionEventArgs);
    }

    public void OnUnitCloneSpawn(object sender, EventArgs actionEventArgs)
    {
        print("clone spawned " + sender.ToString());
    }
}
