using UnityEngine;

public class UnitManager : MonoBehaviour
{
    [SerializeField] private BaseUnit currentUnit;

    void Start()
    {
        InputHandler.Instance.OnAnyInput += OnInput;
    }

    public void OnInput(object sender, ActionEventArgs<object> actionEventArgs)
    {
        currentUnit.TryDoingAction(actionEventArgs.Value, actionEventArgs.ActionType);
    }
}
