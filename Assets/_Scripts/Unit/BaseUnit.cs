using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    private BaseAction[] _unitActions;

    void Awake()
    {
        _unitActions = GetComponents<BaseAction>();
    }

    public void TryDoingAction<T>(T value,ActionTypes actionType)
    {
        foreach (var action in _unitActions)
        {
            if(action.GetActionType() != actionType) continue;

            action.TakeAction(value, actionType);
        }
    }
}
