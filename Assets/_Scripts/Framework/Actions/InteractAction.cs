using System;
using UnityEngine;

public class InteractAction : BaseAction
{
    [SerializeField] private InteractableChecker interactableChecker;

    public override void TakeAction(Action OnActionComplete)
    {
        _OnActionComplete = OnActionComplete;
        interactableChecker.GetClosestInteractable.OnInteract(_unitReference);
        _OnActionComplete?.Invoke();
    }
}
