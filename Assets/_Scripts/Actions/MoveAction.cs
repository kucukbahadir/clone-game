using UnityEngine;

public class MoveAction : BaseAction
{
    public override void TakeAction<T>(T value, ActionTypes actionType)
    {
        print(value);
        print(actionType);
    }
}
