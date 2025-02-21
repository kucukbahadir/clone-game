using System;
using UnityEngine;

public class CloneAction : BaseAction
{
    public override void TakeAction(Action OnActionComplete)
    {
        _OnActionComplete = OnActionComplete;
        print("Clone");
        _OnActionComplete?.Invoke();
    }
}
