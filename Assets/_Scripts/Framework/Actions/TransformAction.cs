using System;

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
        print(transformationData.GetTransformationName);
        _OnActionComplete?.Invoke();
    }
}
