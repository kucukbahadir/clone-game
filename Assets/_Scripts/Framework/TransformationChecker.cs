using UnityEngine;

public class TransformationChecker : MonoBehaviour, IInteractable
{
    [SerializeField] private string requiredTransformation;

    public void OnInteract<T>(T transformationName)
    {
        print(transformationName);
        if(transformationName == null || transformationName.ToString() != requiredTransformation) return;

        print("good transformation");
    }
}
