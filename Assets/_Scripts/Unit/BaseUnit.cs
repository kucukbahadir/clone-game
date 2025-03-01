using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    protected BaseAction[] _unitActions;
    protected BaseAction currentAction;

    protected void Awake()
    {
        _unitActions = GetComponents<BaseAction>();
    }

    public void TryDoingAction(ActionEventArgs actionEventArgs)
    {
        if (!CurrentActionIsNull() && !currentAction.IsInterruptible()) return;

        foreach (var action in _unitActions)
        {
            if(action.GetActionType() != actionEventArgs.ActionType || currentAction == action) continue;

            if(!CurrentActionIsNull())
            {
                currentAction.ActionGotInterrupted();
            }
            currentAction = action;
            break;
        }

        if (CurrentActionIsNull()) return;
        currentAction.TakeAction(OnActionComplete);
    }

    protected void OnActionComplete()
    {
        currentAction = null;
    }

    public BaseAction GetCurrentAction()
    {
        return currentAction;
    }

    private bool CurrentActionIsNull()
    {
        return currentAction == null;
    }
}
