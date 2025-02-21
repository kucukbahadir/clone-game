using System;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public abstract class BaseAction : MonoBehaviour
{
    [SerializeField] private ActionTypes actionType;

    public abstract void TakeAction<T>(T value);

    public ActionTypes GetActionType()
    {
        return actionType;
    }
}
