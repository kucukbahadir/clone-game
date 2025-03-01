using System;
using Unity.IO.LowLevel.Unsafe;
using UnityEditor.Build.Reporting;
using UnityEngine;

[DisallowMultipleComponent]
public abstract class BaseAction : MonoBehaviour
{
    [SerializeField] private ActionTypes actionType;
    [SerializeField] private bool interruptible;

    protected bool _isBusy;
    protected Action _OnActionComplete;

    public abstract void TakeAction(Action OnActionComplete);

    public ActionTypes GetActionType()
    {
        return actionType;
    }

    public bool IsInterruptible()
    {
        return interruptible;
    }

    public virtual void ActionGotInterrupted(){}

    public new string ToString()
    {
        return this.GetType().Name;
    }

}
