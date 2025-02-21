using UnityEngine;

public class UnitManager : MonoBehaviour
{
    [SerializeField] private BaseUnit currentUnit;

    public void OnMoveInput(Vector2 inputValue)
    {
        currentUnit.Move(inputValue);
    }
}
