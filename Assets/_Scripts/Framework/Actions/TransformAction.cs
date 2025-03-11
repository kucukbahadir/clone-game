using System;
using UnityEngine;
using System.Collections;
using UnityEditor.UI;

public class TransformAction : BaseAction
{
    public static EventHandler<Action<TransformationData>> OnTransformationAction;

    public override void TakeAction(Action OnActionComplete)
    {
        _OnActionComplete = OnActionComplete;
        OnTransformationAction?.Invoke(this, HandleNewTransformation);
    }

    private void HandleNewTransformation(TransformationData transformationData)
    {
        print(transformationData.GetTransformName());
        _OnActionComplete?.Invoke();
    }
}
