using UnityEngine;
using UnityEngine.Events;

public class TransformationChecker : Interactable
{
    [SerializeField, HideInInspector]private string requiredTransformation;

    public UnityEvent OnRightInteraction;

    public override void OnInteract(object sender)
    {
        if (sender is not UnitClone) return;
        var unitClone = (UnitClone)sender;
        if(unitClone.GetCurrentTransformation == null || unitClone.GetCurrentTransformation != requiredTransformation)
        {
            print("wrong transformation the transformation need is: " + requiredTransformation);
            return;
        }

        _isInteractable = false;
        OnCorrectInteraction?.Invoke(this, null);
        OnRightInteraction?.Invoke();
    }

    public void SetRequiredTransformation(string newRequiredTransformation) => requiredTransformation = newRequiredTransformation;  
    public string GetRequiredTransformation => requiredTransformation;
}
