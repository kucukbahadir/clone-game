using UnityEngine;

public class ActionInputUI : MonoBehaviour
{
    [SerializeField] private ActionTypes actionType;

    public ActionTypes GetActionType => actionType;
}
