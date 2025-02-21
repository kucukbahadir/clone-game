using System;
using UnityEngine;

public class ActionEventArgs<T> : EventArgs
{
    public T Value;
    public ActionTypes ActionType;

    public ActionEventArgs(T value, ActionTypes actionType)
    {
        Value = value;
        ActionType = actionType;
    }
}
