using System;
using UnityEngine;

public class InteractAction : BaseAction
{
    [SerializeField] private InteractableChecker interactableChecker;

    public override void TakeAction(Action OnActionComplete)
    {
        _OnActionComplete = OnActionComplete;
        if(interactableChecker.GetClosestInteractable == null)
        {
            _OnActionComplete?.Invoke();
            return;
        }
        interactableChecker.GetClosestInteractable.OnInteract(_unitReference);
        _OnActionComplete?.Invoke();
    }
}
