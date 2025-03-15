using UnityEngine;

public class TransformationChecker : MonoBehaviour, IInteractable
{
    [SerializeField] private string requiredTransformation;

    public void OnInteract(string transformationName)
    {
        if(transformationName == null || transformationName != requiredTransformation) return;

        print("good transformation");
    }
}
