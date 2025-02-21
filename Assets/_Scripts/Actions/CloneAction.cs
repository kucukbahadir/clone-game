using UnityEngine;

public class CloneAction : BaseAction
{
    public override void TakeAction<T>(T value)
    {
        print(value);
    }
}
