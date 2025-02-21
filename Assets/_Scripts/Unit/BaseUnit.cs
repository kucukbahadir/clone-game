using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    private BaseAction[] _unitActions;
    private BaseAction currentAction;

    void Awake()
    {
        _unitActions = GetComponents<BaseAction>();
    }

    public void TryDoingAction(ActionEventArgs actionEventArgs)
    {
        if (currentAction != null && !currentAction.IsInterruptible()) return;

        foreach (var action in _unitActions)
        {
            if(action.GetActionType() != actionEventArgs.ActionType || currentAction != null && currentAction == action) continue;

            currentAction = action;
            break;
        }

        if (currentAction == null) return;
        currentAction.TakeAction(OnActionComplete);
    }

    private void OnActionComplete()
    {
        currentAction = null;
    }
}
