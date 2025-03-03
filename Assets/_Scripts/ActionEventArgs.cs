using System;
using UnityEngine;

public class ActionEventArgs : EventArgs
{
    public ActionTypes ActionType;

    public ActionEventArgs(ActionTypes actionType) => ActionType = actionType;
}
