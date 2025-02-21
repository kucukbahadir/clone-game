using System;
using Unity.IO.LowLevel.Unsafe;
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

    public abstract string ToString();
}
