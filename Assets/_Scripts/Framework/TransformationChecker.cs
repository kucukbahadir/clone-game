using UnityEngine;

public class TransformationChecker : Interactable
{
    [SerializeField] private string requiredTransformation;

    public override void OnInteract<T>(T transformationName)
    {
        print(transformationName);
        if(transformationName == null || transformationName.ToString() != requiredTransformation) return;

        print("good transformation");
    }
}
