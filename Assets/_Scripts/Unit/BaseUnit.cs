using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    private BaseAction[] _unitActions;

    void Awake()
    {
        _unitActions = GetComponents<BaseAction>();
    }

    public void TryDoingAction(ActionEventArgs<object> actionEventArgs)
    {
        foreach (var action in _unitActions)
        {
            if(action.GetActionType() != actionEventArgs.ActionType) continue;

            action.TakeAction(actionEventArgs.Value);
        }
    }
}
