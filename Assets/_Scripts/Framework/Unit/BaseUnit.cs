using System;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    protected BaseAction[] _unitActions;
    protected BaseAction currentAction;
    protected BaseUnit _unitReference;

    public static EventHandler OnBaseUnitSpawnIn;

    protected virtual void Awake()
    {
        _unitActions = GetComponents<BaseAction>();
        _unitReference = this;
    }

    private void Start()
    {
        OnBaseUnitSpawnIn?.Invoke(this, null);
    }

    public void TryDoingAction(ActionTypes actionType)
    {
        if (!CurrentActionIsNull() && !CurrentActionIsInterruptible()) return;

        foreach (var action in _unitActions)
        {
            if(action.GetActionType() != actionType || currentAction == action) continue;

            if(!CurrentActionIsNull()) currentAction.ActionGotInterrupted();
 
            currentAction = action;
            break;
        }

        if (CurrentActionIsNull()) return;
        currentAction.TakeAction(OnActionComplete);
    }

    protected void OnActionComplete() => currentAction = null;

    public void OnSwitchUnit() => currentAction.ActionGotInterrupted();

    public BaseAction GetCurrentAction() => currentAction;

    public bool CurrentActionIsNull() => currentAction == null;

    public bool CurrentActionIsInterruptible() => currentAction.IsInterruptible();

    public BaseUnit GetUnitReference => _unitReference;

    public BaseAction[] GetAllActions => _unitActions;
}
