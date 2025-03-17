using UnityEngine;

public class TransformationChecker : Interactable
{
    [SerializeField] private string requiredTransformation;

    public override void OnInteract(object sender)
    {
        if (sender is BaseUnit) return;
        var unitClone = (UnitClone)sender;
        if(unitClone.GetCurrentTransformation == null || unitClone.GetCurrentTransformation != requiredTransformation) return;

        print("good transformation");
    }
}
