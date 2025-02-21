using UnityEngine;

public class MoveAction : BaseAction
{
    private Vector3 _moveDir;

    public override void TakeAction<T>(T value)
    {
        print(value);
    }
}
