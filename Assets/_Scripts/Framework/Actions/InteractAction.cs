using System;
using UnityEngine;

public class InteractAction : BaseAction
{
    public override void TakeAction(Action OnActionComplete)
    {
        _OnActionComplete = OnActionComplete;
        print("aa");
        _OnActionComplete?.Invoke();
    }
}
