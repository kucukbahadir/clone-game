using UnityEngine;

public class UnitManager : MonoBehaviour
{
    [SerializeField] private BaseUnit currentUnit;

    public void OnMoveInput(Vector2 inputValue, ActionTypes actionType)
    {
        currentUnit.TryDoingAction(inputValue, actionType);
    }

    private void DoSomething(int test)
    {
        print(test);
    }
}
