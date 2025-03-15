using System;
using UnityEngine;

public class InteractAction : BaseAction
{
    [SerializeField] private InteractableChecker interactableChecker;

    public override void TakeAction(Action OnActionComplete)
    {
        _OnActionComplete = OnActionComplete;
        var unitCloneCast = (UnitClone)_unitReference;
        interactableChecker.GetCurrentInteractable.OnInteract(unitCloneCast.GetCurrentTransformation);
        _OnActionComplete?.Invoke();
    }
}
