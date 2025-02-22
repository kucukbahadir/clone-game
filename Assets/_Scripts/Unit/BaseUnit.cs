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
        if (currentAction != null && !currentAction.IsInterruptible()) return;

        foreach (var action in _unitActions)
        {
            //current is move
            // new is clone
            if(action.GetActionType() != actionEventArgs.ActionType || currentAction == action) continue;
            print("Interrupted");

            //de actie is geinterruped dus zorg dat de current stopt met zijn logica
            //daarna word de current de nieuwe actie
            if(currentAction != null)
            {
                currentAction.ActionGotInterrupted();
            }
            currentAction = action;
            break;
        }

        if (currentAction == null) return;
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
}
